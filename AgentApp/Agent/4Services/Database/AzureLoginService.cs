using System;
using Microsoft.WindowsAzure.MobileServices;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace RAT.ZTry
{
    public class AzureLoginService
    {
        public AzureLoginService()
        {
            //Create our client
            Client = new MobileServiceClient("http://zmtool.azurewebsites.net/");
            //Client.CurrentUser.UserId = "Zamir@managmentdatabase";
        }
        private MobileServiceClient Client { get; set; } = null;
        private List<Login> loginObjects = null;

        public async Task<List<Login>> GetLogin(string a, string b)
        {
            System.Diagnostics.Debug.WriteLine("\n-----5Accessing Database.");
            loginObjects = await Client.
                GetTable<Login>().
                Where(r => r.Username == a).
                Where(r => r.Password == b).
                ToListAsync();
            System.Diagnostics.Debug.WriteLine("\n-----6Accessing Database." +loginObjects[0].Password);
            loginObjects.Add(new Login() {Id = "Empty", Password = "Empty", Username = "Empty" });
            //Client.Dispose();
            return loginObjects;
        }
    }
}

