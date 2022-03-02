using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

namespace com.impactionalGames.LudoPrime
{
    public class flutterManager : MonoBehaviour, IEventSystemHandler
    {
        public string levelToLoadAfterAuthentiocation;
        public string refrelCode;


        private void Start()
        {
            //loadUpNextScene();
        }

        public void passPhoneNumberToUnity(String phoneNum)
        {
            playerPermData.setPhoneNumber(phoneNum);

            createUser();
            
        }

        public void passRefrelCodeToUnity(String _refrelCode)
        {
            refrelCode= _refrelCode;
        }

       

        

        

        public void createUser() => StartCoroutine(createNewUser_Coroutine());



        IEnumerator createNewUser_Coroutine()
        {
            

            string url = "https://ludogame-backend.herokuapp.com/api/createUser";
            WWWForm form = new WWWForm();
            form.AddField("Phone", playerPermData.getPhoneNumber());
            form.AddField("Referrer", refrelCode);

            using (UnityWebRequest request = UnityWebRequest.Post(url, form))
            {
                yield return request.SendWebRequest();
                if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
                {
                   

                    if (request.downloadHandler.text.Contains("Duplicate entry"))
                    {




                        loadUpNextScene();
                    }
                }
                else
                {


                    loadUpNextScene();

                }
            }
        }

        public void loadUpNextScene()
        {
            SceneManager.LoadScene(levelToLoadAfterAuthentiocation);
        }
    }
}
