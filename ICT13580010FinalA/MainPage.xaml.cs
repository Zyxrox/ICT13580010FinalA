using System;
using System.Collections.Generic;
using ICT13580010FinalA.Models;
using Xamarin.Forms;

namespace ICT13580010FinalA
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            newButton.Clicked += NewButton_Clicked;
        }

        void LoadData()
        {
            employeeListView.ItemsSource = App.DbHelper.GetEmployees();
        }

        protected override void OnAppearing()
        {
            LoadData();
        }

        void NewButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new EmployeeNewPage());
        }

        void Edit_Clicked(object sender, System.EventArgs e)
        {
            var button = sender as MenuItem;
            var employee = button.CommandParameter as Employee;
            Navigation.PushModalAsync(new EmployeeNewPage(employee));
        }

        async void Delete_Clicked(object sender, System.EventArgs e)
        {
            var isOk = await DisplayAlert("Confirm", "Do you really want to delete this employee?", "Yes", "No");

            if (isOk)
            {
                var button = sender as MenuItem;
                var product = button.CommandParameter as Employee;
                App.DbHelper.DeleteEmp(product);

                await DisplayAlert("Success", "Successfully deleted the employee.", "Done");
                LoadData();
            }
        }
    }
}
