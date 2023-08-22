namespace ChildrensLearningCenterWeb.ViewModels
{
    public class SpecialistViewModel
    {
        public int SpecialistId { get; set; }
        public string FirstName { get; set; } = null!;
        public string SecondName { get; set; } = null!;
        public string Telephone { get; set; } = null!;
        public int? YearsExperience { get; set; }
        public DateTime BirthdayDate { get; set; }
        public int DirectionId { get; set; }
        public int RoomId { get; set; }
    }
}
