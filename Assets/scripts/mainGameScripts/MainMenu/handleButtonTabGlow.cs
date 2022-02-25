using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace com.impactionalGames.LudoPrime
{
    public class handleButtonTabGlow : MonoBehaviour
    {
        public GameObject[] panelToTrack;
        public Image[] buttonToActivate;

        public Sprite unselected;
        public Sprite selected;

        // Update is called once per frame
        void Update()
        {
            glowButtonManager();
        }

        void glowButtonManager()
        {
            for(int i = 0; i < panelToTrack.Length; i++)
            {
                if(panelToTrack[i].activeSelf == true)
                {
                    buttonToActivate[i].sprite = selected;
                }
                else
                {
                    buttonToActivate[i].sprite = unselected;
                }
                
            }
        }
    }
}
