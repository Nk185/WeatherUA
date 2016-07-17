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
        public String Name { get; set; }
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
        /// !IMPORTANT! City name should be written as for request, because it's passes to the request as is. !IMPORTANT!
        /// </summary>
        private void InitCitiesList()
        {
            this.Cities = new List<City>
            {
                new City { Name = "Ai-Petri" },
                new City { Name = "Aleksandropol" },
                new City { Name = "Amvrosiivka" },
                new City { Name = "Artemivs'k" },
                new City { Name = "Askaniia-Nova" },
                new City { Name = "Bastanka" },
                new City { Name = "Bekhtery" },
                new City { Name = "Berezhany" },
                new City { Name = "Bila_Tserkva" },
                new City { Name = "Bilopillja" },
                new City { Name = "Bilovods'k" },
                new City { Name = "Bobrynets'" },
                new City { Name = "Bohodukhiv" },
                new City { Name = "Boryspil" },
                new City { Name = "Botieve" },
                new City { Name = "Brody" },
                new City { Name = "Cape_Kazantip" },
                new City { Name = "Chaplyne" },
                new City { Name = "Cherkasy" },
                new City { Name = "Chernihiv" },
                new City { Name = "Chernivtsi" },
                new City { Name = "Chornobyl'" },
                new City { Name = "Chornomors'Ke" },
                new City { Name = "Chortkiv" },
                new City { Name = "Chyhyryn" },
                new City { Name = "Dar'Ivka" },
                new City { Name = "Debal'Tseve" },
                new City { Name = "Dnipropetrovs'k" },
                new City { Name = "Donets'k" },
                new City { Name = "Drohobych" },
                new City { Name = "Druzhba" },
                new City { Name = "Dzankoj"},
                new City { Name = "Fastov" },
                new City { Name = "Feodosiia" },
                new City { Name = "Glukhov" },
                new City { Name = "Gulyaypole" },
                new City { Name = "Hadiach" },
                new City { Name = "Haisyn" },
                new City { Name = "Heniches'k" },
                new City { Name = "Hubynykha" },
                new City { Name = "Ivano-Frankivs'k" },
                new City { Name = "Izium" },
                new City { Name = "Izmail" },
                new City { Name = "Kagul" },
                new City { Name = "Kalush" },
                new City { Name = "Kamenka-Bugskaya" },
                new City { Name = "Kamianets'-Podil'_Skyi" },
                new City { Name = "Kerch" },
                new City { Name = "Kharkiv" },
                new City { Name = "Kherson" },
                new City { Name = "Khmel'Nyts'Kyy" },
                new City { Name = "Kirovohrad" },
                new City { Name = "Klepynine" },
                new City { Name = "Kobeliaky" },
                new City { Name = "Kolomak" },
                new City { Name = "Kolomyia" },
                new City { Name = "Komisarivka" },
                new City { Name = "Konotop'" },
                new City { Name = "Korosten" },
                new City { Name = "Kovel'" },
                new City { Name = "Krasnohrad" },
                new City { Name = "Kremencug" },
                new City { Name = "Kryms'Ka" },
                new City { Name = "Kryvyi_Rih" },
                new City { Name = "Kupians'k" },
                new City { Name = "Kyiv" },
                new City { Name = "Kyrylivka" },
                new City { Name = "L'Viv" },
                new City { Name = "Lebedin" },
                new City { Name = "Liubashivka" },
                new City { Name = "Lozova"},
                new City { Name = "Lubny"},
                new City { Name = "Luhans'k"},
                new City { Name = "Luts'k"},
                new City { Name = "Mariupol'"},
                new City { Name = "Melitopol'"},
                new City { Name = "Mikolaiv"},
                new City { Name = "Mohyliv_Podil'S'Kyy"},
                new City { Name = "Mostiska"},
                new City { Name = "Myronivka"},
                new City { Name = "Nikopol'"},
                new City { Name = "Nizhni_Sirohozy"},
                new City { Name = "Nizhyn"},
                new City { Name = "Nova_Kakhovka"},
                new City { Name = "Nova_Ushytsia"},
                new City { Name = "Novo-Selovskoye"},
                new City { Name = "Novohrad-Volyns'Kyi"},
                new City { Name = "Nyzhniohirs'k"},
                new City { Name = "Odessa"},
                new City { Name = "Ovruch"},
                new City { Name = "Pavlograd"},
                new City { Name = "Perechin"},
                new City { Name = "Pervomais'k"},
                new City { Name = "Pnevno"},
                new City { Name = "Poltava"},
                new City { Name = "Pomichna"},
                new City { Name = "Poshtove"},
                new City { Name = "Priluky"},
                new City { Name = "Primorskiy"},
                new City { Name = "Pryshyb"},
                new City { Name = "Rava-Rus'Ka"},
                new City { Name = "Rivne"},
                new City { Name = "Romny"},
                new City { Name = "Rotmistrovka"},
                new City { Name = "Rozdil'Na"},
                new City { Name = "Sarata"},
                new City { Name = "Sarny"},
                new City { Name = "Seliatyn"},
                new City { Name = "Semenovka"},
                new City { Name = "Serbka"},
                new City { Name = "Sevastopol"},
                new City { Name = "Shepetivka"},
                new City { Name = "Simferopol"},
                new City { Name = "Skole"},
                new City { Name = "Sovetskiy"},
                new City { Name = "Sumy"},
                new City { Name = "Svatove"},
                new City { Name = "Svitlovods'k"},
                new City { Name = "Ternopil'"},
                new City { Name = "Teteriv"},
                new City { Name = "Uman'"},
                new City { Name = "Uzhhorod"},
                new City { Name = "Velikiy_Berezny"},
                new City { Name = "Velyka_Oleksandrivka"},
                new City { Name = "Velykyi_Burluk"},
                new City { Name = "Veselyi_Podil"},
                new City { Name = "Vinnytsia"},
                new City { Name = "Vladislavovka"},
                new City { Name = "Volnovakha"},
                new City { Name = "Volodymyr_Volyns'Kyy"},
                new City { Name = "Volskovtsky"},
                new City { Name = "Voznesens'k"},
                new City { Name = "Yahotyn"},
                new City { Name = "Yalta"},
                new City { Name = "Yampol'"},
                new City { Name = "Yasnya"},
                new City { Name = "Yavorov"},
                new City { Name = "Yevpatoriia"},
                new City { Name = "Zaporizhzhia"},
                new City { Name = "Zhashkov"},
                new City { Name = "Zhytomyr"},
                new City { Name = "Znamianka"},
                new City { Name = "Zolotonosha"},
                new City { Name = "Zvenihorodka"},
            };
        }

        /// <summary>
        /// Gets json response as string and sends it for parsing.
        /// </summary>
        /// <param name="forecast">Reference to forecast array</param>
        /// <param name="currStat">Reference to current weather status</param>
        /// <returns>If data was successfully recived. If returns false, data was not changed.</returns>
        public async void LoadData(string city)
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
                        this.ShowMsg("Occurred error: Cannot load forecast. Try again a bit later", "Got it");

                    if (!StatSuccessfully)
                        this.ShowMsg("Occurred error: Cannot load current weather status. Try again a bit later", "Got it");

                    this._viewNotifier.PropertyChangedW(CurrentStatus, Forecast, StatSuccessfully, ForecSuccessfully);
                }
                else
                {
                    this.ShowMsg("Occurred error: No Internet connection or server is not responding on requests. Try again a bit later", "Got it");

                    this._viewNotifier.PropertyChangedW(null, null, false, false); // To enable button and viewlist
                }
            }
            catch (Exception e)
            {
                this.ShowMsg("Occurred error: seems like we cannot acess the Internet. Check your connection.", "Got it");

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
