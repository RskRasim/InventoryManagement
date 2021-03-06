﻿using InventoryManagementDal.Abstrack;
using InventoryManagementEntity;
using InventoryManagementInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementBll.Concrete
{
    public class CustomerManager : ICustomerService
    {
        private ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public void Add(Customer customer)
        {
            _customerDal.Add(customer);
        }

        public void Delete(int Id, int companyId)
        {
            _customerDal.Delete(Id,companyId);
        }

        public Customer Get(int Id, int companyId)
        {
            return _customerDal.Get(Id,companyId);
        }

        public List<Customer> GetAll(int Id)
        {
            return _customerDal.GetAll(Id);
        }

        public List<Customer> GetAllById(int companyId)
        {
            return _customerDal.GetAllById(companyId);
        }

        public void Update(Customer customer)
        {
            _customerDal.Update(customer);
        }

        void ICustomerService.Add(Customer customer)
        {
            throw new NotImplementedException();
        }

        void ICustomerService.Delete(int Id, int companyId)
        {
            throw new NotImplementedException();
        }

        Customer ICustomerService.Get(int Id, int companyId)
        {
            throw new NotImplementedException();
        }

        List<Customer> ICustomerService.GetAll(int Id)
        {
            throw new NotImplementedException();
        }

        List<Customer> ICustomerService.GetAllById(int companyId)
        {
            throw new NotImplementedException();
        }

        void ICustomerService.Update(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
