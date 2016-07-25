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

using System.Collections.Generic;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;


namespace WeatherUA.Source_Code
{
    public class ViewModel : ViewModelBase, IViewModelNotifier
    {   
        private readonly Model _mdl; // Model; Contains data
        private WeatherStat _currentStatus;
        private City _chosenCity;

        /// <summary>
        /// Gets command on "update button" click.
        /// </summary>
        public RelayCommand UpdateBtn { get; private set; } // When button clicked in Settings     

        /// <summary>
        /// Gets list of weather forecasts.
        /// </summary>
        public List<WeatherStatForecast> WeatherStatForecasts { get; private set; }

        /// <summary>
        /// Gets list of cities for which can get info.
        /// </summary>
        public List<City> Cities { get; private set; } // Collection of items for listview (cities)
        /// <summary>
        /// Gets or sets selected city.
        /// </summary>
        public City ChosenCity
        {
            get { return _chosenCity; }
            set
            {
                _chosenCity = value;
                RaisePropertyChanged(() => TtlWeatherFor); // Auto update title and info when another city chosen
                UpdateInfo();
            }
        } 
        
        /// <summary>
        /// Gets availability of "update" button. 
        /// </summary>
        public bool UpdateBtnEnabled { get; private set; }
        /// <summary>
        /// Gets if "update" progress ring is enabled.
        /// </summary>
        public bool ProgressRingEnabled { get { return !UpdateBtnEnabled; } }

        #region Main info about current day
        public string TtlWeatherFor { get { return "WEATHER FOR: " + ChosenCity.Name.ToUpper() + ", UKRAINE"; } } // Title
        public string TemperatureNow
        {
            get
            {
                return _currentStatus.TemperatureC.ToString() +
                    "°C / " + _currentStatus.TemperatureF + "°F";
            }
        }
        public string FeelsLike
        {
            get
            {
                return "Feels like: " + _currentStatus.FeelsLikeC.ToString() +
                    "°C / " + _currentStatus.FeelsLikeF + "°F";
            }
        }
        public string SkyStatus
        {
            get
            {
                if (_currentStatus.SkyStat == "" || _currentStatus.SkyStat == " ")
                    return "Sky status: N/A";
                else
                    return "Sky status: " + _currentStatus.SkyStat;
            }
        }
        public string WindSpeed
        {
            get
            {
                return "Wind speed: " + _currentStatus.WindSpeedKph + "km/h | "
                    + _currentStatus.WindSpeedMph + "mph";
            }
        }
        public string WindDirection { get { return "Wind direction: " + _currentStatus.WindDirection; } }
        public string BackGroundImg { get { return _currentStatus.BackGroundImg; } }

        public uint DayBrogressValue { get { return _currentStatus.Localtime; } }
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
            /*WeatherStatForecasts = new List<WeatherStatForecast>();
            _currentStatus = new WeatherStat();
            WeatherStatForecasts.Add(new WeatherStatForecast());

            UpdateBtnEnabled = true;*/
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
            RaisePropertyChanged(() => DayBrogressValue);
            
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
                RaisePropertyChanged(() => DayBrogressValue);
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