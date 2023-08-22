namespace ChildrensLearningCenterWeb.ViewModels
{
    public class TwoTablesViewModel
    {
        public int SpecialistId { get; set; }
        public string FirstName { get; set; } = null!;
        public string SecondName { get; set; } = null!;
        public DateTime BirthdayDate { get; set; }
        public int DirectionId { get; set; }
        public string? Title { get; set; }
        public int Price { get; set; }
    }
}
