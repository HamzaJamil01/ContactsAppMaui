using Contacts.Models;

namespace Contacts.Views;

public partial class AddContactsPage : ContentPage
{
	public AddContactsPage()
	{
		InitializeComponent();
	}

    private void ContactCtrl_OnSave(object sender, EventArgs e)
    {
        ContactsRepository.AddContact(new Models.Contacts
        {
            Name = ContactCtrl.Name,
            Email = ContactCtrl.Email,
            Address = ContactCtrl.Address,
            PhoneNumber = ContactCtrl.Phone
        });
        Shell.Current.GoToAsync($"//{nameof(ContactsPage)}");
    }

    private void ContactCtrl_OnCancel(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync($"//{nameof(ContactsPage)}");
    }

    private void ContactCtrl_OnError(object sender, string e)
    {
        DisplayAlert("Error", e, "Ok");
    }
}