using System;
using RestSharp;

namespace CaclulatorRestClient
{
    class RestClientMain
    {
        static void Main()
        {

            var client = new RestClient("http://localhost:49965/");
            var request = new RestRequest("api/points/distance?startX=5&startY=5&endX=10&endY=10");
            var response = client.Execute(request);
            Console.WriteLine(response.Content);
        }
    }
}
