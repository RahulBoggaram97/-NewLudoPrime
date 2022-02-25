using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace com.impactionalGames.LudoPrime
{
    public class tansactApiCaller : MonoBehaviour
    {
        public void transferMoney(string amount) => StartCoroutine(transferMoney_Coroutine(amount));

        IEnumerator transferMoney_Coroutine(string amount)
        {
            Debug.Log("loding");

            string url = "https://ludogame-backend.herokuapp.com/api/addTransactionHistory";
            WWWForm form = new WWWForm();
            form.AddField("Phone", playerPermData.getPhoneNumber());
            form.AddField("amount", amount);

            using (UnityWebRequest request = UnityWebRequest.Post(url, form))
            {
                yield return request.SendWebRequest();
                if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
                {
                    Debug.Log(request.error);
                }
                else
                {
                    Debug.Log(request.downloadHandler.text);

                }
            }
        }
    }
}
