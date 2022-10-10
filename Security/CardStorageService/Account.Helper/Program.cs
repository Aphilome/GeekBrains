using CardStorageService;

namespace Account.Helper
{
    internal class Program
    {
        // empty PR for 5 lesson
        static void Main(string[] args)
        {
            var res = PasswordUtils.CreatePasswordHash("123");
            Console.ReadKey();
        }
    }
}