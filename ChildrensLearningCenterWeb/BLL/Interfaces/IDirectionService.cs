using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IDirectionService
    {
        List<Direction> GetAll();

        void StoredPeocedure(int price);
    }
}
