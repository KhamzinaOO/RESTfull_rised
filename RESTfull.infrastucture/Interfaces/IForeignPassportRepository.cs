﻿using RESRTfull.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESTfull.Infrastructure.Interfaces
{
    public interface IForeignPassportRepository : IBaseRepository<DocForeignPassport>
    {
        Task<DocForeignPassport> GetByNumber(string number);
    }
}