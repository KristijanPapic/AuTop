using AuTOP.Model;
using AuTOP.Model.Common;
using AuTOP.Repository;
using AuTOP.Repository.Common;
using AuTOP.Service.Common;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace AuTOP.WebAPI.Provider
{
    public class OauthProvider : OAuthAuthorizationServerProvider
    {
        public OauthProvider()
        {
        }
        protected IUserRepository userRepository = new UserRepository();
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            await Task.Run(() => context.Validated());
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);

            var students = await userRepository.GetAsync();

            if (students != null)
            {
                var user = students.Where(o => o.Username == context.UserName && o.Password == context.Password).FirstOrDefault();
                if (user != null)
                {
                    identity.AddClaim(new Claim(ClaimTypes.Name, user.Username));
                    identity.AddClaim(new Claim("LoggedOn", DateTime.Now.ToString()));
                    await Task.Run(() => context.Validated(identity));
                }
                else
                {
                    context.SetError("Wrong Credentials", "Provided username and password is incorrect");
                }
            }
            else
            {
                context.SetError("Wrong Credentials", "Provided username and password is incorrect");
            }
            return;

        }
    }
}