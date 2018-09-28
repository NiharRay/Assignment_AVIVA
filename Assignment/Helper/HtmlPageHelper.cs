using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using System.IO;

namespace Assignment.Helper
{
    public class HtmlPageHelper
    {
        /// <summary>
        /// Find the result url of the given sequence number.
        /// </summary>
        /// <param name="sequenceNo">result sequence</param>
        /// <param name="responseHtml"></param>
        /// <returns>returne the url string</returns>
        public string findSequencesResult(int sequenceNo, string responseHtml)
        {
            try
            {
                HtmlDocument document = new HtmlDocument();
                document.Load(new MemoryStream(Encoding.UTF8.GetBytes(responseHtml)));
                string xPathVal = "//*[@id=\"ires\"]/ol/div[" + sequenceNo + "]";
                HtmlNode node = document.DocumentNode.SelectNodes(xPathVal)[0];
                
                if (node.SelectNodes(".//cite")!=null && node.SelectNodes(".//cite").Count > 0 && node.SelectNodes(".//cite")[0].InnerText.StartsWith("http"))
                {
                    return node.SelectNodes(".//cite")[0].InnerText;
                }
                else
                {
                    return findSequencesResult(sequenceNo + 1, responseHtml);
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
