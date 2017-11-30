using System;
using System.Collections.Generic;
using System.Text;

namespace RAT.Services.IoT
{
    class Singleton
    {
        private static Singleton instance;

        private Singleton() { }
        int aaa = 7;
        public string[] MyArray { get; set; }

        public static Singleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Singleton();
                }
                return instance;
            }
        }
    }
}
