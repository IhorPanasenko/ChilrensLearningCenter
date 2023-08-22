namespace ChildrensLearningCenterWeb.ViewModels
{
    public class ChildrenViewModel
    {
       public int ChildId { get; set; }
        public string FirstName { get; set; } = null!;
        public string? SecondName { get; set; }
        public DateTime BirthdayDate { get; set; }
        public int ClientId { get; set; }
    //    public string ClientFirstName { get; set; } = null!;
    //    public string? ClientSecondName { get; set; }
    //    public string TelephoneNumber { get; set; } = null!;
    //    public string? Email { get; set; }
    //    public DateTime? ClientBirthdayDate { get; set; }
    }
}
