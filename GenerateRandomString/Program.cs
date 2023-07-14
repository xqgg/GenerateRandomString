using System.Text;

internal class Program
{

    private static void Main(string[] args)
    {
        string input;
        do
        {
            int length;
            bool isValidLength;
            do
            {
                Console.Write("Enter the length of the random string (max 32): ");
                isValidLength = int.TryParse(Console.ReadLine(), out length) && length <= 32;
            } while (!isValidLength);

            Console.Write("Include lowercase letters? (y/n, default y): ");
            input = Console.ReadLine();
            bool includeLowercase = string.IsNullOrEmpty(input) || input.ToLower() == "y";

            Console.Write("Include uppercase letters? (y/n, default y): ");
            input = Console.ReadLine();
            bool includeUppercase = string.IsNullOrEmpty(input) || input.ToLower() == "y";

            Console.Write("Include numbers? (y/n, default y): ");
            input = Console.ReadLine();
            bool includeNumbers = string.IsNullOrEmpty(input) || input.ToLower() == "y";

            Console.Write("Include special characters? (y/n, default y): ");
            input = Console.ReadLine();
            bool includeSpecial = string.IsNullOrEmpty(input) || input.ToLower() == "y";

            string randomString = GenerateRandomString(length, includeLowercase, includeUppercase, includeNumbers, includeSpecial);
            Console.WriteLine("Random string: " + randomString);

            Console.Write("Press Enter to exit or 'r' to restart: ");
            input = Console.ReadLine();
        } while (input.ToLower() == "r");

    }






    public static string GenerateRandomString(int length, bool includeLowercase, bool includeUppercase, bool includeNumbers, bool includeSpecial)
    {
        const string lowercase = "abcdefghijkmnpqrstuvwxyz";
        const string uppercase = "ABCDEFGHJKLMNPQRSTUVWXYZ";
        const string numbers = "123456789";
        const string special = "!#$%&()*+,-./:;<=>?@[]^_`{|}~";

        var charPool = new StringBuilder();
        if (includeLowercase) charPool.Append(lowercase);
        if (includeUppercase) charPool.Append(uppercase);
        if (includeNumbers) charPool.Append(numbers);
        if (includeSpecial) charPool.Append(special);

        var chars = charPool.ToString().ToCharArray();
        var result = new StringBuilder();
        var rng = new Random();

        for (int i = 0; i < length; i++)
        {
            int index = rng.Next(chars.Length);
            result.Append(chars[index]);
        }

        return result.ToString();
    }


}