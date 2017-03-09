﻿using Amqp;
using Amqp.Framing;
using IoTHubAmqp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Newtonsoft.Json;

namespace IoTHubAmqpService
{
    class SendCommand
    {
            private const string HOST = "ManageIoT.azure-devices.net";
            private const int PORT = 5671;
            private const string SHARED_ACCESS_KEY_NAME = "iothubowner";
            private const string SHARED_ACCESS_KEY = "XnRSB9kO1Knhq6sL7QMhWhxqshHsGV34NBw+HnDj5oU=";

            private const string DEVICE_ID = "Device_1";

            private static Address address;
            private static Connection connection;
            private static Session session;


            public static void SendCommandToDevice()
            {
                Amqp.Trace.TraceLevel = Amqp.TraceLevel.Frame | Amqp.TraceLevel.Verbose;
                //Amqp.Trace.TraceListener = (f, a) => System.Diagnostics.Trace.WriteLine(DateTime.Now.ToString("[hh:ss.fff]") + " " + Fx.Format(f, a));

                address = new Address(HOST, PORT, null, null);
                connection = new Connection(address);

                session = new Session(connection);

                // just as example ...
                // the application ends only after received a command or timeout on receiving

                string audience = Fx.Format("{0}/messages/devicebound", HOST);
                string resourceUri = Fx.Format("{0}/messages/devicebound", HOST);

                string sasToken = GetSharedAccessSignature(SHARED_ACCESS_KEY_NAME, SHARED_ACCESS_KEY, resourceUri,
                    new TimeSpan(1, 0, 0));
                bool cbs = PutCbsToken(connection, HOST, sasToken, audience);

                if (cbs)
                {
                    string to = Fx.Format("/devices/{0}/messages/devicebound", DEVICE_ID);
                    string entity = "/messages/devicebound";

                    SenderLink senderLink = new SenderLink(session, "sender-link", entity);

                    var messageValue = Encoding.UTF8.GetBytes("i am a command.");
                    Message message = new Message()
                    {
                        BodySection = new Data() {Binary = messageValue}
                    };
                    message.Properties = new Properties();
                    message.Properties.To = to;
                    message.Properties.MessageId = Guid.NewGuid().ToString();
                    message.ApplicationProperties = new ApplicationProperties();
                    message.ApplicationProperties["iothub-ack"] = "full";

                    senderLink.Send(message);
                    senderLink.Close();
                }
                session.Close();
                connection.Close();
            }

            static private bool PutCbsToken(Connection connection, string host, string shareAccessSignature,
                string audience)
            {
                bool result = true;
                Session session = new Session(connection);

                string cbsReplyToAddress = "cbs-reply-to";
                var cbsSender = new SenderLink(session, "cbs-sender", "$cbs");
                var cbsReceiver = new ReceiverLink(session, cbsReplyToAddress, "$cbs");

                // construct the put-token message
                var request = new Message(shareAccessSignature);
                request.Properties = new Properties();
                request.Properties.MessageId = Guid.NewGuid().ToString();
                request.Properties.ReplyTo = cbsReplyToAddress;
                request.ApplicationProperties = new ApplicationProperties();
                request.ApplicationProperties["operation"] = "put-token";
                request.ApplicationProperties["type"] = "azure-devices.net:sastoken";
                request.ApplicationProperties["name"] = audience;
                cbsSender.Send(request);

                // receive the response
                var response = cbsReceiver.Receive();
                if (response == null || response.Properties == null || response.ApplicationProperties == null)
                {
                    result = false;
                }
                else
                {
                    int statusCode = (int) response.ApplicationProperties["status-code"];
                    string statusCodeDescription = (string) response.ApplicationProperties["status-description"];
                    if (statusCode != (int) 202 && statusCode != (int) 200) // !Accepted && !OK
                    {
                        result = false;
                    }
                }

                // the sender/receiver may be kept open for refreshing tokens
                cbsSender.Close();
                cbsReceiver.Close();
                session.Close();

                return result;
            }

            private static readonly long UtcReference = (new DateTime(1970, 1, 1, 0, 0, 0, 0)).Ticks;

            static string GetSharedAccessSignature(string keyName, string sharedAccessKey, string resource,
                TimeSpan tokenTimeToLive)
            {
                // http://msdn.microsoft.com/en-us/library/azure/dn170477.aspx
                // the canonical Uri scheme is http because the token is not amqp specific
                // signature is computed from joined encoded request Uri string and expiry string

#if NETMF
// needed in .Net Micro Framework to use standard RFC4648 Base64 encoding alphabet
            System.Convert.UseRFC4648Encoding = true;
#endif
                string expiry =
                    ((long)
                        (DateTime.UtcNow - new DateTime(UtcReference, DateTimeKind.Utc) + tokenTimeToLive).TotalSeconds())
                    .ToString();
                string encodedUri = HttpUtility.UrlEncode(resource);

                byte[] hmac = SHA.computeHMAC_SHA256(Convert.FromBase64String(sharedAccessKey),
                    Encoding.UTF8.GetBytes(encodedUri + "\n" + expiry));
                string sig = Convert.ToBase64String(hmac);

                if (keyName != null)
                {
                    return Fx.Format(
                        "SharedAccessSignature sr={0}&sig={1}&se={2}&skn={3}",
                        encodedUri,
                        HttpUtility.UrlEncode(sig),
                        HttpUtility.UrlEncode(expiry),
                        HttpUtility.UrlEncode(keyName));
                }
                else
                {
                    return Fx.Format(
                        "SharedAccessSignature sr={0}&sig={1}&se={2}",
                        encodedUri,
                        HttpUtility.UrlEncode(sig),
                        HttpUtility.UrlEncode(expiry));
                }
            }
        }
    }
