using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


namespace com.impactionalGames.LudoPrime {

    public class sendMatchDetails : MonoBehaviour
    {

        public void sendMatchDet(string winStats) => StartCoroutine(sendMatchDetails_coroutine(winStats));

        IEnumerator sendMatchDetails_coroutine(string win)
        {
            string url = "https://ludogame-backend.herokuapp.com/api/addTournamentHistory";

            WWWForm form = new WWWForm();
            form.AddField("Phone", playerPermData.getPhoneNumber());
            form.AddField("winner", win);
    
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
