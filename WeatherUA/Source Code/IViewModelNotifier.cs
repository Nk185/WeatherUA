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

using  System.Collections.Generic;

namespace WeatherUA.Source_Code
{
    interface IViewModelNotifier
    {
        /// <summary>
        /// Notifies a ViewModel that WeatherStat and WeatherStatForecast properties could be modified.
        /// </summary>
        /// <param name="newStat">New instance of WeatherStat</param>
        /// <param name="newForecast">New array of WeatherStatForecast instances</param>
        /// <param name="isStatValid">If NewStat have valid value. If false, new value should be ignored</param>
        /// <param name="isForecValid">If NewForecast[] have valid values. If false, new values should be ignored</param>
        void PropertyChangedW(WeatherStat newStat, List<WeatherStatForecast> newForecast, bool isStatValid, bool isForecValid);
    }
}
