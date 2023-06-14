﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasaryeri.BL.Dtos;

namespace Tasaryeri.BL.Abstract
{
    public interface IProductTransactionsUI
    {
        IEnumerable<ProductDTO> GetAll(int CategoryId);
    }
}
