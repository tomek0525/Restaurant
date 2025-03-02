using System.ComponentModel.DataAnnotations;

namespace EmployeeRegister.Domain
{
    public class Organization //Szervezeti egyseg
        {
            [Key] //PK
            public int Id { get; set; }

            [Required]
            public string Name { get; set; }

            [Required] //rovidites
            public string Abbreviation { get; set; }

            // tobb dolgozo egy egyseghez
            public ICollection<Employee> Employees { get; set; }
        }

    }
