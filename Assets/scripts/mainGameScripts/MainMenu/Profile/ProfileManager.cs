using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using SimpleJSON;
using UnityEngine.Networking;


namespace com.impactionalGames.LudoPrime
{
    public class ProfileManager : MonoBehaviour
    {
        [Header("other scripts")]
        public uploadprofilPicture profileUploader;
        public getUserDetails getuseDetObject;

        [Header("Input Fields")]
        public InputField playerNameField;

        [Header("Text elements")]
        public Text phoneNum;
        public Text walletCoinsText;
        public Text totalmatchesText;
        public Text wonMatchesText;
        public Text loseMatchesText;
        public Text refrelCodeText;

        [Header("profilePic")]
        public Image profilePic;


        private void Start()
        {
            

            getuseDetObject.getUserDet();

            Debug.Log("profile start called");

            StartCoroutine( DownloadImage(playerPermData.getProfilePicUrl()));

            Debug.Log(playerPermData.getProfilePicUrl());

            getPlayerName();

            phoneNum.text = playerPermData.getPhoneNumber();

            walletCoinsText.text = "Wallet Coins: " + playerPermData.getMoney();

            totalmatchesText.text = playerPermData.getTotalMatches();

            wonMatchesText.text = playerPermData.getWonMatches();

            loseMatchesText.text = playerPermData.getLoseMatches();

            refrelCodeText.text = "Refrel Code: " + playerPermData.getReferCode();  
         
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

        public IEnumerator DownloadImage(string downloadUrl)
        {
            Debug.Log("Downloading image");

            Texture2D downloadedTexture = null;

            UnityWebRequest request = UnityWebRequestTexture.GetTexture(downloadUrl);
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.Log("cant connect oof");
                Debug.Log(request.error);
            }
            else
            {
                downloadedTexture = ((DownloadHandlerTexture)request.downloadHandler).texture;
                Debug.Log("image downladed");
            }

            if (downloadedTexture != null)
                profilePic.sprite = Sprite.Create(downloadedTexture, new Rect(0f, 0f, downloadedTexture.width, downloadedTexture.height), new Vector2(0.5f, 0.5f), 100f);
            else Debug.Log("texuture is null");


        }
        
        public void uploadPhoto()
        {
            profileUploader.imagePicker();
        }


    }
}