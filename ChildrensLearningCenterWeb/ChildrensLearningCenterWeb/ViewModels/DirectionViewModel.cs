namespace ChildrensLearningCenterWeb.ViewModels
{
    public class DirectionViewModel
    {
        public int DirectionId { get; set; }
        public string Title { get; set; } = null!;
        public string Purpose { get; set; } = null!;
        public int Price { get; set; }
        public string? Description { get; set; }
    }
}
