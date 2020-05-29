using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProjetoEstagioSupDDD.MVC.Startup))]
namespace ProjetoEstagioSupDDD.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
