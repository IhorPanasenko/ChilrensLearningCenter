using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IChildrenService
    {
        List<Children> GetAll();
        Children? Get(int id);
        void Create(Children children);
        void Update(int id, Children children);
        void Delete(int id);
    }
}
