using System;
using System.Linq;
using System.Threading.Tasks;
using CRMSystem.Bot.FormDialogs.Base;
using CRMSystem.Data;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.FormFlow;
using Microsoft.EntityFrameworkCore;

namespace CRMSystem.Bot.FormDialogs
{
    [Serializable]
    public class GetEmailForm: BaseForm<GetEmailForm>
    {
        [NonSerialized]
        private static DbContextOptionsBuilder<CRMDbContext> optionsBuilder = new DbContextOptionsBuilder<CRMDbContext>().UseSqlServer(@"Server=.;Database=CRMSystem;Trusted_Connection=True;");
        
        [Prompt("Please enter Client Name for email.")]
        public string ClientName { get; set; }

        public override IForm<GetEmailForm> BuildForm()
        {
            CRMDbContext db = new CRMDbContext(optionsBuilder.Options);

            async Task onProcessGetEmail(IDialogContext context, GetEmailForm state)
            {
                var customer = db.Customers.Where(c => c.Name == state.ClientName)
                .FirstOrDefault();

                var id = customer.Id;
                var email = customer.Email;
                await context.PostAsync($"Client with ID: {id};" + $" Email: {email}");
            }

            return new FormBuilder<GetEmailForm>()
                .Field(nameof(ClientName))
                .OnCompletion(onProcessGetEmail)
                .Build();
        }
    }
}