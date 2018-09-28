using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Collections.Specialized;

namespace Assignment_AVIVA.Helper
{
    public class GoogleSearchEngineHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="keywordString">Keyword to be searched.</param>
        /// <returns>response HTML page.</returns>
        public string getSearchResult(string keywordString)
        {
            try
            {
                string uriString = "http://www.google.com/search";

                WebClient webClient = new WebClient();

                NameValueCollection nameValueCollection = new NameValueCollection();
                nameValueCollection.Add("q", keywordString);

                webClient.QueryString.Add(nameValueCollection);
                return webClient.DownloadString(uriString);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

    }
}
