using Contacts.Models;
using System.Collections.ObjectModel;
using Contact = Contacts.Models.Contacts;
namespace Contacts.Views;

public partial class ContactsPage : ContentPage
{
	public ContactsPage()
	{
		InitializeComponent();
    }

    private async void listContacts_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if(listContacts.SelectedItem != null)
        {
            await Shell.Current.GoToAsync($"{nameof(EditContactsPage)}?id={((Contact)listContacts.SelectedItem).ContactId}");
        }  
    }
    private void listContacts_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        listContacts.SelectedItem = null;
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        SearchBar.Text = string.Empty;
        LoadContacts(); 
    }

    private void btnAdd_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(AddContactsPage));
    }

    private void MenuItem_Clicked(object sender, EventArgs e)
    {
        var menuItem = sender as MenuItem;
        var contact = menuItem.CommandParameter as Contact;
        ContactsRepository.RemoveContact(contact.ContactId);
        LoadContacts();
    }
    private void LoadContacts()
    {
        var contacts = new ObservableCollection<Contact>(ContactsRepository.getList());
        listContacts.ItemsSource = contacts;
    }

    private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
    {
        var contacts = new ObservableCollection<Contact>(ContactsRepository.SearchContacts(((SearchBar)sender).Text));
        listContacts.ItemsSource = contacts;
    }
}