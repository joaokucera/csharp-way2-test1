using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net;

namespace Test1
{
    public class Way2Word : IWay2Word
    {
        private readonly char[] alphabet = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
        private readonly IDictionary<char, int> dictionary;

        public Way2Word()
        {
            dictionary = new Dictionary<char, int>();
            for (int i = 0; i < alphabet.Length; i++)
            {
                dictionary.Add(alphabet[i], i);
            }
        }

        public int Call(string word, out int numberOfDeadKittens)
        {
            numberOfDeadKittens = 0;
            int position = 0;
            EvaluateWord(word[0], ref position);

            while (true)
            {
                string requestUriString = string.Concat(Config.Way2WordUri, position);

                try
                {
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
                    }
                }
                catch
                {
                    throw;
                }
            }

            return position;
        }

        private void EvaluateWord(char letter, ref int position)
        {
            int value;
            if (dictionary.TryGetValue(letter, out value))
            {
                position = value * 1500;
            }
        }
    }
}
