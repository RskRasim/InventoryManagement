﻿using InventoryManagementEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementInterfaces
{
   public interface IProductService
    {

        List<Product> GetAll();
        Product Get(int productId);
        void Add(Product product);
        void Delete(int Id);
        void Update(Product product);

    }
}
