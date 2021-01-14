using System;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;

namespace gcTest
{
    class RestShrp
    {
        [Test]
        public void restGetLanguageTest()
        {
            RestClient client = new RestClient("https://greencity.azurewebsites.net/");
            RestRequest request = new RestRequest("/language", Method.GET);
            IRestResponse restResponse = client.Execute(request);
            string responseLanguage = restResponse.Content;
            Assert.IsTrue(responseLanguage.Contains("[\"en\",\"ru\",\"ua\"]"));
        }

        [Test]
        public void restSignInTest()
        {
            JObject jObject = new JObject();
            jObject.Add("email", "xdknxusqvjeovowpfk@awdrt.com");
            jObject.Add("password", "Temp#001");
            RestClient client = new RestClient("https://greencity.azurewebsites.net/");
            RestRequest request = new RestRequest("/ownSecurity/signIn", Method.POST);
            request.AddParameter("application/json", jObject, ParameterType.RequestBody);
            IRestResponse restResponse = client.Execute(request);
            Console.WriteLine(restResponse.Content);
            string content = restResponse.Content;
            Assert.IsTrue(content.Contains("accessToken"));
        }
    }
}
