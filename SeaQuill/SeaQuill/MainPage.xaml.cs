using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SeaQuill
{
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            ListView.ItemsSource = await App.Database.GetJokesAsync();
        }

        private async void OnSaveClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(NewJoke.Text)) return;

            var joke = new Joke
            {
                Content = NewJoke.Text
            };
            await App.Database.SaveJokeAsync(joke);

            ListView.ItemsSource = await App.Database.GetJokesAsync();
        }
    }
}
