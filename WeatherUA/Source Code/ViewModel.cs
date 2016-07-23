/*
 * Application:    WeatherUA
 * Solution:       WeatherUA
 * Copyright:      Nk185
 * Code copyright: Nk185
 * File version:   1.4.3.0
 * Used external packages: 
 *      Galasoft - MVVM;
 *      Newtonsoft - JSON;
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;


namespace WeatherUA.Source_Code
{
    public class ViewModel : ViewModelBase, IViewModelNotifier
    {   
        private readonly Model _mdl; // Model; Contains data
        private WeatherStat _currentStatus;
        private City _chosenCity;

        public RelayCommand UpdateBtn { get; private set; } // When button clicked in Settings     

        public List<WeatherStatForecast> WeatherStatForecasts { get; private set; }

        public List<City> Cities { get; set; } // Collection of items for listview (cities)
        public City ChosenCity
        {
            get { return _chosenCity; }
            set
            {
                _chosenCity = value;
                RaisePropertyChanged(() => TtlWeatherFor);
                UpdateInfo();
            }
        } // Auto update title and info when another city chosen

        public bool UpdateBtnEnabled { get; private set; }
        public bool ProgressRingEnabled { get { return !UpdateBtnEnabled; } }

        #region Main info about current day
        public String TtlWeatherFor { get { return "WEATHER FOR: " + ChosenCity.Name.ToUpper() + ", UKRAINE"; } } // Title
        public String TemperatureNow
        {
            get
            {
                return _currentStatus.TemperatureC.ToString() +
                    "°C / " + _currentStatus.TemperatureF + "°F";
            }
        }
        public String FeelsLike
        {
            get
            {
                return "Feels like: " + _currentStatus.FeelsLikeC.ToString() +
                    "°C / " + _currentStatus.FeelsLikeF + "°F";
            }
        }
        public String SkyStatus
        {
            get
            {
                if (_currentStatus.SkyStat == "" || _currentStatus.SkyStat == " ")
                    return "Sky status: N/A";
                else
                    return "Sky status: " + _currentStatus.SkyStat;
            }
        }
        public String WindSpeed
        {
            get
            {
                return "Wind speed: " + _currentStatus.WindSpeedKph + "km/h | "
                    + _currentStatus.WindSpeedMph + "mph";
            }
        }
        public String WindDirection { get { return "Wind direction: " + _currentStatus.WindDirection; } }
        public String BackGroundImg
        {
            get
            {
                String stat = _currentStatus.SkyStat;
                String res = "Assets/";

                if (stat.Contains("Rain"))
                    res += "Rainy.jpg";
                else if (stat.Contains("Snow") || stat.Contains("Ice") || stat.Contains("Hail"))
                    res += "Snowy.jpg";
                else if (stat.Contains("Mist") || stat.Contains("Fog") || stat.Contains("Smoke"))
                    res += "Mist.jpg";
                else if (stat.Contains("Ash") || stat.Contains("Dust") || stat.Contains("Sand") ||
                    stat.Contains("Haze") || stat.Contains("Spray") || stat.Contains("Sandstorm"))
                    res += "Dust.jpg";
                else if (stat.Contains("Rain") && !stat.Contains("Thunderstorms"))
                    res += "Rainy.jpg";
                else if (stat.Contains("Thunderstorms"))
                    res += "Thunderstorm.jpg";
                else if (stat.Contains("Overcast") || stat.Contains("Cloudy") || stat.Contains("Cloud") || stat.Contains("Squalls"))
                    res += "Cloudy.jpg";
                else if (stat.Contains("Clear") || stat.Contains("Partly Cloudy"))
                    res += "Sunny.jpg";
                else // if N/A, Unknown or error
                    res += "SolidColor.jpg";

                return res;
            }
        }
        #endregion

        public ViewModel()
        {
            // Initialize model
            // Load cities
            _mdl = new Model(this);
            Cities = _mdl.Cities;

            // Init default city
            _chosenCity = Cities[65];

            // If user want to update info manualy
            UpdateBtn = new RelayCommand(Click);

            //Load weather from server
            UpdateInfo();
        }

        /// <summary>
        /// Manual information updating
        /// </summary>
        private void Click()
        {
            UpdateInfo();
        }

        /// <summary>
        /// Load/Update forecast and current info
        /// </summary>
        private void UpdateInfo()
        {
            WeatherStatForecasts = new List<WeatherStatForecast>(); // reset old info (or init if first launch)
            _currentStatus       = new WeatherStat(); // reset old info (or init if first launch)
            UpdateBtnEnabled     = false;

            RaisePropertyChanged(() => WeatherStatForecasts);

            RaisePropertyChanged(() => TtlWeatherFor);
            RaisePropertyChanged(() => TemperatureNow);
            RaisePropertyChanged(() => FeelsLike);
            RaisePropertyChanged(() => SkyStatus);
            RaisePropertyChanged(() => WindSpeed);
            RaisePropertyChanged(() => WindDirection);
            
            RaisePropertyChanged(() => UpdateBtnEnabled);
            RaisePropertyChanged(() => ProgressRingEnabled);

            _mdl.LoadWeatherData(ChosenCity.Content);
        }

        /// <summary>
        /// Implements IViewModelNotifier.
        /// Updates UI according to passed data
        /// </summary>
        /// <param name="newStat">New information about current weather.</param>
        /// <param name="newForecast">New information about forecast.</param>
        /// <param name="isStatValid">If current weather contains valid data.</param>
        /// <param name="isForecValid">If forecast conteins valid data.</param>
        public void PropertyChangedW(WeatherStat newStat, List<WeatherStatForecast> newForecast, bool isStatValid, bool isForecValid)
        {
            if (isStatValid)
            {
                _currentStatus = newStat;

                RaisePropertyChanged(() => TtlWeatherFor);
                RaisePropertyChanged(() => TemperatureNow);
                RaisePropertyChanged(() => FeelsLike);
                RaisePropertyChanged(() => SkyStatus);
                RaisePropertyChanged(() => WindSpeed);
                RaisePropertyChanged(() => WindDirection);
                RaisePropertyChanged(() => BackGroundImg);
            }

            if (isForecValid)
            {
                WeatherStatForecasts = newForecast;
                RaisePropertyChanged(() => WeatherStatForecasts);
            }

            UpdateBtnEnabled = true;
            RaisePropertyChanged(() => UpdateBtnEnabled);
            RaisePropertyChanged(() => ProgressRingEnabled);
        }
    }
}