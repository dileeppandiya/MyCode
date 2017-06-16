using MyCode.DTO;
using MyCode.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyCode.Repo
{
    public class CustomerRepo
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public IEnumerable<CustomerDTO> getAllCutomers()
        {
            var customerData = db.Customers;
            return fillObject(customerData);

        }

        private List<CustomerDTO> fillObject(dynamic Data)
        {
            List<CustomerDTO> customers = new List<CustomerDTO>();

            foreach (var item in Data)
            {   var customer = new CustomerDTO();
                customer.FirstName = item.FirstName;
                customer.LastName = item.LastName;
                customers.Add(customer);
            }
            return customers;
        }
    }
}