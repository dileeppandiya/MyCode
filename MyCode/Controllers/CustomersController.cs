using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using MyCode.Models;
using MyCode.Repo;

namespace MyCode.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class CustomersController : ApiController
    {


        private CustomerRepo contactRepository;
        private ApplicationDbContext db = new ApplicationDbContext();


        public CustomersController()
        {
            this.contactRepository = new CustomerRepo();
        }

        // GET: api/Customers
        public IHttpActionResult GetCustomers()
        {
            var result = contactRepository.getAllCutomers();

            return Ok(result);

        }

        [ResponseType(typeof(Customer))]
        // GET: api/Customers
        public IHttpActionResult PostCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            contactRepository.AddCutomer(customer);

            return Ok();

        }


        [ResponseType(typeof(Customer))]
        // DELETE: api/Customers/5
        public IHttpActionResult DeleteCustomer(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = contactRepository.RemoveCutomer(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok();

        }

        [ResponseType(typeof(void))]
        public IHttpActionResult PutCustomer(int id, Customer customer)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != customer.Id)
            {
                return BadRequest();
            }

            var result = contactRepository.UpdateCustomer(id, customer);
            if (result == null)
            {
                return NotFound();
            }
            return StatusCode(HttpStatusCode.NoContent);

        }
        
        
        // GET: api/Customers/5
        [ResponseType(typeof(Customer))]
        public IHttpActionResult GetCustomer(int id)
        {
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        
      

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

       
    }
}