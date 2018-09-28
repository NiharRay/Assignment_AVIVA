using System;
using TechTalk.SpecFlow;
using Assignment;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject.StepDef
{
    [Binding]
    public class GoogleSearchFeatureSteps
    {
        SearchGoogle searchgoogle = null;
        string resultURL = "", resposeData = "";
        bool isFiled = false;

        [Given(@"I have google engine configured")]
        public void GivenIHaveGoogleEngineConfigured()
        {
            searchgoogle = new SearchGoogle();
        }
        
        [When(@"I provide (.*) keyword to search")]
        public void WhenIProvideKeywordToSearch(string keyword)
        {
            try
            {
                keyword = keyword.Trim();
                if (keyword == "null")
                {
                    resposeData = searchgoogle.SetKeyword(null);
                }
                else
                {
                    resposeData = searchgoogle.SetKeyword(keyword);
                }
            }
            catch(Exception ex)
            {
                Assert.AreEqual("Keyword you provided can't be null or empty.", ex.Message);
                isFiled = true;
            }
        }
        
        [Then(@"I should get (.*)th result url")]
        public void ThenIShouldGetThResultUrl(int sequenceNo)
        {
            if (!isFiled)
            {
                resultURL = searchgoogle.SetSequenceIndexAndGetResult(sequenceNo, resposeData);
                Console.WriteLine(resultURL);
            }
        }
    }
}
