/*
 * Application:    WeatherUA
 * Solution:       WeatherUA
 * Copyright:      Nk185
 * Code copyright: Nk185
 * File version:   1.4.2.0
 * Used external packages: 
 *      Galasoft - MVVM;
 *      Newtonsoft - JSON;
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft;
using Newtonsoft.Json;

namespace WeatherUA.Source_Code
{
    /// <summary>
    /// Extracts weather information from json response, represented as string
    /// </summary>
    class JsonParser
    {
        /// <summary>
        /// Json response to process.
        /// </summary>
        private string JsonResponse { get; set; }
        
        /// <summary>
        /// Creates new instance of JsonParser.
        /// </summary>
        /// <param name="jsonResponse">Response in json format</param>
        public JsonParser(string jsonResponse)
        {
            this.JsonResponse = jsonResponse;
        }
        /// <summary>
        /// Resets passed json response.
        /// In case if there is no need to create new instance, you can replace json as soon 
        /// as methods in this class processes response from current inner variable
        /// </summary>
        public string EnterNewResponse { set { this.JsonResponse = value; } }

        /// <summary>
        /// Extracts info about current weather status.
        /// </summary>
        /// <param name="weatherStatus">Out parameter. WeatherStat with current weather status</param>
        /// <returns>Are data was successfully parsed.</returns>               
        public bool ParseWeatherStat(out WeatherStat weatherStatus)
        {
            WeatherStat ws = new WeatherStat();
            bool isSuccess = false;

            try
            {
                dynamic deserializedData = JsonConvert.DeserializeObject<dynamic>(this.JsonResponse);

                ws.SkyStat       = (string)deserializedData.current_observation.weather; // in response - string
                ws.TemperatureC  = (int)deserializedData.current_observation.temp_c; // in response - double
                ws.TemperatureF  = (int)deserializedData.current_observation.temp_f; // in response - double
                ws.FeelsLikeC    = Convert.ToInt32((double)deserializedData.current_observation.feelslike_c); // in response - string with double value
                ws.FeelsLikeF    = Convert.ToInt32((double)deserializedData.current_observation.feelslike_f); // in response - string with double value
                ws.WindSpeedKph  = (uint)deserializedData.current_observation.wind_kph; // in response - double
                ws.WindSpeedMph  = (uint)deserializedData.current_observation.wind_mph; // in response - double
                ws.WindDirection = (string)deserializedData.current_observation.wind_dir; // in response - string

                isSuccess = true;
            }
            catch // In case of if response pattern was changed by wunderground.com
            {
                ws.SkyStat       = ws.SkyStat == "N/A" ? "N/A" : ws.SkyStat;
                ws.TemperatureC  = ws.TemperatureC == 0 ? 0 : ws.TemperatureC;
                ws.TemperatureF  = ws.TemperatureF == 0 ? 0 : ws.TemperatureF;
                ws.FeelsLikeC    = ws.FeelsLikeC == 0 ? 0 : ws.FeelsLikeC;
                ws.FeelsLikeF    = ws.FeelsLikeF == 0 ? 0 : ws.FeelsLikeF;
                ws.WindSpeedKph  = ws.WindSpeedKph == 0 ? 0 : ws.WindSpeedKph;
                ws.WindSpeedMph  = ws.WindSpeedMph == 0 ? 0 : ws.WindSpeedMph;
                ws.WindDirection = "N/A";

                isSuccess = false;
            }

            weatherStatus = ws;
            return isSuccess;
        }

        /// <summary>
        /// Extracts info about forecast for 10 days.
        /// </summary>
        /// <param name="weatherForecast">Out parameter. 10-elements list of WeatherStatForecast with forecast info.</param>
        /// <returns>Are data was successfully parsed.</returns>
        public bool ParseWeatherForec(out List<WeatherStatForecast> weatherForecast)
        {
            WeatherStatForecast[] ws = new WeatherStatForecast[10];
            dynamic deserializedData = JsonConvert.DeserializeObject<dynamic>(this.JsonResponse);
            bool isSuccess = true; 

            for (int i = 0; i < 10; i++)
            {
                ws[i] = new WeatherStatForecast();

                try
                {
                    ws[i].Day         = (uint)deserializedData.forecast.simpleforecast.forecastday[i].date.day; // in response - integer
                    ws[i].WeekdayShrt = (string)deserializedData.forecast.simpleforecast.forecastday[i].date.weekday_short; // in response - string

                    ws[i].SkyStat = (string)deserializedData.forecast.simpleforecast.forecastday[i].conditions; // in response - string

                    ws[i].TemperatureCH = Convert.ToInt32((string)deserializedData.forecast.simpleforecast.forecastday[i].high.celsius); // in response - string
                    ws[i].TemperatureFH = Convert.ToInt32((string)deserializedData.forecast.simpleforecast.forecastday[i].high.fahrenheit); // in response - string
                    ws[i].TemperatureCL = Convert.ToInt32((string)deserializedData.forecast.simpleforecast.forecastday[i].low.celsius); // in response - string
                    ws[i].TemperatureFL = Convert.ToInt32((string)deserializedData.forecast.simpleforecast.forecastday[i].low.fahrenheit); // in response - string

                    ws[i].WindSpeedKph  = (uint)deserializedData.forecast.simpleforecast.forecastday[i].avewind.kph; // in response - integer
                    ws[i].WindSpeedMph  = (uint)deserializedData.forecast.simpleforecast.forecastday[i].avewind.mph; // in response - integer
                    ws[i].WindDirection = (string)deserializedData.forecast.simpleforecast.forecastday[i].avewind.dir; // in response - string
                }
                catch // In case of if response pattern was changed by wunderground.com
                {
                    ws[i].Day         = 0;
                    ws[i].WeekdayShrt = "Mo";

                    ws[i].SkyStat = "N/A";

                    ws[i].TemperatureCH = 0;
                    ws[i].TemperatureCL = 0;
                    ws[i].TemperatureFH = 0;
                    ws[i].TemperatureFL = 0;

                    ws[i].WindSpeedKph  = 0;
                    ws[i].WindSpeedMph  = 0;
                    ws[i].WindDirection = "N/A";

                    isSuccess = false; // If even only one day was with error, whole forecast assumes as invalid.
                }
            }

            weatherForecast = ws.ToList();
            return isSuccess;
        }
    }
}