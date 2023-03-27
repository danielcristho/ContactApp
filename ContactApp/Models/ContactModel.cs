using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace ContactApp.Models
{
    [Table("contact")]
    public class ContactModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        public string Email { get; set; }
        public string CompanyPhone { get; set; }
        public string PhoneNumber { get; set; }
    }
}