using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace APP_Cadastro
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
            Routing.RegisterRoute(nameof(UserPage), typeof(UserPage));
        }

    }
}
