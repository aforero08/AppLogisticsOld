using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AppLogistics.Models
{
    public class Employee
    {

        public int Id { get; set; }
        public long Document { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BornDate { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime RetirementDate { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string MobilePhone { get; set; }
        public string Email { get; set; }
        public MaritalStatus MaritalStatus { get; set; }
        public string EmergencyContact { get; set; }
        public string EmergencyContactPhone { get; set; }
        public EPS Eps { get; set; }
        public AFP Afp { get; set; }
        public BranchOffice BranchOffice { get; set; }
        public DbSet<EmployeeDocuments> Documents { get; set; }

    }
}