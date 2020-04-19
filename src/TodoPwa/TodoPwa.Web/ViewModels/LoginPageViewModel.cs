﻿using Microsoft.AspNetCore.Http;

namespace TodoPwa.Web.ViewModels
{
    public class LoginPageViewModel : MasterPageViewModel
    {
        public LoginPageViewModel(IHttpContextAccessor httpContextAccessor)
            : base(httpContextAccessor)
        {
        }

        public void Login()
        {
            httpContextAccessor.HttpContext.Response.Cookies.Append("username", Username);
            Context.RedirectToRoute("TodoItemListPage");
        }
    }
}
