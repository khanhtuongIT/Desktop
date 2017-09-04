using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.Security.Principal;

namespace Ecm.Bar
{
    public class SecurityManager
    {
        /// <summary>
        /// Produces a string containing a cryptographic hash of the given string.
        /// </summary>
        /// <param name="data">The data to be hashed.</param>
        /// <returns>A cryptographic hash of the given string.</returns>
        public static string HashData(
            string data
            )
        {

            // Convert the string to a unicode array of bytes.
            byte[] msgBytes = Encoding.Unicode.GetBytes(data);

            // Calculate a hash on the data.
            SHA1Managed sha1 = new SHA1Managed();
            byte[] hashBytes = sha1.ComputeHash(msgBytes);

            // Use the string builder for increased speed.
            StringBuilder hashRet = new StringBuilder("");

            // Loop and convert each digit in the hash.
            foreach (byte b in hashBytes)
                hashRet.AppendFormat("{0:X}", b);

            // Return the hash.
            return hashRet.ToString();

        } // End HashData()

        // ******************************************************************

        /// <summary>
        /// Produces an array containing a cryptographic hash of the given data.
        /// </summary>
        /// <param name="data">The data to be hashed.</param>
        /// <returns>A cryptographic hash of the given data.</returns>
        public static byte[] HashData(
            byte[] data
            )
        {

            // Calculate a hash on the data.
            SHA1Managed sha1 = new SHA1Managed();
            byte[] hashBytes = sha1.ComputeHash(data);

            // Return the hash.
            return hashBytes;

        } // End HashData()
    }
}
