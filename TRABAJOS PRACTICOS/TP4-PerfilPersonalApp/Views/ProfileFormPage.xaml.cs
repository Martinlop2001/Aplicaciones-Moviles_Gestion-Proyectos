using PerfilPersonalApp.Models;

namespace PerfilPersonalApp.Views;

public partial class ProfileFormPage : ContentPage
{
    public ProfileFormPage()
    {
        InitializeComponent();
        BirthDatePicker.Date = DateTime.Now.AddYears(-18);
    }

    private async void OnSaveClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(NameEntry.Text))
        {
            await DisplayAlert("Error", "El nombre es obligatorio", "OK");
            return;
        }

        if (string.IsNullOrWhiteSpace(EmailEntry.Text))
        {
            await DisplayAlert("Error", "El email es obligatorio", "OK");
            return;
        }

        if (CountryPicker.SelectedIndex == -1)
        {
            await DisplayAlert("Error", "Selecciona un país", "OK");
            return;
        }

        var profile = new UserProfile
        {
            FullName = NameEntry.Text,
            Email = EmailEntry.Text,
            Phone = PhoneEntry.Text ?? "",
            BirthDate = BirthDatePicker.Date!.Value,
            Country = CountryPicker.SelectedItem?.ToString() ?? "",
            Gender = GenderPicker.SelectedItem?.ToString() ?? "",
            Bio = BioEditor.Text ?? "",
            AcceptsNotifications = NotificationsSwitch.IsToggled
        };

        await Navigation.PushAsync(new ProfileViewPage(profile));
    }
}
