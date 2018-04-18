﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using CRMSystem.Bot.Common;
using CRMSystem.Bot.FormDialogs;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.FormFlow;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;

namespace CRMSystem.Bot.Dialogs
{
    [LuisModel("5a7a50bb-eb63-441e-a497-5339339eda70", "2cfe175785d1493da0345f5521d329c0")]
    [Serializable]
    public class LUISDialog : LuisDialog<object>
    {
        private CommonCallbacks callback;
        public LUISDialog()
        {
            this.callback = new CommonCallbacks();
        }

        #region Default Intents

        [LuisIntent("None")]
        public async Task None(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("I'm sorry I don't know what you mean.");
            context.Wait(MessageReceived);
        }

        [LuisIntent("greetings")]
        public async Task Greetings(IDialogContext context, LuisResult result)
        {
            string username = string.Empty;
            if (context.Activity.From.Name != null)
            {
                username = context.Activity.From.Name;
            }
            await context.PostAsync($"Hello {username}");
            context.Wait(MessageReceived);
        }

        [LuisIntent("howareyou")]
        public async Task HowAreYou(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Thanks! I am fine. How may I help You?");
            context.Wait(MessageReceived);
        }

        [LuisIntent("goodbye")]
        public async Task Goodbye(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Goodbye!");
            context.Wait(MessageReceived);
        }

        [LuisIntent("thanks")]
        public async Task Thanks(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Thank you!");
            context.Wait(MessageReceived);
        }

        [LuisIntent("botquestions")]
        public async Task BotQuestions(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("I am just a bot. I cannot answear You!");
            context.Wait(MessageReceived);
        }

        #endregion

        #region Intents

        [LuisIntent("getinfo")]
        public async Task GetInfo(IDialogContext context, LuisResult result)
        {
            GetInfoForm getInfoForm = new GetInfoForm();
            var form = new FormDialog<GetInfoForm>(new GetInfoForm(), new BuildFormDelegate<GetInfoForm>(getInfoForm.BuildForm), FormOptions.PromptInStart);
            context.Call<GetInfoForm>(form, callback.CallbackGlobal); 
        }

        [LuisIntent("getstatus")]
        public async Task GetStatus(IDialogContext context, LuisResult result)
        {
            GetStatusForm getStatusForm = new GetStatusForm();
            var form = new FormDialog<GetStatusForm>(new GetStatusForm(), new BuildFormDelegate<GetStatusForm>(getStatusForm.BuildForm), FormOptions.PromptInStart);
            context.Call<GetStatusForm>(form, callback.CallbackGlobal);
        }

        [LuisIntent("getphone")]
        public async Task GetPhone(IDialogContext context, LuisResult result)
        {
            GetPhoneForm getPhoneForm = new GetPhoneForm();
            var form = new FormDialog<GetPhoneForm>(new GetPhoneForm(), new BuildFormDelegate<GetPhoneForm>(getPhoneForm.BuildForm), FormOptions.PromptInStart);
            context.Call<GetPhoneForm>(form, callback.CallbackGlobal);
        }

        [LuisIntent("getemail")]
        public async Task GetEmail(IDialogContext context, LuisResult result)
        {
            GetEmailForm getEmailForm = new GetEmailForm();
            var form = new FormDialog<GetEmailForm>(new GetEmailForm(), new BuildFormDelegate<GetEmailForm>(getEmailForm.BuildForm), FormOptions.PromptInStart);
            context.Call<GetEmailForm>(form, callback.CallbackGlobal);
        }

        #endregion
    }
}