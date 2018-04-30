using CRMSystem.Data;
using CRMSystem.Data.Repository;
using CRMSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Text;

namespace CRMSystem.Server.Controllers
{
    //[Authorize(Roles = "Employees", Policy = "OnlyEmployees")]
    ///[Route("api/[controller]")]
    public class CustomerController : Controller
    {
        private readonly IUnitOfWork db;

        public CustomerController(IUnitOfWork db)
        {
            this.db = db;
        }

        [HttpGet]
        [Route("api/Customer/Email")]
        public IActionResult Email([FromQuery]string nameForEmail)
        {
            if (string.IsNullOrEmpty(nameForEmail))
            {
                return this.BadRequest();
            }

            var customer = TakeCustomer(nameForEmail);

            if (customer == null)
            {
                return this.NotFound("There is no email address for this customer!");
            }

            var emailAddress = customer.Email;

            return this.Ok(emailAddress);
        }

        [HttpGet]
        [Route("api/Customer/Status")]
        public IActionResult Status([FromQuery]string nameForStatus)
        {
            if (string.IsNullOrEmpty(nameForStatus))
            {
                return this.BadRequest();
            }

            var customer = TakeCustomer(nameForStatus);

            if (customer == null)
            {
                return this.NotFound("There is no status for this customer!");
            }

            var status = customer.Status;

            return this.Ok(status);
        }

        [HttpGet]
        [Route("api/Customer/Phone")]
        public IActionResult Phone([FromQuery]string nameForPhone)
        {
            if (string.IsNullOrEmpty(nameForPhone))
            {
                return this.BadRequest();
            }

            var customer = TakeCustomer(nameForPhone);

            if (customer == null)
            {
                return this.NotFound("There is no phone number for this customer!");
            }

            var phoneNumber = customer.Phone;

            return this.Ok(phoneNumber);
        }

        [HttpGet]
        [Route("api/Customer/Info")]
        public IActionResult Info([FromQuery]string nameForInfo)
        {
            if (string.IsNullOrEmpty(nameForInfo))
            {
                return this.BadRequest();
            }

            var customer = TakeCustomer(nameForInfo);

            if (customer == null)
            {
                return this.NotFound("There is no information for this customer!");
            }

            StringBuilder info = new StringBuilder();
            info.AppendLine($"ID: {customer.Id};  ");
            info.AppendLine($"Phone: {customer.Phone};  ");
            info.AppendLine($"Email: {customer.Email};  ");
            info.AppendLine($"Added On: {customer.AddedOn};  ");
            info.AppendLine($"Status: {customer.Status};  ");
            
            return this.Ok(info);
        }

        private Customer TakeCustomer(string name)
        {
            var customer = this.db.Customers.All()
                .Where(c => c.Name == name)
                .FirstOrDefault();

            return customer;
        }
    }
}
