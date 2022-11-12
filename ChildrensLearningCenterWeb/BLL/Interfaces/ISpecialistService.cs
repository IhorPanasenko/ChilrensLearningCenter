using ChildrensLearningCenterWeb.ViewModels;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ISpecialistService
    {
        List<Specialist> GetAll();

        string ScalarFunction();

        List<StoredFunctionTableModel> TableFunction();
    }
}
