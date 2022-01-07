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
    public partial class UserPage : ContentPage
    {
        RestService _restService;

        public UserPage()
        {
            _restService = new RestService();
            GetUser();
        }


        async void GetUser()
        {
            List<User> users = await _restService.GetUsersAsync(Constants.ApiCadastroEndpoint);
            InitializeComponent();
            collectionView.ItemsSource = users;

        }


        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            bool resposta = await DisplayAlert("Exclusão", "Deseja excluir o usuário ?", "Sim", "Não");

            if (resposta)
            {
                string id = ((ImageButton)sender).BindingContext as string;

                try
                {
                    await _restService.DeleteUserAsync(Constants.ApiCadastroEndpoint + id);
                    App.Current.MainPage = new AppShell();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("\tERROR {0}", ex.Message);
                }
            }

        }

        async void OnUpdateButtonClicked(object sender, EventArgs e)
        {
            bool resposta = await DisplayAlert("Atualizar", "Deseja atualizar o usuário ?", "Sim", "Não");

            if (resposta)
            {
                string id = ((ImageButton)sender).BindingContext as string;


                try
                {
                    await Navigation.PushAsync(new UpdateUserPage(id));
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("\tERROR {0}", ex.Message);
                }
            }
        }
    }
}
