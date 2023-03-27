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

    isi dari `Repositories/ContactRepositories.cs`. Dimana kelas ini berisi atribut yang digunakan untuk define lokasi dari databasenya, kemudian berisi method dalam membuat database.

    ```csharp
    using SQLite;
    using ContactApp.Models; // Import ContactModel

    namespace ContactApp
    {
        public class ContactRepository
        {
            string _dbPath;
            public string StatusMessage { get; set; }
            private SQLiteAsyncConnection connection;

            private async Task Init()
            {
                if (connection != null)
                    return;

                connection = new SQLiteAsyncConnection(_dbPath);
                await connection.CreateTableAsync<Models.ContactModel>();
            }

            public ContactRepository(string dbPath)
            {
                _dbPath = dbPath;
            }

            public async Task AddNewContact(Models.ContactModel contact)
            {
                int result = 0;
                try
                {
                    await Init();

                    if (contact == null)
                        throw new Exception("Invalid Contact");

                    result = await connection.InsertAsync(contact);
                    StatusMessage = string.Format("{0} record(s) added (Name: {1})", result, contact.Name);
                }
                catch (Exception ex)
                {
                    StatusMessage = string.Format("Failed to add {0}. Error: {1}", contact.Name, ex.Message);
                }
            }

            public async Task<List<Models.ContactModel>> GetAllContact()
            {
                try
                {
                    await Init();
                    return await connection.Table<Models.ContactModel>().ToListAsync();
                }
                catch (Exception ex)
                {
                    StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
                }

                return new List<Models.ContactModel>();
            }

            public void UpdateContact(Models.ContactModel contact)
            {

            }
        }
    }
    ```
    
Aplikasi terdiri dari 2 halaman, yaitu:
1. Halaman utama, yang berisi daftar kontak yang telah tersimpan di basis data dan satu 
button untuk menambahkan kontak.
    - Daftar kontak ditampilkan namanya saja dalam bentuk list/collecttion view.
    - Buton ditambahkan di bagian bawah setelah daftar kontak.
    - Apabila salah satu kontak diklik maka akan membuka halaman detil kontak.
2. Halaman detail kontak, yang berisi detail dari kontak yang diklik.
    - Data yang ditampilkan adalah nama, perusahaan, email, no. telepon kantor, dan nomor telepon pribadi.
    - Di dalam halaman ini pengguna dapat melakukan edit data kemudian 
      menyimpannya ataupun menghapus kontak tersebut. Tambahkan 2 button 
      (Save, dan Delete) untuk mengimplementasikan fitur tersebut.
