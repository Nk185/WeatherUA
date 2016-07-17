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

                ws.SkyStat = DeserializedData.current_observation.weather;
                ws.TemperatureC = DeserializedData.current_observation.temp_c;
                ws.TemperatureF = DeserializedData.current_observation.temp_f;
                ws.FeelsLikeC = DeserializedData.current_observation.feelslike_c;
                ws.FeelsLikeF = DeserializedData.current_observation.feelslike_f;
                ws.WindSpeedKPH = DeserializedData.current_observation.wind_kph;
                ws.WindSpeedMPH = DeserializedData.current_observation.wind_mph;
                ws.WindDirection = DeserializedData.current_observation.wind_dir;

                isSuccess = true;
            }
            catch // In case of if response pattern was changed by wunderground.com
            {
                ws.SkyStat = "N/A";
                ws.TemperatureC = 0;
                ws.TemperatureF = 0;
                ws.FeelsLikeC = 0;
                ws.FeelsLikeF = 0;
                ws.WindSpeedKPH = 0;
                ws.WindSpeedMPH = 0;
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
                try
                {
                    ws[i] = new WeatherStatForecast();

                    ws[i].Day = DeserializedData.forecast.simpleforecast.forecastday[i].date.day;
                    ws[i].WeekdayShrt = DeserializedData.forecast.simpleforecast.forecastday[i].date.weekday_short;

                    ws[i].SkyStat = DeserializedData.forecast.simpleforecast.forecastday[i].conditions;

                    ws[i].TemperatureC_H = DeserializedData.forecast.simpleforecast.forecastday[i].high.celsius;
                    ws[i].TemperatureF_H = DeserializedData.forecast.simpleforecast.forecastday[i].high.fahrenheit;
                    ws[i].TemperatureC_L = DeserializedData.forecast.simpleforecast.forecastday[i].low.celsius;
                    ws[i].TemperatureF_L = DeserializedData.forecast.simpleforecast.forecastday[i].low.fahrenheit;

                    ws[i].WindSpeedKPH = DeserializedData.forecast.simpleforecast.forecastday[i].avewind.kph;
                    ws[i].WindSpeedMPH = DeserializedData.forecast.simpleforecast.forecastday[i].avewind.mph;
                    ws[i].WindDirection = DeserializedData.forecast.simpleforecast.forecastday[i].avewind.dir;
                }
                catch // In case of if response pattern was changed by wunderground.com
                {
                    ws[i] = new WeatherStatForecast();

                    ws[i].Day = "0";
                    ws[i].WeekdayShrt = "Mo";

                    ws[i].SkyStat = "N/A";

                    ws[i].TemperatureC_H = 0;
                    ws[i].TemperatureC_L = 0;
                    ws[i].TemperatureF_H = 0;
                    ws[i].TemperatureF_L = 0;

                    ws[i].WindSpeedKPH = 0;
                    ws[i].WindSpeedMPH = 0;
                    ws[i].WindDirection = "N/A";

                    isSuccess = false; // If even only one day was with error, whole forecast assumes as invalid.
                }
            }

            weatherForecast = ws;
            return isSuccess;
        }
    }
}