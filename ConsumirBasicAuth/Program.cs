using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsumirBasicAuth
{
    class Program
    {
        static void Main(string[] args)
        {
            Task t = new Task(HTTP_Basic_Authentication);
            t.Start();
            Console.ReadLine();
        }

        static async void HTTP_Basic_Authentication()
        {
            var TARGETURL = "https://localhost:44340/WeatherForecast";

            Console.WriteLine("GET: + " + TARGETURL);

            HttpClient client = new HttpClient();
            var byteArray = Encoding.ASCII.GetBytes("admin:@Lola");
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

            HttpResponseMessage response = await client.GetAsync(TARGETURL);
            HttpContent content = response.Content;

            Console.WriteLine("Response Status Code: " + (int)response.StatusCode);
            string result = await content.ReadAsStringAsync();
            if (result != null && result.Length >= 0)
            {
                Console.WriteLine("Result:\n" + result);
            }
        }
    }
}
