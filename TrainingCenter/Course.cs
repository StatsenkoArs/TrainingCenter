namespace ClassLibrary
{
    public enum Period
    {
        everyday,
        everyweek,
        everymonth,
        everyyear
    }
    public class Course
    {
        static int counter = 0;

        public Course(string trainingCenter, string curator, string name, string description, string requiredPreparation, int durationHours, Period period, bool isActive)
        {
            Id = counter++;
            TrainingCenter = trainingCenter;
            Curator = curator;
            Name = name;
            Description = description;
            RequiredPreparation = requiredPreparation;
            DurationHours = durationHours;
            Period = period;
            IsActive = isActive;
        }

        public int Id { get; }
        public string TrainingCenter { get; set; }
        public string Curator { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string RequiredPreparation { get; set; }
        public int DurationHours { get; set; }
        public Period Period { get; set; }
        public bool IsActive { get; set; }

    }
}
