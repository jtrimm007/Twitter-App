using System;
using System.Collections.Generic;
using System.Text;
using Tweetinvi;

namespace TwitterApp
{
    /// <summary>
    /// Authenticated twitter login. 
    /// </summary>
    class TwitterLogIn
    {

        public string AuthenticatedUser { get; set; }

        /// <summary>
        /// Logs into a twitter account using the customer key, customer key secret, access token, access token secret. To retreive new tokens and keys, please visit https://developer.twitter.com. This constructor also sets the authenticated user property.
        /// </summary>
        /// <param name="customer_key"></param>
        /// <param name="customer_key_secret"></param>
        /// <param name="access_token"></param>
        /// <param name="access_token_secret"></param>
        public TwitterLogIn(string customer_key, string customer_key_secret, string access_token, string access_token_secret)
        {
            var userCredentials = Tweetinvi.Auth.CreateCredentials(customer_key, customer_key_secret, access_token, access_token_secret);

            var authenticatedUser = Tweetinvi.User.GetAuthenticatedUser(userCredentials);

            AuthenticatedUser = authenticatedUser.ToString();

            var setAuthCred = Auth.SetUserCredentials(customer_key, customer_key_secret, access_token, access_token_secret);


        }
    }
}
