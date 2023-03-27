namespace ContactApp.Pages;

public partial class ContactsPage : ContentPage
{
    public ContactsPage()
    {
        InitializeComponent();
        BindingContext = new ContactsViewModel();
    }
}
