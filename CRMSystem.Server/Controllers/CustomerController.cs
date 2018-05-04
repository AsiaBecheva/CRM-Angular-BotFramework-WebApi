using System;
using System.Linq;
using CRMSystem.Data;
using CRMSystem.Models;
using CRMSystem.Services.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRMSystem.Server.Controllers
{
    //[Authorize(Roles = "Employees", Policy = "OnlyEmployees")]
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        private readonly CRMDbContext db;

        public CustomerController(CRMDbContext db)
        {
            this.db = db;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var customer = db.Customers
                .Where(x => x.Id == id)
                .FirstOrDefault();

            if (customer == null)
            {
                return this.NotFound("There is no customer with such ID!");
            }

            return this.Ok(customer);
        }


        [HttpPost]
        public IActionResult Post([FromBody]CustomerServiceModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }

            Customer customer = new Customer
            {
                Name = model.Name,
                Email = model.Email,
                Phone = model.Phone,
                Status = model.Status,
                AddedOn = DateTime.Now
            };

            this.db.Customers.Add(customer);
            this.db.SaveChanges();

            return this.Created(this.Url.ToString(), customer);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]CustomerServiceModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }

            var customerForUpdate = this.db.Customers.Where(x => x.Id == id).FirstOrDefault();

            if (customerForUpdate == null)
            {
                return BadRequest("There is no customer with such ID!");
            }

            customerForUpdate.Email = model.Email;
            customerForUpdate.Name = model.Name;
            customerForUpdate.Phone = model.Phone;
            customerForUpdate.Status = model.Status;

            this.db.Customers.Update(customerForUpdate);
            this.db.SaveChanges();

            return this.Ok(customerForUpdate);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var customerForDelete = this.db.Customers.Where(x => x.Id == id).FirstOrDefault();

            if (customerForDelete == null)
            {
                return this.BadRequest();
            }

            this.db.Customers.Remove(customerForDelete);

            return this.Ok("Customer was deleted!");
        }
    }
}
