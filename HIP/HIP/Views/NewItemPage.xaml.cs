﻿using System;

using Xamarin.Forms;
using HIP.Models;
namespace HIP
{
    public partial class NewItemPage : ContentPage
    {
        public Event Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();

            //Item = new Event
            //{
            //    //Text = "Item name",
            //    //Description = "This is an item description."
            //};

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddItem", Item);
            await Navigation.PopToRootAsync();
        }
    }
}
