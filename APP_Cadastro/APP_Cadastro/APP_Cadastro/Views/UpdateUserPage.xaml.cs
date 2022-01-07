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
    public partial class UpdateUserPage : ContentPage
    {
        RestService _restService;
        string _id;

        public UpdateUserPage(string id)
        {
            _id = id;
            InitializeComponent();
            _restService = new RestService();
        }


        async void OnUpdateButtonClicked(object sender, EventArgs e)
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
                        await _restService.UpdateUserAsync(user, Constants.ApiCadastroEndpoint + _id);
                        await DisplayAlert("Alert", "Usuário Atualizado!", "OK");
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

