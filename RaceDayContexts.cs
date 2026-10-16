using Microsoft.EntityFrameworkCore;

public class RaceDayContext : DbContext
{
    public RaceDayContext(DbContextOptions<RaceDayContext> options) : base(options) {}

    public DbSet<Organiser> Organisers { get; set; }
    public DbSet<Participant> Participants { get; set; }
    public DbSet<Event> Events { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Enrolment> Enrolments { get; set; }
    public DbSet<Result> Results { get; set; }
}
