using Amqp;
using Amqp.Framing;
using IoTHubAmqp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using ConsoleApplication1;
using Newtonsoft.Json;

namespace IoTHubAmqpService
{
    public class SendCommand
    {
            private const string HOST = "ManageIoT.azure-devices.net";
            private const int PORT = 5671;
            private const string SHARED_ACCESS_KEY_NAME = "iothubowner";
            private const string SHARED_ACCESS_KEY = "XnRSB9kO1Knhq6sL7QMhWhxqshHsGV34NBw+HnDj5oU=";
        //private const string SHARED_ACCESS_KEY = "ztqW3Ibsf14nTK3G2sTlQLRYEwaVsXVtM918wD0k9BA=";

        private const string DEVICE_ID = "Device_1";

            private static Address address;
            private static Connection connection;
            private static Session session;


            public void SendCommandToDevice()
            {
            System.Diagnostics.Debug.WriteLine("Level 1");
                Amqp.Trace.TraceLevel = Amqp.TraceLevel.Frame | Amqp.TraceLevel.Verbose;
            //Amqp.Trace.TraceListener = (f, a) => System.Diagnostics.Trace.WriteLine(DateTime.Now.ToString("[hh:ss.fff]") + " " + Fx.Format(f, a));
            System.Diagnostics.Debug.WriteLine("Level 2");

            address = new Address(HOST, PORT, null, null);
            System.Diagnostics.Debug.WriteLine("Level 3");

            connection = new Connection(address);
            System.Diagnostics.Debug.WriteLine("Level 4");

            session = new Session(connection);
            System.Diagnostics.Debug.WriteLine("Level 5");

            // just as example ...
            // the application ends only after received a command or timeout on receiving

            string audience = Fx.Format("{0}/messages/devicebound", HOST);
            System.Diagnostics.Debug.WriteLine("Level 6");

            string resourceUri = Fx.Format("{0}/messages/devicebound", HOST);
            System.Diagnostics.Debug.WriteLine("Level 7");

            string sasToken = GetSharedAccessSignature(SHARED_ACCESS_KEY_NAME, SHARED_ACCESS_KEY, resourceUri,
                    new TimeSpan(1, 0, 0));
            System.Diagnostics.Debug.WriteLine("Level 8");

            //bool cbs = PutCbsToken(connection, HOST, sasToken, audience);
            bool cbs = PutCbsToken(connection, HOST, sasToken, audience);

            System.Diagnostics.Debug.WriteLine("Level 9");

            if (cbs)
                {
                    string to = Fx.Format("/devices/{0}/messages/devicebound", DEVICE_ID);
                    string entity = "/messages/devicebound";
                System.Diagnostics.Debug.WriteLine("Level 10");

                SenderLink senderLink = new SenderLink(session, "sender-link", entity);
                System.Diagnostics.Debug.WriteLine("Level 11");

                System.Diagnostics.Debug.WriteLine("Level 12");

                //Sending the command
                var messageString = JsonConvert.SerializeObject(Command);
                Message message = new Message(Encoding.ASCII.GetBytes(messageString));

                System.Diagnostics.Debug.WriteLine("Level 13");

                message.Properties = new Properties();
                    message.Properties.To = to;
                    message.Properties.MessageId = Guid.NewGuid().ToString();
                    message.ApplicationProperties = new ApplicationProperties();
                    message.ApplicationProperties["iothub-ack"] = "full";
                System.Diagnostics.Debug.WriteLine("Level 14");

                senderLink.Send(message); System.Diagnostics.Debug.WriteLine("Level 15");

                senderLink.Close(); System.Diagnostics.Debug.WriteLine("Level 16");

            }
            System.Diagnostics.Debug.WriteLine("Level 17");

            session.Close(); System.Diagnostics.Debug.WriteLine("Level 18");

            connection.Close(); System.Diagnostics.Debug.WriteLine("Level 19");

        }
        public CommandDatapoint Command { get; set; }
        #region MyRegion

        static private bool PutCbsToken(Connection connection, string host, string shareAccessSignature,
                string audience)
            {
            System.Diagnostics.Debug.WriteLine("Level 8A");

            bool result = true;
                Session session = new Session(connection);
            System.Diagnostics.Debug.WriteLine("Level 8B");

            string cbsReplyToAddress = "cbs-reply-to";
            SenderLink cbsSender = new SenderLink(session, "cbs-sender", "$cbs");
            System.Diagnostics.Debug.WriteLine("Level 8C");

            var cbsReceiver = new ReceiverLink(session, cbsReplyToAddress, "$cbs");
            System.Diagnostics.Debug.WriteLine("Level 8D");

            // construct the put-token message
            var request = new Message(shareAccessSignature);
            System.Diagnostics.Debug.WriteLine("Level 8E");

            request.Properties = new Properties();
            System.Diagnostics.Debug.WriteLine("Level 8F");

            request.Properties.MessageId = Guid.NewGuid().ToString();
                request.Properties.ReplyTo = cbsReplyToAddress;
                request.ApplicationProperties = new ApplicationProperties();
                request.ApplicationProperties["operation"] = "put-token";
                request.ApplicationProperties["type"] = "azure-devices.net:sastoken";
                request.ApplicationProperties["name"] = audience;

            System.Diagnostics.Debug.WriteLine("Level 8G");

            cbsSender.Send(request);
            System.Diagnostics.Debug.WriteLine("Level 8H");

            // receive the response
            var response = cbsReceiver.Receive();
            System.Diagnostics.Debug.WriteLine("Level 8I");

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
            System.Diagnostics.Debug.WriteLine("Level 8J");

            // the sender/receiver may be kept open for refreshing tokens
            cbsSender.Close();
            System.Diagnostics.Debug.WriteLine("Level 8K");

            cbsReceiver.Close();
            System.Diagnostics.Debug.WriteLine("Level 8L");

            session.Close();
            System.Diagnostics.Debug.WriteLine("Level 8M");

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
        #endregion
    }
}
