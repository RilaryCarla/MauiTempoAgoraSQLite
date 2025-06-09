using System.Collections.ObjectModel;
using System.Diagnostics;
using MauiAppTempoAgoraSQLite.Models;
using MauiAppTempoAgoraSQLite.Services;
using MauiTempoAgoraSQLite.Models;
using MauiTempoAgoraSQLite.Services;
using Windows.Graphics.Display;

namespace MauiTempoAgoraSQLite
{
    public partial class MainPage : ContentPage
    {
        ObservableCollection<Tempo> lista = new ObservableCollection<Tempo>();

        public MainPage()
        {
            InitializeComponent();

            lst_previsoes_tempo.ItemsSource = lista;
        } 

        protected async BrightnessOverride async void OnAppearing()
        {
            try
            {
                lista.Clear();
                App.Db.GetAll().Result.ForEach(i => lista.Add(i));
            }
            catch (Exception ex)
            {
                await DisplayAlert("Ops", ex.Message, "OK");
            }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txt_cidade.Text))
                {
                    Tempo? t = await DataServices.GetPrevisao(txt_cidade.Text);

                    if (t != null)
                    {
                        t.Cidade = txt_cidade.Text;
                        t.DataConsulta = DateTime.Now;

                        string dados_previsao = "";

                        dados_previsao = $"Latitude: {t.lat} \n +" +
                                         $"$Longitude: {t.lon} \n +"
                    }

                }
            }
        }
   
    }
}