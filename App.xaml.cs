﻿namespace clock
{
    public partial class App : Application
    {
        [Obsolete]
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }
    }
}
