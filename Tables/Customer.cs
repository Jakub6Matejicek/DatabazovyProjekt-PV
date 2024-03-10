using DatabasovyProjektPV.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabasovyProjektPV.Tables
{
    internal class Customer : IBaseClass
    {
        private int id;
        private string firstName;
        private string lastName;
        private string email;
        private DateTime registrationDate;

        public int ID { get => id; set => id = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Email { get => email; set => email = value; }
        public DateTime RegistrationDate { get => registrationDate; set => registrationDate = value; }

        public Customer(int id, string firstName, string lastName, string email, DateTime registrationDate)
        {
            this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
            this.registrationDate = registrationDate;
        }

        public Customer(string firstName, string lastName, string email, DateTime registrationDate)
        {
            this.id = 0;
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
            this.registrationDate = registrationDate;
        }

        public override string? ToString()
        {
            return "Customer( " + id + ", " + firstName + ", " + lastName + ", " + email + ", " + registrationDate + " )";
        }
    }
}
