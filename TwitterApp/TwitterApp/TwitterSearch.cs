using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Tweetinvi;
using Tweetinvi.Models;
using Tweetinvi.Parameters;
using CsvHelper;


namespace TwitterApp
{
    class TwitterSearch
    {
        public List<ITweet> TweetList { get; set; }

        /// <summary>
        /// Basic constructor to start a search and set the TweetList property.
        /// </summary>
        /// <param name="searchString">Pass in a search string</param>
        public TwitterSearch(string searchString)
        {
            var tweets = Search.SearchTweets(searchString.ToString());

            List<ITweet> list = new List<ITweet>(tweets);

            TweetList = list;
        }

        /// <summary>
        /// Basic constructor to start a search and set the TweetList property.
        /// </summary>
        /// <param name="searchString">Pass in the SearchTweetsParameters from Tweetinvi</param>
        public TwitterSearch(SearchTweetsParameters searchString)
        {
            var tweets = Search.SearchTweets(searchString);

            List<ITweet> list = new List<ITweet>(tweets);

            TweetList = list;
        }

        public void CreateCsv(string path)
        {
            StringBuilder stringBuilder = new StringBuilder();

            String csvHead = String.Format("{0},{1},{2},{3},{4},{5}", "Tweet Text", "Date", "Created By", "Hash Tags", "RT count", "Favorite Count");

            stringBuilder.AppendLine(csvHead);

            foreach(var tweet in TweetList)
            {

                StringBuilder hashBuilder = new StringBuilder();

                foreach (var hash in tweet.Hashtags)
                {
                    hashBuilder.Append(hash + " ");
                }

                var tweetToString = tweet.FullText.ToString();


                var replaceNewLineWithSpace = tweetToString.Replace("\n", " ");

                var replaceQuotes = replaceNewLineWithSpace.Replace("\"", "");




                try{
                    String newLine = String.Format($"\"{replaceQuotes}\"  , {tweet.CreatedAt.ToString()}, {tweet.CreatedBy}, {hashBuilder.ToString()}, {tweet.RetweetCount}, {tweet.TweetDTO.FavoriteCount}");
                    stringBuilder.AppendLine(newLine);
                }
                catch(Exception error)
                {
                    Console.WriteLine(error);
                }

            }


            try
            {
                File.WriteAllText(path, stringBuilder.ToString());

            }
            catch(Exception error)
            {
                Console.WriteLine(error);

            }

        }

        private object CsvSerializer(string v)
        {
            throw new NotImplementedException();
        }
    }
}
