using System;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.Sync;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using System.Diagnostics;
using Xamarin.Forms;
using System.IO;
using RAT.ZTry;

[assembly: Dependency(typeof(AzureLoginService))]
namespace RAT.ZTry
{
    public class AzureLoginService
    {
        private MobileServiceClient Client { get; set; } = null;
        private List<Login> loginObjects = null;

        public AzureLoginService()
        {
            //Create our client
            Client = new MobileServiceClient("http://zmtool.azurewebsites.net/");

            
        }
        public async Task<List<Login>> GetLogin(string a, string b)
        {
            System.Diagnostics.Debug.WriteLine("\n-----Checkin database " );
            loginObjects = await Client.
                GetTable<Login>().
                Where(r => r.Username == a).
                Where(r => r.Password == b).
                ToListAsync();
            loginObjects.Add(new Login() {Password = "Empty", Username = "Empty" });
            //Client.Dispose();
            System.Diagnostics.Debug.WriteLine("\n-----E1 is"+ loginObjects[0].Username);
            return loginObjects;
        }
    }
    public class TodoItem
    {
        public string Id { get; set; }
        public string Text { get; set; }
    }
}

