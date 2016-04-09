using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace MobileApi.Views
{
	public partial class MenuPage : ContentPage
	{
		public MenuPage ()
		{
			InitializeComponent ();
            Title = "XamarinTR";
		}
        public void onInsert(object sender, EventArgs e)
        {
            var startPage = (Start)this.Parent;
            startPage.Detail = new Insert();
            startPage.IsPresented = false;
        }

    }
}
