using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using TodoPwa.BL.Facades;

namespace TodoPwa.Web.ViewModels
{
    public class LoginPageViewModel : MasterPageViewModel
    {
        private readonly ITokenFacade tokenFacade;

        public LoginPageViewModel(
            IHttpContextAccessor httpContextAccessor,
            ITokenFacade tokenFacade)
            : base(httpContextAccessor)
        {
            this.tokenFacade = tokenFacade;
        }
        public string Title { get; set; } = "Login";
        public async Task Login()
        {
            httpContextAccessor.HttpContext.Response.Cookies.Append("username", Username);

            if (Username != null && Token != null)
            {
                await tokenFacade.InsertTokenAsync(Username, Token);
            }

            Context.RedirectToRoute("TodoItemListPage");
        }
    }
}
