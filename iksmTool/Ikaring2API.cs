// must riblary System.Web.dll

using System;
using System.Net;

namespace Project.Network
{
    /// <summary>
    /// イカリング2データ取得API
    /// </summary>
    public class Ikaring2API
    {
        /// <summary>取得元URL</summary>
        private const String IKA_HOST_URL = @"https://app.splatoon2.nintendo.net";
        /// <summary>Cookieセッション名</summary>
        private const String COOKIE_NAME_IKSM = "iksm_session";

        /// <summary>直近５０試合の戦績データ取得</summary>
        public const String RESULT_URL = @"https://app.splatoon2.nintendo.net/api/results";
        /// <summary>１試合分の戦績データ取得</summary>
        public const String BATTLE_URL = @"https://app.splatoon2.nintendo.net/api/results/{0}";

        /// <summary>
        /// APIからデータを取得する
        /// </summary>
        /// <param name="apiURL">API取得用URL</param>
        /// <param name="iksmSession">クッキー認証用のデータ</param>
        public static String GetJson(String apiURL, String iksmSession)
        {
            String result;
            try {
                using (var wce = new WebClientEx()) {

                    wce.CookieContainer.Add(new Uri(IKA_HOST_URL),
                                           new Cookie(COOKIE_NAME_IKSM, iksmSession));

                    result = wce.DownloadString(apiURL);
                }
            }
            catch (Exception) {

                result = String.Empty;
            }
            return result;
        }
    }

    /// <summary>
    /// クッキー認証対応WebClient
    /// </summary>
    public class WebClientEx : WebClient
    {
        public CookieContainer CookieContainer { get; set; }

        public WebClientEx()
        {
            this.CookieContainer = new CookieContainer();
        }

        /// <summary>
        /// WebRequest取得処理
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        protected override WebRequest GetWebRequest(Uri uri)
        {
            WebRequest webRequest = base.GetWebRequest(uri);

            if (webRequest is HttpWebRequest) {
                var httpWebRequest = (HttpWebRequest)webRequest;
                httpWebRequest.CookieContainer = this.CookieContainer;
            }

            return webRequest;
        }
    }
}
