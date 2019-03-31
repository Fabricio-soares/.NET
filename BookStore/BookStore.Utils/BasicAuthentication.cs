using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Net.Http;

namespace BookStore.Utils
{
   public class BasicAuthentication : AuthorizationFilterAttribute
    {
        private const string BasicAuthResponseHeader = "WWW-Autentication";
        private const string BasicAuthResponseHeaderValue = "Basic-Autentication";

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            AuthenticationHeaderValue _authValue = actionContext.Request.Headers.Authorization;
            if (_authValue !=null && !String.IsNullOrEmpty(_authValue.Parameter)  && _authValue.Scheme == BasicAuthResponseHeader)
            {
                string[] credentials = Encoding.ASCII.GetString(Convert.FromBase64String(_authValue.Parameter)).Split(new[] { ':' });
            }
            else
            {
                actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Unauthorized);
                return;
            }
            base.OnAuthorization(actionContext);
        }
    }
}
