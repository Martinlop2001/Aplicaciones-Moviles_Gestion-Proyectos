using PerfilPersonalApp.Models;

namespace PerfilPersonalApp.Views;

public partial class ProfileViewPage : ContentPage
{
    private UserProfile _profile;

    public ProfileViewPage(UserProfile profile)
    {
        InitializeComponent();
        _profile = profile;
        LoadProfile();
    }

    private void LoadProfile()
    {
        var initials = GetInitials(_profile.FullName);
        InitialsLabel.Text = initials;

        NameLabel.Text = _profile.FullName;
        AgeLabel.Text = $"{_profile.Age} años";

        EmailLabel.Text = _profile.Email;
        PhoneLabel.Text = string.IsNullOrEmpty(_profile.Phone) ? "No especificado" : _profile.Phone;
        CountryLabel.Text = _profile.Country;

        BioLabel.Text = string.IsNullOrEmpty(_profile.Bio) ? "Sin biografía" : _profile.Bio;

        GenderLabel.Text = _profile.Gender;

        NotificationsLabel.Text = _profile.AcceptsNotifications ? "Activadas" : "Desactivadas";
    }

    private string GetInitials(string fullName)
    {
        if (string.IsNullOrWhiteSpace(fullName))
            return "??";

        var parts = fullName.Trim().Split(' ');
        if (parts.Length == 1)
            return parts[0].Substring(0, Math.Min(2, parts[0].Length)).ToUpper();

        return (parts[0][0].ToString() + parts[parts.Length - 1][0].ToString()).ToUpper();
    }

    private async void OnBackToHomeClicked(object sender, EventArgs e)
    {
        await Navigation.PopToRootAsync();
    }
}
