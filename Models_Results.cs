namespace RaceDayMVC.Models;

public class Result
{
    public int ResultId { get; set; }

    public int ParticipantId { get; set; }

    public int EventId { get; set; }

    public string FinishTime { get; set; }

    public int Position { get; set; }
}
