﻿using AirConditionerShop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirConditionerShop.BLL.IServices
{
    public interface ISupplierService
    {
        List<SupplierCompany> GetAllSuppliers();
    }
}
