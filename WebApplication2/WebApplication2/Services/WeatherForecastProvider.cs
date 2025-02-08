using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace WebApplication2.Services
{
    public class WeatherForecastProvider
    {
        const string cURL = "https://weather-ydn-yql.media.yahoo.com/forecastrss";
        const string cAppID = "F9SVuv3e";
        const string cConsumerKey = "dj0yJmk9YWZxSVVvWE1tTWZmJnM9Y29uc3VtZXJzZWNyZXQmc3Y9MCZ4PTEz";
        const string cConsumerSecret = "c2a7ccc2d0ff902ccef76a931b63239194ddb126";
        const string cOAuthVersion = "1.0";
        const string cOAuthSignMethod = "HMAC-SHA1";

        const string cWeatherID = "woeid=924943";  // Amsterdam, The Netherlands
        const string cUnitID = "u=c";           // Metric units
        const string cFormat = "xml";
 
        public async Task<string> GetAuthToken()
        {
            //using (HttpClient client = new HttpClient())
            //{
            //    var values = new Dictionary<string, string>
            //    {
            //        //{"Content-Type", "application/" + cFormat},
            //        {"X-Yahoo-App-Id", cAppID},
            //        //{"Authorization", _get_auth()},
            //    };

            //    var content = new StringContent(String.Empty);
            //    content.Headers.ContentType.MediaType = "application/" + cFormat;
            //    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Authorization", _get_auth());
            //    foreach (var item in values)
            //    {
            //        content.Headers.Add(item.Key, item.Value);
            //    }

            //    var response = await client.PostAsync(cURL, content);
            //    var responseString = await response.Content.ReadAsStringAsync();

            //    return responseString;
            //}
            const string lURL = cURL + "?" 
                                     //+ cWeatherID 
                                     + @"lat=37.372&lon=122.038"
                                + "&" + cUnitID + "&format=" + cFormat;

            var lClt = new WebClient();

            lClt.Headers.Set("Content-Type", "application/" + cFormat);
            lClt.Headers.Add("X-Yahoo-App-Id", cAppID);
            lClt.Headers.Add("Authorization", _get_auth());

            Console.WriteLine("Downloading Yahoo weather report . . .");

            byte[] lDataBuffer = lClt.DownloadData(lURL);

            string lOut = Encoding.ASCII.GetString(lDataBuffer);
            return lOut;
        }

        private static string _get_timestamp()
        {
            TimeSpan lTS = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            return Convert.ToInt64(lTS.TotalSeconds).ToString();
        }  // end _get_timestamp

        private static string _get_nonce()
        {
            return Convert.ToBase64String(
             new ASCIIEncoding().GetBytes(
              DateTime.Now.Ticks.ToString()
             )
            );
        }  // end _get_nonce

        // NOTE: whenever the value of a parameter is changed, say cUnitID "u=c" => "location=sunnyvale,ca"
        // The order in lSign needs to be updated, i.e. re-sort lSign
        // Please don't simply change value of any parameter without re-sorting.
        private static string _get_auth()
        {
            string retVal;
            string lNonce = _get_nonce();
            string lTimes = _get_timestamp();
            string lCKey = string.Concat(cConsumerSecret, "&");
            string lSign = string.Format(  // note the sort order !!!
             "format={0}&" +
             "oauth_consumer_key={1}&" +
             "oauth_nonce={2}&" +
             "oauth_signature_method={3}&" +
             "oauth_timestamp={4}&" +
             "oauth_version={5}&" +
             "{6}&{7}",
             cFormat,
             cConsumerKey,
             lNonce,
             cOAuthSignMethod,
             lTimes,
             cOAuthVersion,
             cUnitID,
             cWeatherID
            );

            lSign = string.Concat(
             "GET&", Uri.EscapeDataString(cURL), "&", Uri.EscapeDataString(lSign)
            );

            using (var lHasher = new HMACSHA1(Encoding.ASCII.GetBytes(lCKey)))
            {
                lSign = Convert.ToBase64String(
                 lHasher.ComputeHash(Encoding.ASCII.GetBytes(lSign))
                );
            }  // end using

            return "OAuth " +
                   "oauth_consumer_key=\"" + cConsumerKey + "\", " +
                   "oauth_nonce=\"" + lNonce + "\", " +
                   "oauth_timestamp=\"" + lTimes + "\", " +
                   "oauth_signature_method=\"" + cOAuthSignMethod + "\", " +
                   "oauth_signature=\"" + lSign + "\", " +
                   "oauth_version=\"" + cOAuthVersion + "\"";

        }  // end _get_auth

    }
}