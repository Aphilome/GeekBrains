using System;

namespace CertGenerator
{
    public class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("~~ Certification center ~~\n");
                Console.WriteLine("1. Cerate root certificate");
                Console.WriteLine("2. Cerate certificate");
                Console.WriteLine("0. Exit");
                Console.Write("> ");

                if (int.TryParse(Console.ReadLine(),out int no))
                {
                    switch (no)
                    {
                        case 0:
                            Console.WriteLine("Closing application");
                            Console.ReadKey();
                            return;
                        case 1:
                            var certificateConfiguration = new CertificateConfiguration
                            {
                                CertName = "Mad Company CA",
                                OutFolder = @"D:\cert",
                                Password = "12345678",
                                CertDuration = 30
                            };
                            var certificateGenerationProvider = new CertificateGenerationProvider();
                            certificateGenerationProvider.GenerateRootCertificate(certificateConfiguration);
                            Console.WriteLine("Success!");
                            break;
                        case 2:
                            int counter = 0;
                            var certificateExplorerProvider = new CertificateExplorerProvider(true);
                            certificateExplorerProvider.LoadCertificates();
                            foreach (var certificate in certificateExplorerProvider.Certificates)
                            {
                                Console.WriteLine($"{counter++} >>> {certificate}");
                            }
                            Console.Write("Choose number: ");
                            var addCertificateConfiguration = new CertificateConfiguration
                            {
                                RootCertificate = certificateExplorerProvider.Certificates[int.Parse(Console.ReadLine())].Certificate,
                                CertName = "IT Department",
                                OutFolder = @"D:\cert",
                                Password = "12345678",
                            };
                            var certificateGenerationProvider2 = new CertificateGenerationProvider();
                            certificateGenerationProvider2.GenerateCertificate(addCertificateConfiguration);
                            Console.WriteLine("Success!");
                            break;
                        default:
                            Console.WriteLine("Invalid input, please repeat input");
                            break;
                    }
                }
                else
                    Console.WriteLine("Invalid input, please repeat input");
            }
        }
    }
}
