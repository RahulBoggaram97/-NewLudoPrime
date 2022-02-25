using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

namespace com.impactionalGames.LudoPrime
{
    public class flutterManager : MonoBehaviour, IEventSystemHandler
    {
        public string levelToLoadAfterAuthentiocation;

        private void Start()
        {
            /*loadUpNextScene()*/;
        }

        public void passPhoneNumberToUnity(String phoneNum)
        {
            playerPermData.setPhoneNumber(phoneNum);
        }

        public void loadUpNextScene()
        {
            SceneManager.LoadScene(levelToLoadAfterAuthentiocation);
        }
    }
}
