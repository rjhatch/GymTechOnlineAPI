namespace GymTechOnlineAPI.Models
{
    public class GymTechOnlineDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string PeopleCollectionName { get; set; } = null!;
        public string ScheduleCollectionName { get; set; } = null!;
        public string PaymentsCollectionName { get; set; } = null!;
        public string FormatCollectionName { get; set; } = null!;

    }
}
