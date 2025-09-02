﻿using System.Collections.ObjectModel;

namespace MauiMatchingPairs
{
    public partial class MainPage : ContentPage
    {
        MainPageViewModel vm;

        public MainPage()
        {
            InitializeComponent();

            vm = new MainPageViewModel();
            BindingContext = vm;
        }
    }
}
