using System;
using System.Net;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using RestSharp.Deserializers;
using RestSharp.Serialization.Json;


namespace WooliesUI.Tests
{
    [TestFixture]
    public class APITests
    {
        IRestResponse restResponse = null;

        [OneTimeSetUp]
        public void SetUp()
        {
            //Creating Client connection
            RestClient restClient = new RestClient("http://restapi.demoqa.com/utilities/weather/city/");
            //Creating request to get data from server
            RestRequest restRequest = new RestRequest("Sydney", Method.GET);

            // Executing request to server and checking server response to the it
            restResponse = restClient.Execute(restRequest);
        }


        [Test, Description("Check that the API status is OK")]
        public void StatusOKTest()
        {
            Assert.That(restResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test, Description("Check that the API content is in valid  JSON")]
        public void ContentTypeTest()
        {
            //Assert the API response is valid JSON
            Assert.That(restResponse.ContentType, Is.EqualTo("application/json"));
        }

        [Test, Description("Check that the weather in Sydney is greater than 10 degrees")]
        public void SydneyWeatherTest()
        {
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

        [Test, Description("Check that Sydney is the city in the response request")]
        public void SydneyIsCity()
        {
            var obj = JsonConvert.DeserializeObject<dynamic>(restResponse.Content);

            Assert.That(obj.City.ToString(), Is.EqualTo("Sydney"));
        }
    }
}
