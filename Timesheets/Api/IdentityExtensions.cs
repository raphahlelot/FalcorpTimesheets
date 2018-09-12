using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;

namespace Falcorp.Timesheets.Api
{

    public static class IdentityExtensions
    {

        /// <summary>
        ///     Gets firstname
        /// </summary>
        /// <see cref="IIdentity"/>
        /// <param name="identity"></param>
        /// <returns></returns>
        public static string GetFirstName(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("FirstName");

            return (claim != null) ? string.IsNullOrEmpty(claim.Value) ? " " : claim.Value : " ";
        }

        /// <summary>
        ///      Gets surname
        /// </summary>
        ///  <see cref="IIdentity"/>
        /// <param name="identity"></param>
        /// <returns></returns>
        public static string GetLastName(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("LastName");

            return (claim != null) ? string.IsNullOrEmpty(claim.Value) ? " " : claim.Value : " ";
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="identity"></param>
        /// <returns></returns>
        public static string GetPrimaryClient(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("PrimaryClient");

            return (claim != null) ? string.IsNullOrEmpty(claim.Value) ? " " : claim.Value : " ";

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="identity"></param>
        /// <returns></returns>
        public static string GetEmployeeId(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("EmployeeId");

            return (claim != null) ? string.IsNullOrEmpty(claim.Value) ? " " : claim.Value : " ";

        }


    }
}