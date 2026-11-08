namespace RaceDayMVC.ViewModels;

public class ProfileViewModel
{
    public string Name { get; set; }

    public string Surname { get; set; }

    public string Email { get; set; }

    public IFormFile ProfilePicture { get; set; }

    public string ProfilePictureUrl { get; set; }
}
