using System;
using System.Collections.Generic;
using System.IO;

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
            FileHandler fileHandler = new FileHandler("C:/CaesarTest");
            Caesar caesar = new Caesar();
            
            //---Encryption and Decryption sample-----------------------------------------------------------------
            string testInput = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.";
            string encrypted = 
                caesar.CaesarCrypt(
                    testInput,
                    CaesarCharset.GermanKeyboard,
                    CaesarAction.Encrypt);
            string decrypted =
                caesar.CaesarCrypt(
                    encrypted,
                    CaesarCharset.GermanKeyboard,
                    CaesarAction.Decrypt);

            Console.WriteLine(
                $"\n{(char)32}\u001b[33m{(char)32}{(char)32}{(char)32}{(char)32}Input:{(char)32}\"{testInput}\"\u001b[0m\n" +
                $"{(char)32}\u001b[36mEncrypted:{(char)32}\"{encrypted}\"\u001b[0m\n" +
                $"{(char)32}\u001b[32mDecrypted:{(char)32}\"{ decrypted}\u001b[0m\n");
            //----------------------------------------------------------------------------------------------------

            //---Text file Encryption sample----------------------------------------------------------------------
            List<FileInfo> filesToEncrypt = fileHandler.ReadAllTextFiles();
            int failCounter = 0;
            Console.WriteLine($"{filesToEncrypt.Count} Text files where found.");
            for (int i = 0; i < filesToEncrypt.Count; i++)
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"\nEncrypting file \"{filesToEncrypt[i].FullName}\".\nContent:\n");

                    string fileContent = File.ReadAllText(filesToEncrypt[i].FullName);

                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.Cyan;
                    Console.WriteLine(fileContent);
                    Console.ResetColor();

                    string fileEncrypted =
                        caesar.CaesarCrypt(
                            File.ReadAllText(filesToEncrypt[i].FullName), 
                            CaesarCharset.GermanKeyboard, 
                            CaesarAction.Encrypt);

                    bool success = 
                        fileHandler.WriteContentToFile(
                            filesToEncrypt[i].FullName + ".caesar", 
                            fileEncrypted);
                    if (!success)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"\nFail to encrypt file {filesToEncrypt[i].FullName}.");
                        failCounter++;
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\nDONE");
                        Console.ResetColor();
                    }
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Fail to encrypt file {filesToEncrypt[i].FullName}.");
                    failCounter++;
                    Console.ResetColor();
                }
            }
            Console.WriteLine($"\n{filesToEncrypt.Count - failCounter} of {filesToEncrypt.Count} files encrypted.");

            //----------------------------------------------------------------------------------------------------
        }
    }
}
