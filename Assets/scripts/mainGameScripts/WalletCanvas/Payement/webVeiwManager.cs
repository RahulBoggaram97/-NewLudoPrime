using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace com.impactionalGames.LudoPrime
{
    public class webVeiwManager : MonoBehaviour
    {
        public string Url;

        WebViewObject webViewObject;

        public string murl;

        public Text status;

        public getUserDetails getDetails;



        void Update()
        {
            if (webViewObject != null)
            {

                webViewObject.EvaluateJS("if (location) window.Unity.call('url:' + location.href);");
                status.text = murl;
            }

            if (murl.Contains("success"))
            {
                onTransactoinSuccessHandler();
            }
            else if (murl.Contains("paynow"))
            {
                webViewObject.SetVisibility(true);
            }
            else if (murl.Contains("failure"))
            {
                onTransactoinSuccessHandler();
            }
        }


        public void openPayTmGateway()
        {

            webViewObject = (new GameObject("WebViewObject")).AddComponent<WebViewObject>();

            webViewObject.SetVisibility(true);
            webViewObject.Init((msg) =>
            {
                if (msg.StartsWith("http"))
                {
                    murl = msg.Substring(4);
                }
                if (msg.StartsWith("url:"))
                {
                    murl = msg.Substring(4);
                }

            });
            webViewObject.EvaluateJS(@"
        window.addEventListener('onpageshow', function(){
        Unity.call('url:' + window.location.href);
         }, false);
            ");

            webViewObject.EvaluateJS("if (location) window.Unity.call(location.href);");

            webViewObject.SetMargins(5, 200, 5, 500);
            webViewObject.SetVisibility(true);
            webViewObject.LoadURL(Url);


        }


        void onTransactoinSuccessHandler()
        {
            webViewObject.SetVisibility(false);
            getDetails.getUserDet();
        }
    }
}
