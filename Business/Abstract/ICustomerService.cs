using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICustomerService : IEntityService<Customer>
    {       
        IDataResult<Customer> GetByUserId(int userId);
        IDataResult<Customer> GetByCompanyName(string companyName);
        IDataResult<List<CustomerDetailDto>> GetCustomerDetails();
    }
}