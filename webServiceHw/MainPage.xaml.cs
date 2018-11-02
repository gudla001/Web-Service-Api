using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;
using System.Collections;
using Newtonsoft.Json.Linq;
using Intents;
using Plugin.Connectivity;

namespace webServiceHw
{
    public partial class MainPage : ContentPage
    {
        public bool DoIHaveInternet()
        {
            return CrossConnectivity.Current.IsConnected;
        }
        ObservableCollection<DefinitionModel> collection = new ObservableCollection<DefinitionModel>();
        public MainPage()
        {
            InitializeComponent();


        }

       async void Handle_Completed(object sender, System.EventArgs e)
        {
            if(!DoIHaveInternet())
            {
                await DisplayAlert("Alert", "No internet connection", "OK");
            }

            var text = ((Entry)sender).Text;
            var client = new HttpClient();
            var definitionApiAddress = "https://owlbot.info/api/v2/dictionary/";
            var Uri = new Uri(definitionApiAddress+text);
            var response = await client.GetAsync(Uri);
            if (response.IsSuccessStatusCode)
            {
                var jsonContent = await response.Content.ReadAsStringAsync();
                if(jsonContent == "[]")
                {
                    nullObject.Text = "*** " + text + "*** is not a word";
                }
               
                var some = JsonConvert.DeserializeObject<List<DefinitionModel>>(jsonContent);
                foreach (var item in some)
                {
                    if (item != null )
                    {
                        collection.Add(item);
                    }
                }
             }
            defListView.ItemsSource = collection;
        }
      
    }
}
