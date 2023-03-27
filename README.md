# Contact App using .NET MAUI

Aplikasi menyimpan data kontak yang berisi id, nama kontak, perusahaan, email, no. telepon 
kantor, dan no. telepon pribadi.
1. Semua data tersebut tersimpan di dalam basis data SQLite.
2. Buatlah kelas model untuk data tersebut.

isi dari `Models/ContactModel.cs`
```csharp
namespace ContactApp.Models
{
    [Table("contact")]
    public class Contact
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
```

3. Buatlah kelas repository yang berfungsi untuk melakukan operasi CRUD ke dalam basis 
data
