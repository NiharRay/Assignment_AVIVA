using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Helper
{
    public class Validation
    {
        /// <summary>
        /// Validates whether keyword is valid or not.
        /// </summary>
        /// <param name="keyword">String provided to be searched.</param>
        /// <returns></returns>
        public string ValidateSearchKeyword(string keyword)
        {
            if(String.IsNullOrEmpty(keyword))
            {
                return "Keyword you provided can't be null or empty.";
            }
            else if (String.IsNullOrWhiteSpace(keyword))
            {
                return "Keyword you provided can't be null or white.";
            }
            return "0";
        }

        /// <summary>
        /// Validates whether sequence number is valid or not.
        /// </summary>
        /// <param name="sequenceNo">Result sequence number</param>
        /// <returns></returns>
        public string ValidateSequenceNo(int sequenceNo)
        {
            if(sequenceNo<=0)
            {
                return "Sequence number can't be less then and equal to ZERO.";
            }
            return "0";
        }
    }
}
