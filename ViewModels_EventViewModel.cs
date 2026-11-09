namespace RaceDayMVC.ViewModels;

public class EventViewModel
{
    public string Name { get; set; }

    public string Description { get; set; }

    public DateTime Date { get; set; }

    public string Location { get; set; }

    public double Distance { get; set; }

    public string EventType { get; set; }

    public IFormFile BannerImage { get; set; }

    public string BannerUrl { get; set; }
}
