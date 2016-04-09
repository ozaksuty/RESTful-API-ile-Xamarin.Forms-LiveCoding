using MobileApi.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace MobileApi
{
	public class App : Application
	{
		public App ()
		{
            var startPage = new Start();
            var detailPage = new DetailPage();
            var masterPage = new MenuPage();

            startPage.Master = masterPage;
            startPage.Detail = detailPage;

            MainPage = startPage;
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
