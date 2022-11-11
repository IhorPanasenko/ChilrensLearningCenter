namespace ChildrensLearningCenterWeb.ViewModels
{
    public class ClassViewModel
    {
        public int ClassId { get; set; }
        public string DayOfWeek { get; set; } = null!;
        public TimeSpan Time { get; set; }
        public int SpecialistId { get; set; }
        public int ChildId { get; set; }
    }
}
