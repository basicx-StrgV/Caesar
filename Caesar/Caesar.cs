using System.Text;

namespace Caesar
{
    public class Caesar
    {
        public string CaesarCrypt(string input, CaesarCharset charSet, CaesarAction action)
        {
            string currentText = input;
            StringBuilder resultBuilder = new StringBuilder();
            for (int i = 0; i < charSet.RunCount; i++)
            {
                for (int j = 0; j < currentText.Length; j++)
                {
                    int charIndex = charSet.IndexOf(currentText[j]);
                    char resultChar = currentText[j];
                    if (charIndex >= 0)
                    {
                        switch (action)
                        {
                            case CaesarAction.Encrypt:
                                resultChar = charSet[charIndex + charSet.StepValue];
                                break;
                            case CaesarAction.Decrypt:
                                resultChar = charSet[charIndex - charSet.StepValue];
                                break;
                        }
                    }
                    resultBuilder.Append(resultChar);
                }
                currentText = resultBuilder.ToString();
                resultBuilder.Clear();
            }
            return currentText;
        }
    }
}
