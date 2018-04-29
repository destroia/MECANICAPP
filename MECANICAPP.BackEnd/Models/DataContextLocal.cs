﻿using MECANICAPP.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MECANICAPP.BackEnd.Models
{
    public class DataContextLocal : DataContext
    {
        public System.Data.Entity.DbSet<MECANICAPP.Domain.Category> Categories { get; set; }

        public System.Data.Entity.DbSet<MECANICAPP.Domain.Item> Items { get; set; }
    }
}