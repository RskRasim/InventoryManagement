using InventoryManagementEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementDal.Abstrack
{
    public interface IProductImgDal
    {
        void Add(ProductImg productImg);
        void Delete(int Id);
        void Update(ProductImg productImg);
        List<ProductImg> GetAll();
        ProductImg Get(int Id);


    }
}
