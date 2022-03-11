using System;

namespace Caesar
{
    class Program
    {
        static void Main(string[] args)
        {
            new Program().Run();
        }

        public void Run()
        {
            Caesar caesar = new Caesar();

            string userInput = ReadUserInput();

            if(userInput != null)
            {
                string encrypted =
                caesar.CaesarCrypt(
                    userInput,
                    CaesarCharset.GermanKeyboard,
                    CaesarAction.Encrypt);
                string decrypted =
                    caesar.CaesarCrypt(
                        encrypted,
                        CaesarCharset.GermanKeyboard,
                        CaesarAction.Decrypt);

                Console.WriteLine(
                    $"\n{(char)32}\u001b[33m{(char)32}{(char)32}{(char)32}{(char)32}Input:{(char)32}\"{userInput}\"\u001b[0m\n" +
                    $"{(char)32}\u001b[36mEncrypted:{(char)32}\"{encrypted}\"\u001b[0m\n" +
                    $"{(char)32}\u001b[32mDecrypted:{(char)32}\"{ decrypted}\u001b[0m\n");
            }
        }

        private string ReadUserInput()
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write($"\n{(char)32}Please input your text: ");
                Console.ResetColor();
                string userInput = Console.ReadLine();
                Console.Write("\n");
                return userInput;
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\n{(char)32}An error occurred while reading the input!\n");
                Console.ResetColor();
                return null;
            }
        }
    }
}
