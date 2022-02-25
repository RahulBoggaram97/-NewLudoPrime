using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using System.Linq;

namespace com.impactionalGames.LudoPrime
{
    public class EndGameManager : MonoBehaviourPunCallbacks
    {
        [Header("Celibration gifs")]
        public GameObject winImage;
        public GameObject lossImage;


        public static EndGameManager egm;

        [Header("Rolling dice collector to access score")]
        public RollinDice[] scoreDice;

        [Header("Text for the leaderboard")]
        public Text[] ranktext;

        [Header("Level to load when game is finished")]
        public string gameFinishedLevelToLoad;


        public WinnerDecider winDecide;

        private void Start()
        {
            egm = this;
        }
        public void winStarterMethod()
        {
            checkWhichLobby();
        }

        void checkWhichLobby()
        {
            

            if (checkIfItsOneVoneLobby())
            {
                

                winDecide.decideOnevOneWinner();

            }
            else if (!chechIfItsCustomLobby())
            {
                winDecide.decideFourPlayerGameWinner();
            }
            else
            {
                return;
            }
        }

        //deciding which Lobby
        bool checkIfItsOneVoneLobby()
        {
            switch (PhotonNetwork.CurrentLobby.Name)
            {
                case "oneVoneOne":
                    return true;
                case "oneVoneFive":
                    return true;
                case "oneVoneTen":
                    return true;
                case "oneVoneTwentyFive":
                    return true;
                case "oneVoneFifty":
                    return true;
                case "oneVoneHundred":
                    return true;
                default:
                    return false;
            }

        }

        bool chechIfItsCustomLobby()
        {
            switch (PhotonNetwork.CurrentLobby.Name)
            {
                case "customLobby":
                    return true;
                default:
                    return false;
            }

        }

       



       





    }
}
