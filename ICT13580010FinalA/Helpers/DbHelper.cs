using System;
using System.Collections.Generic;
using System.Linq;
using ICT13580010FinalA.Models;
using SQLite;
namespace ICT13580010FinalA.Helpers

{
    public class DbHelper
    {
        SQLiteConnection db;

        public DbHelper(string dbPath)
        {
            db = new SQLiteConnection(dbPath);
            db.CreateTable<Employee>();
        }

        public int AddEmp(Employee employee)
        {
            db.Insert(employee);
            return employee.Id;
        }

        public List<Employee> GetEmployees()
        {
            return db.Table<Employee>().ToList();
        }

        public int UpdateEmp(Employee employee)
        {
            return db.Update(employee);
        }

        public int DeleteEmp(Employee employee)
        {
            return db.Delete(employee);
        }
    }
}
