﻿using DotVVM.Framework.ViewModel;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using TodoPwa.BL.Models;

namespace TodoPwa.Web.ViewModels
{
    public class MasterPageViewModel : DotvvmViewModelBase
    {
        protected readonly IHttpContextAccessor httpContextAccessor;

        public string Username { get; set; }

        public bool IsPageOffline { get; set; } = false;
        public string Token { get; set; }
        public PushNotificationContentModel PushNotificationContent { get; set; } = new PushNotificationContentModel();

        public string CurrentRoute => Context.Route.RouteName;
        public MasterPageViewModel(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        public override async Task Init()
        {
            await base.Init();

            if (!Context.IsPostBack)
            {
                if (httpContextAccessor.HttpContext.Request.Cookies.TryGetValue("username", out var username))
                {
                    Username = username;
                }
            }
        }

        public void ClearPushNotificationContent()
        {
            PushNotificationContent = new PushNotificationContentModel();
        }
    }
}
