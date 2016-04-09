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
	public partial class Insert : ContentPage
	{
        List<Task> taskList = new List<Task>();
		public Insert ()
		{
			InitializeComponent ();

            DepartmentProvider provider = new DepartmentProvider();
            Task<List<Department>> depTask = Task<List<Department>>.Run(() => provider.Get().Result);
            taskList.Add(depTask);
            Task.WaitAll(taskList.ToArray());
            if (depTask.Status == TaskStatus.RanToCompletion)
            {
                var result = depTask.Result;
                foreach (var item in result)
                {
                    pckrDapertmanet.Items.Add(item.DepartmanName);
                }
            }
		}

        public void onInsertStudent(object sender, EventArgs e)
        {
            Student student = new Student();
            student.Name = txtName.Text;
            student.Surname = txtSurname.Text;
            student.BirthDate = dtpBirthDate.Date;
            student.RegistrationDate = DateTime.Now;
            student.DepartmentID = pckrDapertmanet.SelectedIndex + 1;
            student.About = txtAbout.Text;

            StudentProvider provider = new StudentProvider();
            Task<MobileResult> insertTask = Task<MobileResult>.Run(() => provider.Insert(student).Result);
            taskList.Add(insertTask);
            Task.WaitAll(taskList.ToArray());
            if (insertTask.Status == TaskStatus.RanToCompletion)
            {
                var result = insertTask.Result;
                DisplayAlert(result.Result.ToString(), result.Message, "Ok");
            }
        }

    }
}
