﻿using MauiAppMinhasCompras1.Helpers;

namespace MauiAppMinhasCompras1
{
    public partial class App : Application
    {
        static SQLiteDatabaseHelper? _db;

        public static SQLiteDatabaseHelper Db
        {
            get
            {
                if (_db == null)
                {
                    string path = Path.Combine(
                        Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),"banco_sqlit_compras.db3");
                    _db = new SQLiteDatabaseHelper(path);

                }
                return _db;

            }

        }
       
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new NavigationPage(new Views.ListaProduto()));
        }
    }
}