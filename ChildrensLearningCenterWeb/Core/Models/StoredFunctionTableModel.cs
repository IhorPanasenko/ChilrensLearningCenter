using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace ChildrensLearningCenterWeb.ViewModels
{
    [Keyless]
    public class StoredFunctionTableModel
    {
        public StoredFunctionTableModel()
        {
            Classes = new HashSet<Class>();
        }
        public int SpecialistID { get; set; }
        public int DirectionID { get; set; }

        public virtual ICollection<Class> Classes { get; set; }

    }
}
