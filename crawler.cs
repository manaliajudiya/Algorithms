using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Xml;
using System.Text.RegularExpressions;
using System.Linq;

namespace ConsoleAppCore
{
    class crawler
    {
        int defaultCount = 10;

        public async Task CrawlAsync()
        {
            var url = "https://en.wikipedia.org/wiki/Microsoft";

            var client = new HttpClient();

            var html = await client.GetStringAsync(url);

            //Filter words from History
            var historyStart = html.IndexOf("id=\"History\"");
            var historyEnd = html.IndexOf("id=\"Corporate_affairs\"");

            int length = historyEnd - historyStart + 1;
            string history = html.Substring(historyStart, length);
                        
            Dictionary<string, int> hash = new Dictionary<string, int>();

            Regex regex = new Regex("(<.*?>\\s*)+", RegexOptions.Singleline);
            string resultText = regex.Replace(history, " ").Trim();
            
            var words = resultText.Split(); 
            foreach (var w in words)
            {
                if(w.Where(c => char.IsPunctuation(c)).Any() || w.Length < 1){          //Remove words with punctuations
                    continue;
                }

                if (hash.ContainsKey(w))                                                //Word exists in the dictionary
                {
                    hash[w] += 1;                                                       //Increase count
                }
                else
                {
                    hash.Add(w, 1);                                                     //Add a new word in dictionary
                }
            }
            
            int i = 0;
            foreach(var word in hash.OrderByDescending(x => x.Value))
            {
                if(i >= defaultCount) { break; }
                Console.WriteLine(word);
                i++;
            }
        } 

        
    }
}
