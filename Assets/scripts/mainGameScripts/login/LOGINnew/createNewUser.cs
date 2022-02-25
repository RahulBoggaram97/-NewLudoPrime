using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System;

namespace com.impactionalGames.LudoPrime
{
    public class createNewUser : MonoBehaviour
    {

        public Text debugText;

        public Text referelCodeText;

        private void Awake()
        {
            debugText.text = debugText.text + "         create new user awake called";
            authManager.loginStateChanged += HandleOnAuthenticate;
        }

        private void OnDestroy()
        {
            authManager.loginStateChanged -= HandleOnAuthenticate;
        }

        private void HandleOnAuthenticate(loginState state)
        {
            if(state == loginState.createUser)
            {
                debugText.text = playerPermData.getPhoneNumber();

               if(playerPermData.getPhoneNumber() == String.Empty)
                {
                    debugText.text = "You need to authenticate";
                }
                
            }
        }

        public void createUser() => StartCoroutine(createNewUser_Coroutine());

        

       IEnumerator createNewUser_Coroutine()
        {
            debugText.text = "creating user";

            string url = "https://ludogame-backend.herokuapp.com/api/createUser";
            WWWForm form = new WWWForm();
            form.AddField("Phone", playerPermData.getPhoneNumber());
            form.AddField("Referrer", referelCodeText.text);

            using (UnityWebRequest request = UnityWebRequest.Post(url, form))
            {
                yield return request.SendWebRequest();
                if(request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
                {
                    debugText.text = request.error;

                    if(request.downloadHandler.text.Contains("Duplicate entry"))
                    {
                        debugText.text = "user have already been created";

                        authManager.instance.updateLoginState(loginState.loggedIn);

                        playerPermData.setUserName(authManager.instance.userNameField.text);
                    }
                }
                else
                {
                    debugText.text = "user have been created";
                    authManager.instance.updateLoginState(loginState.loggedIn);
                    playerPermData.setUserName(authManager.instance.userNameField.text);


                }
            }
        }


       

    }
}
