using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
   

namespace com.impactionalGames.LudoPrime
{
    public class oneVone : lobbyUITemplate
    {
        public TypedLobby oneVoneLobby1 = new TypedLobby("oneVoneOne", LobbyType.Default);
        public TypedLobby oneVoneLobby5 = new TypedLobby("oneVoneFive", LobbyType.Default);
        public TypedLobby oneVoneLobby10 = new TypedLobby("oneVoneTen", LobbyType.Default);
        public TypedLobby oneVoneLobby25 = new TypedLobby("oneVoneTwentyFive", LobbyType.Default);
        public TypedLobby oneVoneLobby50 = new TypedLobby("oneVoneFifty", LobbyType.Default);
        public TypedLobby oneVoneLobby100 = new TypedLobby("oneVoneHundred", LobbyType.Default);

        
        public async void joinOneVone1()
        {
            await manageTheFee();

            if (playerPermData.getMoney() > entryFee)

                PhotonNetwork.JoinLobby(oneVoneLobby1);

            else   redirectToPaymentOptions();
            Debug.Log("the joined lobby is : " + PhotonNetwork.CurrentLobby);

        }
        public async void joinOneVone5()
        {
            await manageTheFee();

            if (playerPermData.getMoney() > entryFee)

                PhotonNetwork.JoinLobby(oneVoneLobby5);

            else redirectToPaymentOptions();
            Debug.Log("the joined lobby is : " + PhotonNetwork.CurrentLobby);

        }
        public async void joinOneVone10()
        {
            await manageTheFee();


            if (playerPermData.getMoney() > entryFee)
                PhotonNetwork.JoinLobby(oneVoneLobby10);

            else redirectToPaymentOptions();
            Debug.Log("the joined lobby is : " + PhotonNetwork.CurrentLobby);

        }
        public async void joinOneVone25()
        {
            await manageTheFee();

            if (playerPermData.getMoney() > entryFee)
                PhotonNetwork.JoinLobby(oneVoneLobby25);

            else redirectToPaymentOptions();
            Debug.Log("the joined lobby is : " + PhotonNetwork.CurrentLobby);

        }
        public async void joinOneVone50()
        {
            await manageTheFee();


            if (playerPermData.getMoney() > entryFee)
                PhotonNetwork.JoinLobby(oneVoneLobby50);

            else redirectToPaymentOptions();
            Debug.Log("the joined lobby is : " + PhotonNetwork.CurrentLobby);

        }
        public async void joinOneVone100()
        {
            await manageTheFee();


            if (playerPermData.getMoney() > entryFee)
                PhotonNetwork.JoinLobby(oneVoneLobby100);

            else redirectToPaymentOptions();
            Debug.Log("the joined lobby is : " + PhotonNetwork.CurrentLobby);

        }


    }
}
