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
        public AzureLoginService()
        {
            //Create our client
            Client = new MobileServiceClient("http://zamirmobileapp.azurewebsites.net");
        }
        private MobileServiceClient Client { get; set; } = null;
        private List<Login> loginObjects = null;

        public async Task<List<Login>> GetLogin(string a, string b)
        {
            loginObjects = await Client.
                GetTable<Login>().
                Where(r => r.Username == a).
                Where(r => r.Password == b).
                ToListAsync();

            Client.Dispose();
            return loginObjects;
        }
    }
}

