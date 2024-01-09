using Contacts.Models;
using Contact = Contacts.Models.Contacts;
namespace Contacts.Views;

[QueryProperty(nameof(ContactId), "id")]
public partial class EditContactsPage : ContentPage
{
	private Contact contact;
	public EditContactsPage()
	{
		InitializeComponent();
	}
	public int ContactId { 
		set
		{
			contact = ContactsRepository.getContactById(value);
			if(contact != null)
			{
                ContactCtrl.Name = contact.Name;
				ContactCtrl.Email = contact.Email;
				ContactCtrl.Phone = contact.PhoneNumber;
				ContactCtrl.Address = contact.Address;
            }
		} 
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
		Shell.Current.GoToAsync("..");
    }

    private void btnUpdate_Clicked(object sender, EventArgs e)
    {
		contact.Name = ContactCtrl.Name;
		contact.Email = ContactCtrl.Email;
		contact.Address = ContactCtrl.Address;
		contact.PhoneNumber = ContactCtrl.Phone;
		ContactsRepository.UpdateContact(contact, contact.ContactId);
		Shell.Current.GoToAsync("..");
    }

    private void ContactCtrl_OnError(object sender, string e)
    {
		DisplayAlert("Error", e, "Ok");
    }
}