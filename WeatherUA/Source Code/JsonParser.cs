/*
 * Application:    WeatherUA
 * Solution:       WeatherUA
 * Copyright:      Nk185
 * Code copyright: Nk185
 * File version:   1.4.1.2
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
        private string _jsonResponse { get; set; }
        
        /// <summary>
        /// Creates new instance of JsonParser.
        /// </summary>
        /// <param name="jsonResponse">Response in json format</param>
        public JsonParser(string jsonResponse)
        {
            this._jsonResponse = jsonResponse;
        }
        /// <summary>
        /// Resets passed json response.
        /// In case if there is no need to create new instance, you can replace json as soon 
        /// as methods in this class processes response from current inner variable
        /// </summary>
        public string EnterNewResponse { set { this._jsonResponse = value; } }

        /// <summary>
        /// Extracts info about current weather status.
        /// </summary>
        /// <param name="weatherStatus">Out parameter. WeatherStat with current weather status</param>
        /// <returns>Is data was successfully parsed.</returns>               
        public bool ParseWeatherStat(out WeatherStat weatherStatus)
        {
            WeatherStat ws = new WeatherStat();
            bool isSuccess = false;

            try
            {
                dynamic DeserializedData = JsonConvert.DeserializeObject<dynamic>(this._jsonResponse);

                ws.SkyStat       = (string)DeserializedData.current_observation.weather; // in response - string
                ws.TemperatureC  = (int)DeserializedData.current_observation.temp_c; // in response - double
                ws.TemperatureF  = (int)DeserializedData.current_observation.temp_f; // in response - double
                ws.FeelsLikeC    = Convert.ToInt32((double)DeserializedData.current_observation.feelslike_c); // in response - string with double value
                ws.FeelsLikeF    = Convert.ToInt32((double)DeserializedData.current_observation.feelslike_f); // in response - string with double value
                ws.WindSpeedKPH  = (uint)DeserializedData.current_observation.wind_kph; // in response - double
                ws.WindSpeedMPH  = (uint)DeserializedData.current_observation.wind_mph; // in response - double
                ws.WindDirection = (string)DeserializedData.current_observation.wind_dir; // in response - string

                isSuccess = true;
            }
            catch // In case of if response pattern was changed by wunderground.com
            {
                ws.SkyStat       = ws.SkyStat == "N/A" ? "N/A" : ws.SkyStat;
                ws.TemperatureC  = ws.TemperatureC == 0 ? 0 : ws.TemperatureC;
                ws.TemperatureF  = ws.TemperatureF == 0 ? 0 : ws.TemperatureF;
                ws.FeelsLikeC    = ws.FeelsLikeC == 0 ? 0 : ws.FeelsLikeC;
                ws.FeelsLikeF    = ws.FeelsLikeF == 0 ? 0 : ws.FeelsLikeF;
                ws.WindSpeedKPH  = ws.WindSpeedKPH == 0 ? 0 : ws.WindSpeedKPH;
                ws.WindSpeedMPH  = ws.WindSpeedMPH == 0 ? 0 : ws.WindSpeedMPH;
                ws.WindDirection = "N/A";

                isSuccess = false;
            }

            weatherStatus = ws;
            return isSuccess;
        }

        /// <summary>
        /// Extracts info about forecast for 10 days.
        /// </summary>
        /// <param name="weatherForecast">Out parameter. 10-elements array of WeatherStatForecast with forecast info.</param>
        /// <returns>Is data was successfully parsed.</returns>
        public bool ParseWeatherForec(out WeatherStatForecast[] weatherForecast)
        {
            WeatherStatForecast[] ws = new WeatherStatForecast[10];
            dynamic DeserializedData = JsonConvert.DeserializeObject<dynamic>(this._jsonResponse);
            bool isSuccess = true; 

            for (int i = 0; i < 10; i++)
            {
                ws[i] = new WeatherStatForecast();

                try
                {
                    ws[i].Day         = (uint)DeserializedData.forecast.simpleforecast.forecastday[i].date.day; // in response - integer
                    ws[i].WeekdayShrt = (string)DeserializedData.forecast.simpleforecast.forecastday[i].date.weekday_short; // in response - string

                    ws[i].SkyStat = (string)DeserializedData.forecast.simpleforecast.forecastday[i].conditions; // in response - string

                    ws[i].TemperatureC_H = Convert.ToInt32((string)DeserializedData.forecast.simpleforecast.forecastday[i].high.celsius); // in response - string
                    ws[i].TemperatureF_H = Convert.ToInt32((string)DeserializedData.forecast.simpleforecast.forecastday[i].high.fahrenheit); // in response - string
                    ws[i].TemperatureC_L = Convert.ToInt32((string)DeserializedData.forecast.simpleforecast.forecastday[i].low.celsius); // in response - string
                    ws[i].TemperatureF_L = Convert.ToInt32((string)DeserializedData.forecast.simpleforecast.forecastday[i].low.fahrenheit); // in response - string

                    ws[i].WindSpeedKPH  = (uint)DeserializedData.forecast.simpleforecast.forecastday[i].avewind.kph; // in response - integer
                    ws[i].WindSpeedMPH  = (uint)DeserializedData.forecast.simpleforecast.forecastday[i].avewind.mph; // in response - integer
                    ws[i].WindDirection = (string)DeserializedData.forecast.simpleforecast.forecastday[i].avewind.dir; // in response - string
                }
                catch // In case of if response pattern was changed by wunderground.com
                {
                    ws[i].Day         = 0;
                    ws[i].WeekdayShrt = "Mo";

                    ws[i].SkyStat = "N/A";

                    ws[i].TemperatureC_H = 0;
                    ws[i].TemperatureC_L = 0;
                    ws[i].TemperatureF_H = 0;
                    ws[i].TemperatureF_L = 0;

                    ws[i].WindSpeedKPH  = 0;
                    ws[i].WindSpeedMPH  = 0;
                    ws[i].WindDirection = "N/A";

                    isSuccess = false; // If even only one day was with error, whole forecast assumes as invalid.
                }
            }

            weatherForecast = ws;
            return isSuccess;
        }
    }
}