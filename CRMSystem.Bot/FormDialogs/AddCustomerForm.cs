using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using CRMSystem.Bot.Common;
using CRMSystem.Bot.FormDialogs.Base;
using CRMSystem.Models;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.FormFlow;

namespace CRMSystem.Bot.FormDialogs
{
    [Serializable]
    public class AddCustomerForm : BaseForm<AddCustomerForm>
    {
        [Required]
        [MaxLength(100)]
        [Prompt("Please enter Client Name.")]
        public string Name { get; set; }

        [Prompt("Please enter Client Status.")]
        public Status Status { get; set; }

        [MaxLength(20)]
        [Prompt("Please enter Client phone number.")]
        public string Phone { get; set; }

        [MaxLength(40)]
        [Prompt("Please enter Client Email.")]
        public string Email { get; set; }

        public override IForm<AddCustomerForm> BuildForm()
        {

            async Task onProcessAddCustomer(IDialogContext context, AddCustomerForm state)
            {
                var db = GetDatabase.GetContext();

                Customer customer = new Customer
                {
                    Name = state.Name,
                    Phone = state.Phone,
                    Status = state.Status,
                    Email = state.Email,
                    AddedOn = DateTime.Now
                };

                db.Add(customer);
                db.SaveChanges();
            }

            return new FormBuilder<AddCustomerForm>()
                .Field(nameof(Name))
                .Field(nameof(Phone))
                .Field(nameof(Email))
                .Field(nameof(Status))
                .OnCompletion(onProcessAddCustomer)
                .Build();
        }

    }
}