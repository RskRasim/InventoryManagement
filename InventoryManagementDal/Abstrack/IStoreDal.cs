﻿using InventoryManagementEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICompanyAddressesServices.Abstrack
{
    public interface IStoreDal
    {
        List<Store> GetAll();
        List<Store> GetAllById(int CompanyId);
        Store Get(int storeId);
        void Add(Store store);
        void Delete(int storeId);
        void Update(Store store);

    }
}
