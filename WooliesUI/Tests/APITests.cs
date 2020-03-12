using System;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;

namespace WooliesUI.Tests
{
    public class APITests
    {

        [Test]
        public void APITest()
        {
            //Creating Client connection 
            RestClient restClient = new RestClient("http://restapi.demoqa.com/utilities/weather/city/");

            //Creating request to get data from server
            RestRequest restRequest = new RestRequest("Sydney", Method.GET);

            // Executing request to server and checking server response to the it
            IRestResponse restResponse = restClient.Execute(restRequest);

            var obj = JsonConvert.DeserializeObject<dynamic>(restResponse.Content);
            int temp = (int)obj.Temperature;

            if (temp > 10)
            {
                Assert.Pass("The weather in Sydney is hotter than 10 degrees");
            }
            
        }
    }
}
