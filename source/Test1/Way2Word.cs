using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Test1
{
    public class Way2Word : IWay2Word
    {
        public void Call(int position)
        {
            string requestUriString = string.Concat(Config.Way2WordUri, position);

            HttpWebRequest request = WebRequest.Create(requestUriString) as HttpWebRequest;

            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                StreamReader reader = new StreamReader(response.GetResponseStream());

                Console.WriteLine(reader.ReadToEnd());
            }
        }
    }
}
