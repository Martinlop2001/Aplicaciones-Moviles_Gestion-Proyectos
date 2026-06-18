namespace PerfilPersonalApp.Models
{
    public class UserProfile
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime BirthDate { get; set; }
        public string Country { get; set; }
        public string Bio { get; set; }
        public string Gender { get; set; }
        public bool AcceptsNotifications { get; set; }

        public int Age
        {
            get
            {
                var today = DateTime.Today;
                var age = today.Year - BirthDate.Year;
                if (BirthDate.Date > today.AddYears(-age)) age--;
                return age;
            }
        }
    }
}
