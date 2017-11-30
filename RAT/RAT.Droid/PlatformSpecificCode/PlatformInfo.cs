using System;
using Android.OS;

namespace PlatInfoSap2
{
    public class PlatformInfo
    {
        public string GetModel()
        {
            int a = Android.OS.Process.MyTid();


            return String.Format("{0} {1}", Build.Brand,
                a);
        }

        public string GetVersion()
        {
            return Build.VERSION.Release.ToString();
        }
    }
}