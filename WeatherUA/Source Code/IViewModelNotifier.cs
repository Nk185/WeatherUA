/*
 * Application:    WeatherUA
 * Solution:       WeatherUA
 * Copyright:      Nk185
 * Code copyright: Nk185
 * File version:   1.4.1.0 
 * Used external packages: 
 *      Galasoft - MVVM;
 *      Newtonsoft - JSON;
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherUA.Source_Code
{
    interface IViewModelNotifier
    {
        /// <summary>
        /// Notifies a ViewModel that WeatherStat and WeatherStatForecast properties could be modified.
        /// </summary>
        /// <param name="NewStat">New instance of WeatherStat</param>
        /// <param name="NewForecast">New array of WeatherStatForecast instances</param>
        /// <param name="isStatValid">If NewStat have valid value. If false, new value should be ignored</param>
        /// <param name="isForecValid">If NewForecast[] have valid values. If false, new values should be ignored</param>
        void PropertyChangedW(WeatherStat NewStat, WeatherStatForecast[] NewForecast, bool isStatValid, bool isForecValid);
    }
}
