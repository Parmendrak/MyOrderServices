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
using MyOrderServices.Models;

namespace MyOrderServices.Controllers
{
    public class CustomerDetailsController : ApiController
    {
        private MyOrderServicesContext db = new MyOrderServicesContext();

        // GET: api/CustomerDetails
        public IQueryable<CustomerDetail> GetCustomerDetails()
        {
            return db.CustomerDetails;
        }

        // GET: api/CustomerDetails/5
        [ResponseType(typeof(CustomerDetail))]
        public IHttpActionResult GetCustomerDetail(int id)
        {
            CustomerDetail customerDetail = db.CustomerDetails.Find(id);
            if (customerDetail == null)
            {
                return NotFound();
            }

            return Ok(customerDetail);
        }

        // PUT: api/CustomerDetails/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCustomerDetail(int id, CustomerDetail customerDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != customerDetail.CustomerId)
            {
                return BadRequest();
            }

            db.Entry(customerDetail).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerDetailExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/CustomerDetails
        [ResponseType(typeof(CustomerDetail))]
        public IHttpActionResult PostCustomerDetail(CustomerDetail customerDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CustomerDetails.Add(customerDetail);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = customerDetail.CustomerId }, customerDetail);
        }

        // DELETE: api/CustomerDetails/5
        [ResponseType(typeof(CustomerDetail))]
        public IHttpActionResult DeleteCustomerDetail(int id)
        {
            CustomerDetail customerDetail = db.CustomerDetails.Find(id);
            if (customerDetail == null)
            {
                return NotFound();
            }

            db.CustomerDetails.Remove(customerDetail);
            db.SaveChanges();

            return Ok(customerDetail);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CustomerDetailExists(int id)
        {
            return db.CustomerDetails.Count(e => e.CustomerId == id) > 0;
        }
    }
}