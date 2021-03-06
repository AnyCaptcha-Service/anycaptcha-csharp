using AnyCaptchaHelper.Helper;
using Newtonsoft.Json.Linq;

namespace AnyCaptchaHelper.Api
{
    internal class HCaptcha : HCaptchaProxyless
    {
        public ProxyTypeOption? ProxyType { protected get; set; }
        public string ProxyAddress { protected get; set; }
        public int? ProxyPort { protected get; set; }
        public string ProxyLogin { protected get; set; }
        public string ProxyPassword { protected get; set; }
        public string UserAgent { protected get; set; }
        public string Cookies { protected get; set; }

        public override JObject GetPostData()
        {
            var postData = base.GetPostData();
            postData["type"] = "HCaptchaTask";

            if (ProxyType == null || ProxyPort == null || ProxyPort < 1 || ProxyPort > 65535 ||
                string.IsNullOrEmpty(ProxyAddress))
            {
                return null;
            }

            postData.Add("proxyType", ProxyType.ToString().ToLower());
            postData.Add("proxyAddress", ProxyAddress);
            postData.Add("proxyPort", ProxyPort);
            postData.Add("proxyLogin", ProxyLogin);
            postData.Add("proxyPassword", ProxyPassword);
            postData.Add("userAgent", UserAgent);
            postData.Add("cookies", Cookies);

            return postData;
        }
    }
}