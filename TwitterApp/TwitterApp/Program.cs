using System;
using Tweetinvi.Models;
using System.IO;
using System.Text;
using Tweetinvi.Parameters;


namespace TwitterApp
{
    class Program
    {
        public static string customer_key = "pD0m2GNPtUiiK0l5Wwzfl8x3u";
        public static string customer_key_secret = "O7e0TSBfsP7O5DvVe55DF5z2rHTCYk9aSnqtSV5Cxdkm4m6jRL";
        public static string access_token = "721557153912352769-o4fwjUPPsqUJyGFscVr7BxudeqexkPt";
        public static string access_token_secret = "0J0EX7BRvjKlW6vi0mIVmURvfXWfWsPR14jsJF3su7mwf";
        public static string pathToSaveCsv = "C:\\Users\\jbthy\\Dropbox (Personal)\\ETSU\\Spring-2019\\Research-Assistant\\twitterAppData\\twitterData.csv";





        static void Main(string[] args)
        {


            Console.WriteLine($"<{DateTime.Now}> - Bot Started");

            TwitterLogIn logIntoTwitter = new TwitterLogIn(customer_key, customer_key_secret, 
                access_token, access_token_secret);

            Console.WriteLine($"User: {logIntoTwitter.AuthenticatedUser}");


            SearchTweetsParameters searchParameter = new SearchTweetsParameters("Turkey")
            {
               // GeoCode = new GeoCode(-122.398720, 37.781157, 1000, DistanceMeasure.Miles),
                Lang = LanguageFilter.English,
                //SearchType = SearchResultType.Popular,
                MaximumNumberOfResults = 1000,
                //Until = new DateTime(2019, 01, 02),
                //SinceId = 399616835892781056,
                //MaxId = 405001488843284480,
                //Filters = TweetSearchFilters.Images
            };



            TwitterSearch searchTweets = new TwitterSearch(searchParameter);


            foreach (var tweet in searchTweets.TweetList)
            {
                Console.WriteLine($"Created By: \n{tweet.CreatedBy}\n");
                Console.WriteLine($"Place: \n{tweet.Place}\n");
                Console.WriteLine($"Coordinates: \n{tweet.Coordinates}\n");
                Console.WriteLine($"TweetDTO FavoriteCount: \n{tweet.TweetDTO.FavoriteCount}\n");
                Console.WriteLine($"Favorited: \n{tweet.Favorited}\n");
                Console.WriteLine($"Tweet Time: \n{tweet.CreatedAt}\n");
                Console.WriteLine($"Tweet: \n{tweet}\n");

                StringBuilder hashBuilder = new StringBuilder();
                Console.WriteLine($"Tweet: \n{tweet}\n");
                foreach (var hash in tweet.Hashtags)
                {
                    hashBuilder.Append(hash + " ");
                }

                Console.WriteLine($"Hash Tags: \n{hashBuilder.ToString()}\n");
                Console.WriteLine($"Retweet Count: \n{tweet.RetweetCount}\n");
                Console.WriteLine($"Fav Count: \n{tweet.FavoriteCount}\n");
                Console.WriteLine($"Tweet Text:  \n{tweet.FullText}\n--------------------------------------");

            }

            searchTweets.CreateCsv(pathToSaveCsv);

            Console.Read();
        }



    }
}
