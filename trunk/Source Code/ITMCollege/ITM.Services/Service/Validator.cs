using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITM.Services.Service
{
    /// -----------------------------------------------------------------------------
    /// Project	 : ITMWebsite
    /// Class	 : Validate
    /// 
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Global resource for Validate methods
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <history>
    /// - Created on 16 May 2013
    /// </history>
    /// -----------------------------------------------------------------------------
    public class Validator
    {

        /// <summary>
        /// Get a substring of the first N characters.
        /// </summary>
        public string Truncate(string source, int length)
        {
            if (source.Length > length)
            {
                source = source.Substring(0, length);
            }
            return source;
        }
        /// <summary>
        /// Check for maximum length of string
        /// </summary>
        /// <param name="str">String to check</param>
        /// <param name="maxLength">Int length value</param>
        /// <returns>Boolean</returns>
        public Boolean CheckMaxLength(string str, int maxLength)
        {
            if (str.Length > maxLength)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Check for minium length of string
        /// </summary>
        /// <param name="str">String to check</param>
        /// <param name="minLength">Int length value</param>
        /// <returns></returns>
        public Boolean CheckMinLength(string str, int minLength)
        {
            if (str.Length < minLength)
            {
                return false;
            }
            return true;
        }
    }
}
