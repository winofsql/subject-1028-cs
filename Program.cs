using System.Web;
using System.Text;
using System.Collections.Generic;
using System.Net;
using System;

namespace subject-1028-cs-post
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = "http://localhost/php-form-post/keijiban6.php";
            string encoding = "utf-8";
            Dictionary<string, string> param
             = new Dictionary<string, string>() {
                 { "personal_name", "件名CS" },
                 { "contents", "本文\nあいうえお" } 
               };

            try {
                WebClient webClient = new WebClient();
                webClient.Encoding = Encoding.GetEncoding("utf-8");
                webClient.Headers["Content-Type"] = "application/x-www-form-urlencoded";

                string data_string = "";
                foreach (KeyValuePair<string, string> kvp in param) {
                    if (data_string != "") {
                        data_string += "&";
                    }
                    data_string += kvp.Key + "=";
                    data_string += HttpUtility.UrlEncode(kvp.Value, Encoding.GetEncoding(encoding));
                }

                string result = webClient.UploadString(new Uri(url), "POST", data_string);

                Console.WriteLine(result);

            }
            catch (System.Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
