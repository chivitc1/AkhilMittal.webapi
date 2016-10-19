using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BusinessServices.security;
using webapi.config.Filters;

namespace webapi.Controllers.security
{
    /*
     * Every request coming through this controller will have to pass through this 
     * authentication filter, that check for BasicAuthentication header and credentials.
     * Authentication filter sets CurrentThread principal to the authenticated Identity.
     */
    [ApiAuthenticationFilter]
    public class AuthenticateController : ApiController
    {
        #region Private variable.

        private readonly ITokenServices _tokenServices;

        #endregion

        #region Public Constructor

        /// <summary>
        /// Public constructor to initialize product service instance
        /// </summary>
        public AuthenticateController(ITokenServices tokenServices)
        {
            _tokenServices = tokenServices;
        }

        #endregion

        /// <summary>
        /// Authenticates user and returns token with expiry.
        /// </summary>
        /// <returns></returns>
        [HttpPost]

        //multiple endpoints
        [Route("login")]
        [Route("authenticate")]
        [Route("get/token")]
        public HttpResponseMessage Authenticate()
        {
            if (System.Threading.Thread.CurrentPrincipal == null ||
                !System.Threading.Thread.CurrentPrincipal.Identity.IsAuthenticated) return null;
            var basicAuthenticationIdentity = System.Threading.Thread.CurrentPrincipal.Identity as BasicAuthenticationIdentity;
            if (basicAuthenticationIdentity == null) return null;
            var userId = basicAuthenticationIdentity.UserId;
            return GetAuthToken(userId);
        }

        /// <summary>
        /// Returns auth token for the validated user.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        private HttpResponseMessage GetAuthToken(int userId)
        {
            var token = _tokenServices.GenerateToken(userId);
            var response = Request.CreateResponse(HttpStatusCode.OK, "Authorized");
            response.Headers.Add("Token", token.AuthToken);
            response.Headers.Add("TokenExpiry", ConfigurationManager.AppSettings["AuthTokenExpiry"]);
            response.Headers.Add("Access-Control-Expose-Headers", "Token,TokenExpiry");
            return response;
        }
    }
}
