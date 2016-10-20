using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace webapi.config.ErrorHelper
{
    /*
     * Here, I divided our exceptions in the following three categories:
            1. API Exceptions – for API level exceptions.
            2. Business Exceptions – for exceptions at business logic level.
            3. Data Exceptions – Data related exceptions.
     */
    public interface IApiExceptions
    {
        /// <summary>
        /// ErrorCode
        /// </summary>
        int ErrorCode { get; set; }
        /// <summary>
        /// ErrorDescription
        /// </summary>
        string ErrorDescription { get; set; }
        /// <summary>
        /// HttpStatus
        /// </summary>
        HttpStatusCode HttpStatus { get; set; }
        /// <summary>
        /// ReasonPhrase
        /// </summary>
        string ReasonPhrase { get; set; }
    }
}
