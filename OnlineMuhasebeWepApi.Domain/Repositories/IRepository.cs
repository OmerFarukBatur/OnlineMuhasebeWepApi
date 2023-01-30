﻿using Microsoft.EntityFrameworkCore;
using OnlineMuhasebeWepApi.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMuhasebeWepApi.Domain.Repositories
{
    public interface IRepository<T> where T : Entity
    {
        void SetDbContextInstance(DbContext context);
        DbSet<T> Entity { get; set; }
    }
}
