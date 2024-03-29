﻿using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IChildrenRepository
    {
        List<Children> GetAll();
        Children? Get(int id);
        void Create(Children children);
        void Update(int id, Children children);
        void Delete(int id);

        void StroedProcedureCreate(string clientFN, string clientSn, string clientPhone, string clientEmail, DateOnly clientBIrthdayDate, string childFN, string childSN, DateOnly childBirtdayDate);
    }
}
