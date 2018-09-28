using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment.Helper;

namespace Assignment
{
    public class SearchGoogle
    {
        public string ProvideKeyWord(string keyword)
        {
            try
            {
                Validation validator = new Validation();
                string validationSearchResult = validator.ValidateSearchKeyword(keyword);
                if (validationSearchResult != "0")
                {
                    throw new Exception(validationSearchResult);
                }
                GoogleSearchEngineHelper googleSearch = new GoogleSearchEngineHelper();
                string resultHTML = googleSearch.getSearchResult(keyword);

                int sequenceNo;
                if (!int.TryParse(Console.ReadLine(), out sequenceNo))
                {
                    throw new Exception("Not a valid sequence");
                }

                ///Validate sequence keyword
                string validationSequenceNumberResult = validator.ValidateSequenceNo(sequenceNo);
                if (validationSequenceNumberResult != "0")
                {
                    throw new Exception(validationSequenceNumberResult);
                }

                HtmlPageHelper htmlPageManipulation = new HtmlPageHelper();
                string resultURL = htmlPageManipulation.findSequencesResult(sequenceNo, resultHTML);

                return resultURL;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public string SetSequenceIndexAndGetResult(int sequenceNo, string resultHTML)
        {
            try
            {
                ///Validate sequence keyword
                Validation validator = new Validation();
                string validationSequenceNumberResult = validator.ValidateSequenceNo(sequenceNo);
                if (validationSequenceNumberResult != "0")
                {
                    throw new Exception(validationSequenceNumberResult);
                }

                HtmlPageHelper htmlPageManipulation = new HtmlPageHelper();
                string resultURL = htmlPageManipulation.findSequencesResult(sequenceNo, resultHTML);

                return resultURL;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string SetKeyword(string keyword)
        {
            try
            {
                Validation validator = new Validation();
                string validationSearchResult = validator.ValidateSearchKeyword(keyword);
                if (validationSearchResult != "0")
                {
                    throw new Exception(validationSearchResult);
                }
                GoogleSearchEngineHelper googleSearch = new GoogleSearchEngineHelper();
                string resultHTML = googleSearch.getSearchResult(keyword);
                return resultHTML;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
