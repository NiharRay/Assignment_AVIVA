using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Collections.Specialized;
using HtmlAgilityPack;
using Assignment_AVIVA.Helper;

namespace Assignment_AVIVA
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Commented
            //string uriString = "http://www.google.com/search";
            //string keywordString = "docker";

            //WebClient webClient = new WebClient();

            //NameValueCollection nameValueCollection = new NameValueCollection();
            //nameValueCollection.Add("q", keywordString);

            //webClient.QueryString.Add(nameValueCollection);
            //string Text = webClient.DownloadString(uriString);

            /////HTML Agility pack
            //HtmlDocument document = new HtmlDocument();
            //document.Load(new MemoryStream(Encoding.UTF8.GetBytes(Text)));
            //HtmlNode node = document.DocumentNode.SelectNodes("//*[@id=\"ires\"]/ol/div[5]")[0];//.SelectNodes("//a[@href]")[0];//.Split("url?q=".ToCharArray())[1];
            ////var url = node.SelectNodes(".//a[@href]")[0].Attributes["href"].Value.Split(new string[] { "url?q="}, StringSplitOptions.None)[1];
            //var url = node.SelectNodes(".//cite")[0].InnerText;
            //Console.WriteLine(url);
            #endregion

            try
            {
                Console.WriteLine("           ASSIGNMENT           ");
                Console.WriteLine("--------------------------------");
                Console.WriteLine("Please enter the search keyword :- ");
                string keyword = Console.ReadLine();
                ///Validate search keyword
                Validation validator = new Validation();
                string validationSearchResult = validator.ValidateSearchKeyword(keyword);
                while (validationSearchResult != "0")
                {
                    Console.WriteLine(validationSearchResult);
                    Console.WriteLine("-----------------------------------------");
                    Console.WriteLine("Please enter again the search keyword :- ");
                    keyword = Console.ReadLine();
                    validationSearchResult = validator.ValidateSearchKeyword(keyword);
                }

                GoogleSearchEngineHelper googleSearch = new GoogleSearchEngineHelper();
                string resultHTML = googleSearch.getSearchResult(keyword);
                Console.WriteLine("Cheers we got search result for you.");
                Console.WriteLine("------------------------------------");

                Console.WriteLine("Please define which sequence of search result's URL required : -");
                //string sequenceNo = Console.ReadLine();
                int sequenceNo;
                //int.TryParse(Console.ReadLine(), out sequenceNo);
                if (!int.TryParse(Console.ReadLine(), out sequenceNo))
                {
                    throw new Exception("Not a valid sequence");
                }

                ///Validate sequence keyword
                string validationSequenceNumberResult = validator.ValidateSequenceNo(sequenceNo);
                while (validationSequenceNumberResult != "0")
                {
                    Console.WriteLine(validationSequenceNumberResult);
                    Console.WriteLine("----------------------------------------------------------------------");
                    Console.WriteLine("Please define which sequence of search result's URL required again : -");
                    if (!int.TryParse(Console.ReadLine(), out sequenceNo))
                    {
                        throw new Exception("Not a valid sequence");
                    }
                    validationSequenceNumberResult = validator.ValidateSequenceNo(sequenceNo);
                }

                HtmlPageHelper htmlPageManipulation = new HtmlPageHelper();
                string resultURL = htmlPageManipulation.findSequencesResult(sequenceNo, resultHTML);
                Console.WriteLine("Google search result for KEYWORD {0} and SEQUENCE NO. {1} is '{2}'", keyword, sequenceNo, resultURL);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.InnerException);
            }
             Console.ReadKey();
        }
    }
}
