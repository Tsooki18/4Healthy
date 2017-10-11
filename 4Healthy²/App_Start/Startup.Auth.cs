using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Google;
using Owin;
using _4Healthy_.Models;

namespace _4Healthy_
{
    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            // Configurar o contexto do banco de dados na criação de usuário
            app.CreatePerOwinContext(ApplicationDbContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
            app.CreatePerOwinContext<ApplicationSignInManager>(ApplicationSignInManager.Create);

            // Permitindo a aplicação o uso de cookies para armazenamento de dados
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Conta/Login"),
                Provider = new CookieAuthenticationProvider
                {
                    // Permite a validação de segurança quando um usuário faz o login.
                    // Fator de segurança utilizado quando o usuário redefine sua senha.  
                    OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<ApplicationUserManager, ApplicationUser>(
                        validateInterval: TimeSpan.FromMinutes(30),
                        regenerateIdentity: (manager, user) => user.GenerateUserIdentityAsync(manager))
                }
            });            
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            app.UseTwoFactorSignInCookie(DefaultAuthenticationTypes.TwoFactorCookie, TimeSpan.FromMinutes(5));

            // Permite a aplicação relembrar o segundo fator de login de verificaçao assim como o telefone e email.
            // Similar à opção "Remember Me" no menu de LogIn.
            app.UseTwoFactorRememberBrowserCookie(DefaultAuthenticationTypes.TwoFactorRememberBrowserCookie);

        }
    }
}