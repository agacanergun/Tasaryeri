﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasaryeri.DAL.Entities;

namespace Tasaryeri.DAL.EntityFramework.Abstract
{
    public interface IEfSalerLoginDAL
    {
        Saler SalerLogin(Saler saler);
        bool SalerRegister(Saler saler);

    }
}
