using DotVVM.Framework.Hosting;
using System.Threading.Tasks;

namespace TodoPwa.Web.Presenters
{
    public class OnlineStatusCheckPresenter : IDotvvmPresenter
    {
        public async Task ProcessRequest(IDotvvmRequestContext context)
        {
            context.HttpContext.Response.StatusCode = 200;
        }
    }
}