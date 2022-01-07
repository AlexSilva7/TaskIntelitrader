using APP_Cadastro.Models;
using APP_Cadastro.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace APP_Cadastro
{
    public partial class MainPage : ContentPage
    {
        RestService _restService;

        public MainPage()
        {
            InitializeComponent();
            _restService = new RestService();
        }

        async void OnRegisterButtonClicked(object sender, EventArgs e)
        {
            if (InputName.Text == null || InputAge.Text == null || InputName.Text.Trim() == "")
            {
                await DisplayAlert("Alert", "Nome e idade devem ser preenchidos!", "OK");
            }
            else
            {
                string name = InputName.Text;
                string surname = InputSurname.Text;
                int age;

                bool convertAge = Int32.TryParse(InputAge.Text, out age);

                if (!convertAge)
                {
                    await DisplayAlert("Alert", "Idade inválida", "OK");
                }
                else
                {
                    User user = new User()
                    {
                        Name = name,
                        Surname = surname,
                        Age = age
                    };

                    try
                    {
                        await _restService.PostUserAsync(user, Constants.ApiCadastroEndpoint);
                        await DisplayAlert("Alert", "Usuário Cadastrado!", "OK");
                        App.Current.MainPage = new AppShell();

                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(@"\Error: " + ex);
                    }

                }
            }
        }
    }
}
