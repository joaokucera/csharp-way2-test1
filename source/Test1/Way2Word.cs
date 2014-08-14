using System.Collections.Specialized;
using System.IO;
using System.Net;

namespace Test1
{
    public class Way2Word : IWay2Word
    {
        private readonly char[] Alphabet = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };

        public int Call(string word, out int numberOfDeadKittens)
        {
            numberOfDeadKittens = 0;
            int position = 0;

            while (true)
            {
                string requestUriString = string.Concat(Config.Way2WordUri, position);

                HttpWebRequest request = WebRequest.Create(requestUriString) as HttpWebRequest;

                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    numberOfDeadKittens++;
                    position++;

                    StreamReader reader = new StreamReader(response.GetResponseStream());
                    string output = reader.ReadToEnd();

                    if (word == output)
                    {
                        break;
                    }

                    EvaluateWord(word[0], ref position);
                }
            }

            return position;
        }

        private void EvaluateWord(char letter, ref int position)
        {
            for (int i = 0; i < Alphabet.Length; i++)
            {
                if ((int)letter >= (int)Alphabet[i])
                {
                    position += 500;
                }
                else if ((int)letter <= (int)Alphabet[i])
                {
                    if (position <= 500)
                    {
                        break;
                    }

                    position -= 500;
                }
            }
        }
    }
}
