using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

namespace com.impactionalGames.LudoPrime
{
    public class UIHandlerEndGame : MonoBehaviourPun
    {
        public EndGameManager endGameManager;
        public WinnerDecider winDec;

        public GameObject leaderBoard;

        private void Update()
        {
            if(leaderBoard.activeSelf == true && Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene("GameMenu");

                PhotonNetwork.LeaveRoom();
                PhotonNetwork.LeaveLobby(); 
                SceneManager.LoadScene("GameMenu");

               
            }
        }

        public void UpdateLeaderBoard()
        {
           leaderBoard.SetActive(true);
            rpc_updateLeaderBoard();

            
        }

        
        void rpc_updateLeaderBoard()
        {
            endGameManager.ranktext[0].text = PhotonNetwork.PlayerList[winDec.rank1Index].NickName;
            endGameManager.ranktext[1].text = PhotonNetwork.PlayerList[winDec.rank2Index].NickName;

            if (PhotonNetwork.PlayerList.Length > 2)
            {

                endGameManager.ranktext[2].text = PhotonNetwork.PlayerList[winDec.rank3Index].NickName;
                endGameManager.ranktext[3].text = PhotonNetwork.PlayerList[winDec.rank4Index].NickName;
            }
            else
            {
                return;
            }
        }
    }

}