using DotVVM.Framework.Configuration;
using DotVVM.Framework.ResourceManagement;
using Microsoft.Extensions.DependencyInjection;
using TodoPwa.Web.Presenters;

namespace TodoPwa.Web
{
    public class DotvvmStartup : IDotvvmStartup, IDotvvmServiceConfigurator
    {
        // For more information about this class, visit https://dotvvm.com/docs/tutorials/basics-project-structure
        public void Configure(DotvvmConfiguration config, string applicationPath)
        {
            ConfigureRoutes(config, applicationPath);
            ConfigureControls(config, applicationPath);
            ConfigureResources(config, applicationPath);
        }

        private void ConfigureRoutes(DotvvmConfiguration config, string applicationPath)
        {
            config.RouteTable.Add("Default", "", "Views/LoginPage.dothtml");
            config.RouteTable.Add("TodoItemListPage", "todo-items", "Views/TodoItemListPage.dothtml");
            config.RouteTable.Add("TodoItemNewPage", "todo-item-new", "Views/TodoItemNewPage.dothtml");
            config.RouteTable.Add("OnlineStatusCheckPresenter", "online-status-check", serviceProvider => new OnlineStatusCheckPresenter());
        }

        private void ConfigureControls(DotvvmConfiguration config, string applicationPath)
        {
            // register code-only controls and markup controls
        }

        private void ConfigureResources(DotvvmConfiguration config, string applicationPath)
        {
            config.Resources.Register("app-js", new ScriptResource
            {
                Location = new FileResourceLocation("wwwroot/app.js")
            });
        }

        public void ConfigureServices(IDotvvmServiceCollection options)
        {
            options.AddDefaultTempStorages("temp");
        }
    }
}
