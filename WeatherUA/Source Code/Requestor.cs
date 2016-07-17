﻿using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Text;
using System.IO;


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

        public Requestor()
        {
            
        }

        public async Task getData(string city)
        {
            string resCur = "Error";
            string resForec = "Error";

            HttpClient client = new HttpClient();

            HttpResponseMessage response = await client.GetAsync("http://api.wunderground.com/api/faf69394af3f9e9b/conditions/q/UA/" + city + ".json");

            if (response.IsSuccessStatusCode)
            {
                HttpContent content = response.Content;
                resCur = content.ReadAsStringAsync().Result;
            }

            response = await client.GetAsync("http://api.wunderground.com/api/faf69394af3f9e9b/forecast10day/q/UA/" + city + ".json");

            if (response.IsSuccessStatusCode)
            {
                HttpContent content = response.Content;
                resForec = content.ReadAsStringAsync().Result;
            }

            CurrentWeatherJson = resCur;
            ForecastJson = resForec;

            client.Dispose();
        }
    }
}