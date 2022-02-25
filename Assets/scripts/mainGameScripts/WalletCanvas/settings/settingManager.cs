using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace com.impactionalGames.LudoPrime
{
    public class settingManager : MonoBehaviour
    {
        public Dropdown language;
        public static event Action<string> onlangChanged;

        public void UpdateLanguage()
        {
            if (language.value == 1)
            {
                playerPermData.setLanguage(playerPermData.HINDI_KEY);
                onlangChanged?.Invoke(playerPermData.getLanguage());
            }
            else
            {
                playerPermData.setLanguage(playerPermData.ENGLISH_KEY);
                onlangChanged?.Invoke(playerPermData.getLanguage());
            }

        }

    }
}