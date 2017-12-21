using System;
using System.Collections.Generic;
using ICT13580010FinalA.Models;
using Xamarin.Forms;

namespace ICT13580010FinalA
{
    public partial class EmployeeNewPage : ContentPage
    {
        Employee employee;

        public EmployeeNewPage(Employee employee = null)
        {
            InitializeComponent();

            this.employee = employee;

            titleLabel.Text = employee == null ? "New Employee" : "Edit Employee";

            genderPicker.Items.Add("Male");
            genderPicker.Items.Add("Female");
            genderPicker.Items.Add("Other");

            departmentPicker.Items.Add("Sale");
            departmentPicker.Items.Add("CSR");
            departmentPicker.Items.Add("Accouting");

            statusPicker.Items.Add("Single");
            statusPicker.Items.Add("Married");
            statusPicker.Items.Add("Devorced");

            childStepper.ValueChanged += ChildStepper_ValueChanged;
            salarySlider.ValueChanged += SalarySlider_ValueChanged;

            saveButton.Clicked += SaveButton_Clicked;
            cancelButton.Clicked += CancelButton_Clicked;

            if (employee != null)
            {
                nameEntry.Text = employee.Name;
                lastNameEntry.Text = employee.SurName;
                ageEntry.Text = employee.Age.ToString();
                genderPicker.SelectedItem = employee.Sex;
                departmentPicker.SelectedItem = employee.Department;
                telEntry.Text = employee.Tel.ToString();
                emailEntry.Text = employee.Email;
                addressEditor.Text = employee.Address;
                statusPicker.SelectedItem = employee.Status;
                childLabel.Text = employee.Child.ToString();
                salaryLabel.Text = employee.Salary.ToString();
                salarySlider.Value = (double)employee.Salary;
            }
        }

        void ChildStepper_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            int value = (int)e.NewValue;
            childLabel.Text = value.ToString();
        }

        void SalarySlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            int value = (int)e.NewValue;
            salaryLabel.Text = value.ToString();
        }

        async void SaveButton_Clicked(object sender, EventArgs e)
        {
            var isOk = await DisplayAlert("Confirm", "Do you want to save?", "Yes", "No");

            if (isOk)
            {
                if (employee == null)
                {
                    employee = new Employee();

                    employee.Name = nameEntry.Text;
                    employee.SurName = lastNameEntry.Text;
                    employee.Age = int.Parse(ageEntry.Text);
                    employee.Sex = genderPicker.SelectedItem.ToString();
                    employee.Department = departmentPicker.SelectedItem.ToString();
                    employee.Tel = telEntry.Text;
                    employee.Email = emailEntry.Text;
                    employee.Address = addressEditor.Text;
                    employee.Status = statusPicker.SelectedItem.ToString();
                    employee.Child = int.Parse(childLabel.Text);
                    employee.Salary = decimal.Parse(salaryLabel.Text);


                    var id = App.DbHelper.AddEmp(employee);

                    await DisplayAlert("New Employee is saved", "The Product Id is #" + id, "Done");
                }

                else
                {
                    employee.Name = nameEntry.Text;
                    employee.SurName = lastNameEntry.Text;
                    employee.Age = int.Parse(ageEntry.Text);
                    employee.Sex = genderPicker.SelectedItem.ToString();
                    employee.Department = departmentPicker.SelectedItem.ToString();
                    employee.Tel = telEntry.Text;
                    employee.Email = emailEntry.Text;
                    employee.Address = addressEditor.Text;
                    employee.Status = statusPicker.SelectedItem.ToString();
                    employee.Child = int.Parse(childLabel.Text);
                    employee.Salary = decimal.Parse(salaryLabel.Text);

                    var id = App.DbHelper.UpdateEmp(employee);

                    await DisplayAlert("Employee is saved", "The Employee Id is #" + id, "Done");
                }

                await Navigation.PopModalAsync();
            }
        }

        void CancelButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}
