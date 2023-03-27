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