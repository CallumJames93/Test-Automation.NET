using System;
using System.Net;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;

namespace WooliesUI.Tests
{
    public class APITests
    {
        [Test, Description("Check that the API status is OK")]
        public void StatusOKTest()
        {
            //Creating Client connection
            RestClient restClient = new RestClient("http://restapi.demoqa.com/utilities/weather/city/");
            //Creating request to get data from server
            RestRequest restRequest = new RestRequest("Sydney", Method.GET);

            // Executing request to server and checking server response to the it
            IRestResponse restResponse = restClient.Execute(restRequest);

            //Assert the API response is valid JSON
            Assert.That(restResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test, Description("Check that the API content is in valid  JSON")]
        public void ContentTypeTest()
        {
            //Creating Client connection
            RestClient restClient = new RestClient("http://restapi.demoqa.com/utilities/weather/city/");
            //Creating request to get data from server
            RestRequest restRequest = new RestRequest("Sydney", Method.GET);

            // Executing request to server and checking server response to the it
            IRestResponse restResponse = restClient.Execute(restRequest);

            //Assert the API response is valid JSON
            Assert.That(restResponse.ContentType, Is.EqualTo("application/json"));
        }

        [Test, Description("Check that the weather in Sydney is greater than 10 degrees")]
        public void SydneyWeatherTest()
        {
            //Creating Client connection 
            RestClient restClient = new RestClient("http://restapi.demoqa.com/utilities/weather/city/");

            //Creating request to get data from server
            RestRequest restRequest = new RestRequest("Sydney", Method.GET);

            // Executing request to server and checking server response to the it
            IRestResponse restResponse = restClient.Execute(restRequest);

            var obj = JsonConvert.DeserializeObject<dynamic>(restResponse.Content);
            //int temp = (int)obj.Temperature;
            string tempMsg = (string)obj.Temperature;
            string temp = tempMsg.Remove(14);

            var actualTemp = Int16.Parse(temp);

            if (actualTemp >10)
            {
                Assert.Pass("The weather in Sydney is hotter than 10 degrees");
            }
            
        }
    }
}
