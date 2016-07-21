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
using Windows.UI.Popups;

namespace WeatherUA.Source_Code
{
    /// <summary>
    /// Represents city as object
    /// </summary>
    public class City
    {
        /// <summary>
        /// City name
        /// </summary>
        public string Name { get; set; }
        public string Content { get; set; }
    }

    /// <summary>
    /// Main model. Conteins general methods.
    /// Prepairs data for ViewModel.
    /// </summary>
    class Model
    {
        private IViewModelNotifier _viewNotifier;

        /// <summary>
        /// Lis of cities for "Location Settings" list in View.
        /// </summary>
        public List<City> Cities { get; private set; }

        public Model(IViewModelNotifier viewNotifier)
        {
            this._viewNotifier = viewNotifier;
            InitCitiesList();
        }

        /// <summary>
        /// Fills list with cities names
        /// !IMPORTANT! City content should be written as for request, because it's passes to the request as is. !IMPORTANT!
        /// </summary>
        private void InitCitiesList()
        {
            this.Cities = new List<City>
            {
                new City { Name = "Ai-Petri", Content = "Ai-Petri" },
                new City { Name = "Aleksandropol", Content = "Aleksandropol" },
                new City { Name = "Amvrosiivka", Content = "Amvrosiivka" },
                new City { Name = "Artemivs'k", Content = "Artemivs'k" },
                new City { Name = "Askaniia Nova", Content = "Askaniia-Nova" },
                new City { Name = "Bastanka", Content = "Bastanka" },
                new City { Name = "Bekhtery", Content = "Bekhtery" },
                new City { Name = "Berezhany", Content = "Berezhany" },
                new City { Name = "Bila Tserkva", Content = "Bila_Tserkva" },
                new City { Name = "Bilopillja", Content = "Bilopillja" },
                new City { Name = "Bilovods'k", Content = "Bilovods'k" },
                new City { Name = "Bobrynets'", Content = "Bobrynets'" },
                new City { Name = "Bohodukhiv", Content = "Bohodukhiv" },
                new City { Name = "Boryspil'", Content = "Boryspil'" },
                new City { Name = "Botieve", Content = "Botieve" },
                new City { Name = "Brody", Content = "Brody" },
                new City { Name = "Cape Kazantip", Content = "Cape_Kazantip" },
                new City { Name = "Chaplyne", Content = "Chaplyne" },
                new City { Name = "Cherkasy", Content = "Cherkasy" },
                new City { Name = "Chernihiv", Content = "Chernihiv" },
                new City { Name = "Chernivtsi", Content = "Chernivtsi" },
                new City { Name = "Chornobyl'", Content = "Chornobyl'" },
                new City { Name = "Chornomors'Ke", Content = "Chornomors'Ke" },
                new City { Name = "Chortkiv", Content = "Chortkiv" },
                new City { Name = "Chyhyryn", Content = "Chyhyryn" },
                new City { Name = "Dar'Ivka", Content = "Dar'Ivka" },
                new City { Name = "Debal'Tseve", Content = "Debal'Tseve" },
                new City { Name = "Dnipropetrovs'k", Content = "Dnipropetrovs'k" },
                new City { Name = "Donets'k", Content = "Donets'k" },
                new City { Name = "Drohobych", Content = "Drohobych" },
                new City { Name = "Druzhba", Content = "Druzhba" },
                new City { Name = "Dzankoj", Content = "Dzankoj"},
                new City { Name = "Fastov", Content = "Fastov" },
                new City { Name = "Feodosiia", Content = "Feodosiia" },
                new City { Name = "Glukhov", Content = "Glukhov" },
                new City { Name = "Gulyaypole", Content = "Gulyaypole" },
                new City { Name = "Hadiach", Content = "Hadiach" },
                new City { Name = "Haisyn", Content = "Haisyn" },
                new City { Name = "Heniches'k", Content = "Heniches'k" },
                new City { Name = "Hubynykha", Content = "Hubynykha" },
                new City { Name = "Ivano-Frankivs'k", Content = "Ivano-Frankivs'k" },
                new City { Name = "Izium", Content = "Izium" },
                new City { Name = "Izmail", Content = "Izmail" },
                new City { Name = "Kagul", Content = "Kagul" },
                new City { Name = "Kalush", Content = "Kalush" },
                new City { Name = "Kamenka-Bugskaya", Content = "Kamenka-Bugskaya" },
                new City { Name = "Kamianets'-Podil'skyi", Content = "Kamianets'-Podil'_Skyi" },
                new City { Name = "Kerch", Content = "Kerch" },
                new City { Name = "Kharkiv", Content = "Kharkiv" },
                new City { Name = "Kherson", Content = "Kherson" },
                new City { Name = "Khmel'Nyts'Kyy", Content = "Khmel'Nyts'Kyy" },
                new City { Name = "Kirovohrad", Content = "Kirovohrad" },
                new City { Name = "Klepynine", Content = "Klepynine" },
                new City { Name = "Kobeliaky", Content = "Kobeliaky" },
                new City { Name = "Kolomak", Content = "Kolomak" },
                new City { Name = "Kolomyia", Content = "Kolomyia" },
                new City { Name = "Komisarivka", Content = "Komisarivka" },
                new City { Name = "Konotop", Content = "Konotop" },
                new City { Name = "Korosten", Content = "Korosten" },
                new City { Name = "Kovel'", Content = "Kovel'" },
                new City { Name = "Krasnohrad", Content = "Krasnohrad" },
                new City { Name = "Kremencug", Content = "Kremencug" },
                new City { Name = "Kryms'Ka", Content = "Kryms'Ka" },
                new City { Name = "Kryvyi Rih", Content = "Kryvyi_Rih" },
                new City { Name = "Kupians'k", Content = "Kupians'k" },
                new City { Name = "Kyiv", Content = "Kyiv" },
                new City { Name = "Kyrylivka", Content = "Kyrylivka" },
                new City { Name = "L'Viv", Content = "L'Viv" },
                new City { Name = "Lebedin", Content = "Lebedin" },
                new City { Name = "Liubashivka", Content = "Liubashivka" },
                new City { Name = "Lozova", Content = "Lozova"},
                new City { Name = "Lubny", Content = "Lubny"},
                new City { Name = "Luhans'k", Content = "Luhans'k"},
                new City { Name = "Luts'k", Content = "Luts'k"},
                new City { Name = "Mariupol'", Content = "Mariupol'"},
                new City { Name = "Melitopol'", Content = "Melitopol'"},
                new City { Name = "Mikolaiv", Content = "Mikolaiv"},
                new City { Name = "Mohyliv Podil'S'Kyy", Content = "Mohyliv_Podil'S'Kyy"},
                new City { Name = "Mostiska", Content = "Mostiska"},
                new City { Name = "Myronivka", Content = "Myronivka"},
                new City { Name = "Nikopol'", Content = "Nikopol'"},
                new City { Name = "Nizhni Sirohozy", Content = "Nizhni_Sirohozy"},
                new City { Name = "Nizhyn", Content = "Nizhyn"},
                new City { Name = "Nova Kakhovka", Content = "Nova_Kakhovka"},
                new City { Name = "Nova Ushytsia", Content = "Nova_Ushytsia"},
                new City { Name = "Novo-Selovskoye", Content = "Novo-Selovskoye"},
                new City { Name = "Novohrad-Volyns'Kyi", Content = "Novohrad-Volyns'Kyi"},
                new City { Name = "Nyzhniohirs'k", Content = "Nyzhniohirs'k"},
                new City { Name = "Odessa", Content = "Odessa"},
                new City { Name = "Ovruch", Content = "Ovruch"},
                new City { Name = "Pavlograd", Content = "Pavlograd"},
                new City { Name = "Perechin", Content = "Perechin"},
                new City { Name = "Pervomais'k", Content = "Pervomais'k"},
                new City { Name = "Pnevno", Content = "Pnevno"},
                new City { Name = "Poltava", Content = "Poltava"},
                new City { Name = "Pomichna", Content = "Pomichna"},
                new City { Name = "Poshtove", Content = "Poshtove"},
                new City { Name = "Priluky", Content = "Priluky"},
                new City { Name = "Primorskiy", Content = "Primorskiy"},
                new City { Name = "Pryshyb", Content = "Pryshyb"},
                new City { Name = "Rava-Rus'Ka", Content = "Rava-Rus'Ka"},
                new City { Name = "Rivne", Content = "Rivne"},
                new City { Name = "Romny", Content = "Romny"},
                new City { Name = "Rotmistrovka", Content = "Rotmistrovka"},
                new City { Name = "Rozdil'Na", Content = "Rozdil'Na"},
                new City { Name = "Sarata", Content = "Sarata"},
                new City { Name = "Sarny", Content = "Sarny"},
                new City { Name = "Seliatyn", Content = "Seliatyn"},
                new City { Name = "Semenovka", Content = "Semenovka"},
                new City { Name = "Serbka", Content = "Serbka"},
                new City { Name = "Sevastopol", Content = "Sevastopol"},
                new City { Name = "Shepetivka", Content = "Shepetivka"},
                new City { Name = "Simferopol", Content = "Simferopol"},
                new City { Name = "Skole", Content = "Skole"},
                new City { Name = "Sovetskiy", Content = "Sovetskiy"},
                new City { Name = "Sumy", Content = "Sumy"},
                new City { Name = "Svatove", Content = "Svatove"},
                new City { Name = "Svitlovods'k", Content = "Svitlovods'k"},
                new City { Name = "Ternopil'", Content = "Ternopil'"},
                new City { Name = "Teteriv", Content = "Teteriv"},
                new City { Name = "Uman'", Content = "Uman'"},
                new City { Name = "Uzhhorod", Content = "Uzhhorod"},
                new City { Name = "Velikiy Berezny", Content = "Velikiy_Berezny"},
                new City { Name = "Velyka Oleksandrivka", Content = "Velyka_Oleksandrivka"},
                new City { Name = "Velykyi Burluk", Content = "Velykyi_Burluk"},
                new City { Name = "Veselyi Podil", Content = "Veselyi_Podil"},
                new City { Name = "Vinnytsia", Content = "Vinnytsia"},
                new City { Name = "Vladislavovka", Content = "Vladislavovka"},
                new City { Name = "Volnovakha", Content = "Volnovakha"},
                new City { Name = "Volodymyr Volyns'Kyy", Content = "Volodymyr_Volyns'Kyy"},
                new City { Name = "Volskovtsky", Content = "Volskovtsky"},
                new City { Name = "Voznesens'k", Content = "Voznesens'k"},
                new City { Name = "Yahotyn", Content = "Yahotyn"},
                new City { Name = "Yalta", Content = "Yalta"},
                new City { Name = "Yampol'", Content = "Yampol'"},
                new City { Name = "Yasnya", Content = "Yasnya"},
                new City { Name = "Yavorov", Content = "Yavorov"},
                new City { Name = "Yevpatoriia", Content = "Yevpatoriia"},
                new City { Name = "Zaporizhzhia", Content = "Zaporizhzhia"},
                new City { Name = "Zhashkov", Content = "Zhashkov"},
                new City { Name = "Zhytomyr", Content = "Zhytomyr"},
                new City { Name = "Znamianka", Content = "Znamianka"},
                new City { Name = "Zolotonosha", Content = "Zolotonosha"},
                new City { Name = "Zvenihorodka", Content = "Zvenihorodka"},
            };
        }

