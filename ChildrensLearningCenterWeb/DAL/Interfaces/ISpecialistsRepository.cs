﻿using ChildrensLearningCenterWeb.ViewModels;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ISpecialistsRepository
    {
        List<Specialist> GetAll();

        string ScalarFunction();

        List<StoredFunctionTableModel> TableFunction();

        List<Specialist> TwoTables();
    }
}
