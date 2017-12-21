using System;
using SQLite;
using SQLitePCL;
namespace ICT13580010FinalA.Models
{
    public class Employee
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [NotNull]
        [MaxLength(30)]
        public String Name { get; set; }

        [NotNull]
        [MaxLength(30)]
        public String SurName { get; set; }

        [NotNull]
        [MaxLength(3)]
        public int Age { get; set; }

        [NotNull]
        public String Sex { get; set; }

        [NotNull]
        public String Department { get; set; }

        [MaxLength(15)]
        public String Tel { get; set; }

        [MaxLength(30)]
        public String Email { get; set; }

        [NotNull]
        [MaxLength(100)]
        public string Address { get; set; }

        public String Status { get; set; }

        public int Child { get; set; }

        public decimal Salary { get; set; }
    }
}