        /// <summary>
        /// Gets json response as string and sends it for parsing.
        /// </summary>
        /// <param name="forecast">Reference to forecast array</param>
        /// <param name="currStat">Reference to current weather status</param>
        /// <returns>If data was successfully recived. If returns false, data was not changed.</returns>
        public async void LoadWeatherData(string city)
        {
            try
            {
                WeatherStatForecast[] Forecast = new WeatherStatForecast[10];
                WeatherStat CurrentStatus = new WeatherStat();
                Requestor requestor = new Requestor();
                bool StatSuccessfully = false;
                bool ForecSuccessfully = false;
                JsonParser jsp;

                await requestor.getData(city); // getting json response

                jsp = new JsonParser(requestor.CurrentWeatherJson);

                StatSuccessfully = jsp.ParseWeatherStat(out CurrentStatus); // parsing current status

                jsp.EnterNewResponse = requestor.ForecastJson;
                ForecSuccessfully = jsp.ParseWeatherForec(out Forecast); // parsing forecast

                if (StatSuccessfully || ForecSuccessfully)
                {
                    if (!ForecSuccessfully)
                        this.ShowMsg("Occurred error: Cannot load all required data for forecast. All missed data will be replaced by default values." +
                            " Try to update info a bit later...", "Got it");

                    if (!StatSuccessfully)
                        this.ShowMsg("Occurred error: Cannot load current weather status. All missed data will be replaced by default values." +
                            " Try to update info a bit later...", "Got it");

                    this._viewNotifier.PropertyChangedW(CurrentStatus, Forecast, true, true);
                }
                else
                {
                    this.ShowMsg("Occurred error: No Internet connection or server is not responding on requests. Try again a bit later...", "Got it");

                    this._viewNotifier.PropertyChangedW(null, null, false, false); // To enable button and viewlist
                }
            }
            catch (Exception e)
            {
                this.ShowMsg("Occurred error: seems like we cannot access the Internet. Check your connection.", "Got it");

                this._viewNotifier.PropertyChangedW(null, null, false, false); // To enable button and viewlist
            }
                
        }

        private async void ShowMsg(string msg, string btn1Txt, UICommandInvokedHandler onBtn1Click)
        {
            try
            {
                MessageDialog msgDial = new MessageDialog(msg, "Information");

                UICommand okBtn = new UICommand(btn1Txt);
                okBtn.Invoked = onBtn1Click;
                msgDial.Commands.Add(okBtn);

                await msgDial.ShowAsync();
            }
            catch (Exception e)
            {

            }
        }
        private async void ShowMsg(string msg, string btn1Txt)
        {
            try
            {
                MessageDialog msgDial = new MessageDialog(msg, "Information");

                UICommand okBtn = new UICommand(btn1Txt);
                msgDial.Commands.Add(okBtn);

                await msgDial.ShowAsync();
            }
            catch (Exception e)
            {

            }
        }

        private void GotItBtn(IUICommand cmd)
        {

        }
    }
}
