using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using CRMSystem.Bot.FormDialogs.Base;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.FormFlow;

namespace CRMSystem.Bot.FormDialogs
{
    [Serializable]
    public class GetInfoForm : BaseForm<GetInfoForm>
    {
        [Prompt("Please enter Client Name")]
        [Pattern(@"(?<!\d)\d{20}(?!\d)")]
        public string ClientName { get; set; }

        public override IForm<GetInfoForm> BuildForm()
        {
            return new FormBuilder<GetInfoForm>()
               .Field(nameof(ClientName))
               .OnCompletion(OnProcessGetInfo)
               .Build();
        }

        private async Task OnProcessGetInfo(IDialogContext context, GetInfoForm state)
        {
            await context.PostAsync($"The client {ClientName} has multiple supermarkets.");
        }
    }
}