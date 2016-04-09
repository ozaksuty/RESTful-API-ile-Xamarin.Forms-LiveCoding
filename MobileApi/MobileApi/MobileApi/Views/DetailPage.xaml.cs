using MobileApi.Models;
using MobileApi.ServiceProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace MobileApi.Views
{
	public partial class DetailPage : ContentPage
	{
        StudentProvider provider = new StudentProvider();
        List<Task> taskList = new List<Task>();
		public DetailPage ()
		{
			InitializeComponent ();

            Task<List<Student>> studTask = Task<List<Student>>.Run(() => provider.Get().Result);
            taskList.Add(studTask);
            Task.WaitAll(taskList.ToArray());
            if (studTask.Status == TaskStatus.RanToCompletion)
            {
                var result = studTask.Result;
                lvStudents.ItemsSource = result;
            }
            lvStudents.ItemSelected += LvStudents_ItemSelected;
        }

        private async void LvStudents_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Student selectedStuden = (Student)e.SelectedItem;
            var accepted = await DisplayAlert("Are You Sure?", "Delete " + selectedStuden.Name, "Ok", "Cancel");
            if (accepted)
            {
                Task<MobileResult> deletedTask = Task<MobileResult>.Run(() => provider.Delete(selectedStuden.StudentID).Result);
                taskList.Add(deletedTask);
                Task.WaitAll(taskList.ToArray());
                if (deletedTask.Status == TaskStatus.RanToCompletion)
                {
                    var result = deletedTask.Result;
                    DisplayAlert("Success", result.Message, "Ok");
                }
            }
        }
    }
}
