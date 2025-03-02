using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeRegister.Domain
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string PhoneNumber { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        //nullable, mert nem mindenki rendelkezik felettessel
        public int? SupervisorId { get; set; }
        public Employee? Supervisor { get; set; }

        //nem nullable, mert kötelező lehet
        public int OrganizationalUnitId { get; set; }
        public Organization OrganizationalUnit { get; set; }
    }
}
