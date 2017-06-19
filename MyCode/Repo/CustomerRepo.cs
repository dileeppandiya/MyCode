using MyCode.DTO;
using MyCode.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
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


        public void AddCutomer(Customer customer)
        {
            db.Customers.Add(customer);
            db.SaveChanges();
        }


        public Customer RemoveCutomer(int id)
        {
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return null;
            }

            db.Customers.Remove(customer);
            db.SaveChanges();

            return customer;
        }


        public bool? UpdateCustomer(int id, Customer customer)
        {
            db.Entry(customer).State = System.Data.Entity.EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            return true;
        }

        

        private bool CustomerExists(int id)
        {
            return db.Customers.Count(e => e.Id == id) > 0;
        }



        private List<CustomerDTO> fillObject(dynamic Data)
        {
            List<CustomerDTO> customers = new List<CustomerDTO>();

            foreach (var item in Data)
            {   var customer = new CustomerDTO();
                customer.FirstName = item.FirstName;
                customer.LastName = item.LastName;
                customer.Id = item.Id;
                customers.Add(customer);
            }
            return customers;
        }
    }
}