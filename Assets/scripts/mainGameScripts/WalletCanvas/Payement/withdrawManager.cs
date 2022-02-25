using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using TMPro;

namespace com.impactionalGames.LudoPrime
{
    public class withdrawManager : MonoBehaviour
    {
        public InputField withdrawField;
        public Text debugText;
        public TextMeshProUGUI moneyText;

        private void Start()
        {
            moneyText.text = playerPermData.getMoney().ToString();
        }

        public void withdraw()
        {
            if (withdrawField == null)
            {
                debugText.text = "Please enter amount!!";
            }
            else {

                if (int.Parse(withdrawField.text) > playerPermData.getMoney())
                {
                    debugText.text = "You dont have enough balance to withdraw this amount!!";

                }
                else
                {
                    StartCoroutine(withdraw_coroutine());
                }
            }
           

        } 

        IEnumerator withdraw_coroutine()
        {
            string url = "https://ludogame-backend.herokuapp.com/api/addWithdrawRequest";

            

            WWWForm form = new WWWForm();
            form.AddField("phone", playerPermData.getPhoneNumber());
            form.AddField("amount", withdrawField.text);

            using (UnityWebRequest request = UnityWebRequest.Post(url, form))
            {
                yield return request.SendWebRequest();
                if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
                {
                    debugText.text = request.error + request.downloadHandler.text;
                }
                else
                {
                    debugText.text = request.downloadHandler.text;
                }
            }
        }
    }

}