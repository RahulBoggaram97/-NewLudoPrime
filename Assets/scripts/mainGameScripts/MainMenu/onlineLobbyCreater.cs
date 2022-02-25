using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using System.Threading.Tasks;


namespace com.impactionalGames.LudoPrime
{
    public class onlineLobbyCreater : MonoBehaviourPunCallbacks
    {
        public GameObject[] lobbyPrefabs;

        //public oneVone oneVonePrefab;
        //public oneWinner oneWinnerPrefab;
        //public twoWinner twoWinnersPrefab;
        //public threeWinner threeWinnersPrefab;

        public Transform[] lobbyUIPos;

        public float timer = 0f;

        public RoomOptions roomOptions = new RoomOptions();

        public const string ENTRYFEE_PROP_KEY = "EF";

        public int entryFee;

        

        private void Update()
        {
            updateTimer();
        }

        void updateTimer()
        {
            timer = timer - Time.deltaTime;
            
            if (timer < 0f)
            {
                if (availablePosition() != null)
                {
                    updateOnlineMenuData();
                    timer = 10f;
                }
            }
        }

        
        



         void updateOnlineMenuData()
        {
            Debug.Log("updateonlinemenu called");
            
            Instantiate(prefabToInstantiate(), availablePosition());   
           
        }

        GameObject prefabToInstantiate()
        {
            GameObject instance = lobbyPrefabs[Random.Range(0, lobbyPrefabs.Length - 1)];
            return instance;
        }
    

        private Transform availablePosition()
        {
           Transform availPos;

           for (int i = 0; i < lobbyUIPos.Length; i++)
           {
                if (lobbyUIPos[i].childCount == 0)
                {
                     availPos = lobbyUIPos[i];
                     return availPos;
                }
                Debug.Log("avail pos got called");
           }
           return null;
                
        }




        public override void OnJoinedLobby()
        {
            PhotonNetwork.NickName = playerPermData.getUserName();
            Debug.Log("current lobby is " + PhotonNetwork.CurrentLobby.Name);

            joinTheMainGame();

        }

        public void joinTheMainGame()
        {

            PhotonNetwork.JoinRandomOrCreateRoom();
           
            

            
        }

       




    }
}
