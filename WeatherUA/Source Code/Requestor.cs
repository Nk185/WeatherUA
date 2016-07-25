/*
 * Application:    WeatherUA
 * Solution:       WeatherUA
 * Copyright:      Nk185
 * Code copyright: Nk185
 * File version:   1.4.4.0 
 * Used external packages: 
 *      Galasoft - MVVM;
 *      Newtonsoft - JSON;
 */

using System.Net.Http;
using System.Threading.Tasks;


namespace WeatherUA.Source_Code
{
    /// <summary>
    /// Creates and sends requests to the weather
    /// server.
    /// Use 'getData'to get data from server. 
    /// </summary>
    class Requestor
    {
        public string CurrentWeatherJson { get; private set; }
        public string ForecastJson { get; private set; }

        public string AstronomyJson { get; private set; }

        public async Task GetData(string city)
        {
            string resCur   = "Error";
            string resForec = "Error";
            string resAstr  = "Error";

            HttpClient client = new HttpClient();
            HttpContent content;

            HttpResponseMessage response = await client.GetAsync("http://api.wunderground.com/api/faf69394af3f9e9b/conditions/q/UA/" + city + ".json");

            if (response.IsSuccessStatusCode)
            {
                content = response.Content;
                resCur = content.ReadAsStringAsync().Result;
            }

            response = await client.GetAsync("http://api.wunderground.com/api/faf69394af3f9e9b/forecast10day/q/UA/" + city + ".json");

            if (response.IsSuccessStatusCode)
            {
                content = response.Content;
                resForec = content.ReadAsStringAsync().Result;
            }

            response = await client.GetAsync("http://api.wunderground.com/api/faf69394af3f9e9b/astronomy/q/UA/" + city + ".json");

            if (response.IsSuccessStatusCode)
            {
                content = response.Content;
                resAstr = content.ReadAsStringAsync().Result;
            }

            CurrentWeatherJson = resCur;
            ForecastJson       = resForec;
            AstronomyJson      = resAstr;

            client.Dispose();
        }
    }
}
