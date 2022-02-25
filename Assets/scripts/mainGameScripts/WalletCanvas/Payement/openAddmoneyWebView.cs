using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace com.impactionalGames.LudoPrime
{
    public class openAddmoneyWebView : MonoBehaviour
    {
        public string webViewSceneName;

        public void openAddMoneyWebView()
        {
            SceneManager.LoadScene(webViewSceneName);
        }
    }
}

