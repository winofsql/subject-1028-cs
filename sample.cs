using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Web;

namespace winofsql {

    class Tool {

        public static string serverEncoding = "utf-8";

        // *********************************************
        // UTF-8 POST
        // *********************************************
        public static string Post(string url,
            Dictionary<string, string> param,
            UploadStringCompletedEventHandler UploadStringCompleted=null) {

            string result = "";

            try {
                WebClient webClient = new WebClient();
                webClient.Encoding = Encoding.GetEncoding(serverEncoding);

                if ( UploadStringCompleted != null ) {
                    // 呼び出し側でラムダ式を使う事を想定した
                    // イベント登録
                    webClient.UploadStringCompleted += UploadStringCompleted;
                }

                webClient.Headers["Content-Type"] = "application/x-www-form-urlencoded";

                string data_string = "";

                foreach (KeyValuePair<string, string> kvp in param)
                {
                    if (data_string != "")
                    {
                        data_string += "&";
                    }
                    data_string += kvp.Key + "=";

                    // *******************************************************
                    // プロジェクトのプロパティの対象フレームワークを 
                    //『Framework 4』 にして System.Web を参照します
                    // *******************************************************
                    data_string += HttpUtility.UrlEncode(kvp.Value, Encoding.UTF8);
                }
                
                webClient.UploadStringAsync(new Uri(url), "POST", data_string);

            }
            catch (Exception Err) {
                result = "ERROR: " + Err.Message;
            }

            return result;

        }

        // *********************************************
        // エンコード指定 POST
        // *********************************************
        public static string Post(string url,
            string encoding,
            Dictionary<string, string> param,
            UploadStringCompletedEventHandler UploadStringCompleted=null) {

            string result = "";

            try {
                WebClient webClient = new WebClient();
                webClient.Encoding = Encoding.GetEncoding(serverEncoding);

                if ( UploadStringCompleted != null ) {
                    // 呼び出し側でラムダ式を使う事を想定した
                    // イベント登録
                    webClient.UploadStringCompleted += UploadStringCompleted;
                }

                webClient.Headers["Content-Type"] = "application/x-www-form-urlencoded";

                string data_string = "";

                foreach (KeyValuePair<string, string> kvp in param)
                {
                    if (data_string != "")
                    {
                        data_string += "&";
                    }
                    data_string += kvp.Key + "=";

                    // *******************************************************
                    // プロジェクトのプロパティの対象のフレームワークを 
                    //『.NET Framework 4』 にして System.Web を参照します
                    // *******************************************************
                    data_string += HttpUtility.UrlEncode(kvp.Value, Encoding.GetEncoding(encoding));
                }
                
                webClient.UploadStringAsync(new Uri(url), "POST", data_string);

            }
            catch (Exception Err) {
                result = "ERROR: " + Err.Message;
            }

            return result;

        }

        // *********************************************
        // URL のみ呼び出し GET
        // *********************************************
        public static string Get(
            string url,
            DownloadStringCompletedEventHandler DownloadStringCompleted=null) {

            string result = "";

            try {
                WebClient webClient = new WebClient();
                webClient.Encoding = Encoding.GetEncoding(serverEncoding);

                if ( DownloadStringCompleted != null ) {
                    // 呼び出し側でラムダ式を使う事を想定した
                    // イベント登録
                    webClient.DownloadStringCompleted += DownloadStringCompleted;
                }

                webClient.DownloadStringAsync(new Uri(url));

            }
            catch (Exception Err) {
                result = "ERROR: " + Err.Message;
            }

            return result;

        }

        // *********************************************
        // データ呼び出し( UTF-8 ) GET
        // *********************************************
        public static string Get(
            string url, 
            Dictionary<string, string> param,
            DownloadStringCompletedEventHandler DownloadStringCompleted=null) {

            string result = "";

            try
            {
                WebClient webClient = new WebClient();
                webClient.Encoding = Encoding.GetEncoding(serverEncoding);

                if (DownloadStringCompleted != null)
                {
                    // 呼び出し側でラムダ式を使う事を想定した
                    // イベント登録
                    webClient.DownloadStringCompleted += DownloadStringCompleted;
                }

                string data_string = "";

                foreach (KeyValuePair<string, string> kvp in param)
                {
                    if (data_string != "")
                    {
                        data_string += "&";
                    }
                    data_string += kvp.Key + "=";

                    // *******************************************************
                    // プロジェクトのプロパティの対象フレームワークを 
                    //『Framework 4』 にして System.Web を参照します
                    // *******************************************************
                    data_string += HttpUtility.UrlEncode(kvp.Value, Encoding.UTF8);
                }

                webClient.DownloadStringAsync(new Uri(url + "?" + data_string));

            }
            catch (Exception Err)
            {
                result = "ERROR: " + Err.Message;
            }

            return result;

        }

        // *********************************************
        // データ呼び出し( エンコード指定 ) GET
        // *********************************************
        public static string Get(
            string url,
            string encoding,
            Dictionary<string, string> param,
            DownloadStringCompletedEventHandler DownloadStringCompleted=null) {

            string result = "";

            try
            {
                WebClient webClient = new WebClient();
                webClient.Encoding = Encoding.GetEncoding(serverEncoding);

                if (DownloadStringCompleted != null)
                {
                    // 呼び出し側でラムダ式を使う事を想定した
                    // イベント登録
                    webClient.DownloadStringCompleted += DownloadStringCompleted;
                }

                string data_string = "";

                foreach (KeyValuePair<string, string> kvp in param)
                {
                    if (data_string != "")
                    {
                        data_string += "&";
                    }
                    data_string += kvp.Key + "=";

                    // *******************************************************
                    // プロジェクトのプロパティの対象フレームワークを 
                    //『Framework 4』 にして System.Web を参照します
                    // *******************************************************
                    data_string += HttpUtility.UrlEncode(kvp.Value, Encoding.GetEncoding(encoding));
                }

                webClient.DownloadStringAsync(new Uri(url + "?" + data_string));

            }
            catch (Exception Err)
            {
                result = "ERROR: " + Err.Message;
            }

            return result;

        }

    }
}
