using PumpClient.PumpServiceReference;
using System;
using System.ServiceModel;

namespace PumpClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var instanceContext = new InstanceContext(new CallbackHandler());
            var client = new PumpnServiceClient(instanceContext);

            client.UpdateAndCompileScript(@"C:\scripts\Sample.script");
            client.RunScript();

            Console.WriteLine("Please, Enter to exit ...");
            Console.ReadKey(true);
            client.Close();
        }
    }
}
