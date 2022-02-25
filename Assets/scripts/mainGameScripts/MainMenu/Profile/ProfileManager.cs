using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using SimpleJSON;

namespace com.impactionalGames.LudoPrime
{
    public class ProfileManager : MonoBehaviour
    {


        public getUserDetails getuseDetObject;


        public InputField playerNameField;

        public Text phoneNum;
        public Text walletCoinsText;
        public Text totalmatchesText;
        public Text wonMatchesText;
        public Text loseMatchesText;


        private void Start()
        {
            playerPermData.setPhoneNumber("9876543210");

            getuseDetObject.getUserDet();

            getPlayerName();

            phoneNum.text = playerPermData.getPhoneNumber();

            walletCoinsText.text = "Wallet Coins: " + playerPermData.getMoney();

            totalmatchesText.text = playerPermData.getTotalMatches();

            wonMatchesText.text = playerPermData.getWonMatches();

            loseMatchesText.text = playerPermData.getLoseMatches();
         
        }


        public void getPlayerName()
        {
            string defaultName = string.Empty;
            if (playerNameField != null)
            {
                if (PlayerPrefs.HasKey(playerPermData.USERNAME_PREF_KEY))
                {
                    defaultName = PlayerPrefs.GetString(playerPermData.USERNAME_PREF_KEY);
                    playerNameField.text = defaultName;
                }
            }

            PhotonNetwork.NickName = defaultName;
        

        }

        public void setPlayerName()
        {
            if (playerNameField.text != string.Empty)
            {
                PhotonNetwork.NickName = playerNameField.text;
                playerPermData.setUserName(playerNameField.text);
            }
            else
            {

                return;
            }
        }

        void getUserDataFromRest()
        {

        }

    }
}