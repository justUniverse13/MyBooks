﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyBooks
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewBookPage : ContentPage
	{
		public NewBookPage ()
		{
			InitializeComponent ();
		}

        private void Button_Clicked(object sender, EventArgs e)
        {
            Book book = new Book()
            {
                Name = nameEntry.Text,
                Author = authorEntry.Text
            };

           using( SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.DB_PATH))
            {
                conn.CreateTable<Book>();
               var numbersOfRaws = conn.Insert(book);

                if (numbersOfRaws > 0)
                {
                    DisplayAlert("Success", "We have handle Click alert,", "Great!");
                }
                else
                {
                    DisplayAlert("Failure", "We have not handle Click alert,", "Fail!");
                }
            }
           
           // 
        }
    }
}