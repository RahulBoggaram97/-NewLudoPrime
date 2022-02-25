using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;


namespace com.impactionalGames.LudoPrime
{
    public class oneWinner : lobbyUITemplate
    {
        public TypedLobby oneWinnerLobby1 = new TypedLobby("oneWinnerOne", LobbyType.Default);
        public TypedLobby oneWinnerLobby5 = new TypedLobby("oneWinnerFive", LobbyType.Default);
        public TypedLobby oneWinnerLobby10 = new TypedLobby("oneWinnerTen", LobbyType.Default);
        public TypedLobby oneWinnerLobby25 = new TypedLobby("oneWinnerTwentyFive", LobbyType.Default);
        public TypedLobby oneWinnerLobby50 = new TypedLobby("oneWinnerFifty", LobbyType.Default);
        public TypedLobby oneWinnerLobby100 = new TypedLobby("oneWinnerHundred", LobbyType.Default);


        public async void joinoneWinner1()
        {
            await manageTheFee();


            if (playerPermData.getMoney() > entryFee)

                PhotonNetwork.JoinLobby(oneWinnerLobby1);

            else redirectToPaymentOptions();
            Debug.Log("the joined lobby is : " + PhotonNetwork.CurrentLobby);

        }
        public async void joinoneWinner5()
        {
            await manageTheFee();

            if (playerPermData.getMoney() > entryFee)

                PhotonNetwork.JoinLobby(oneWinnerLobby5);

            else redirectToPaymentOptions();
            Debug.Log("the joined lobby is : " + PhotonNetwork.CurrentLobby);

        }
        public async void joinoneWinner10()
        {
            await manageTheFee();

            if (playerPermData.getMoney() > entryFee)

                PhotonNetwork.JoinLobby(oneWinnerLobby10);

            else redirectToPaymentOptions();
            Debug.Log("the joined lobby is : " + PhotonNetwork.CurrentLobby);

        }
        public async void joinoneWinner25()
        {
            await manageTheFee();

            if (playerPermData.getMoney() > entryFee)

                PhotonNetwork.JoinLobby(oneWinnerLobby25);

            else redirectToPaymentOptions();
            Debug.Log("the joined lobby is : " + PhotonNetwork.CurrentLobby);

        }
        public async void joinoneWinner50()
        {
            await manageTheFee();

            if (playerPermData.getMoney() > entryFee)

                PhotonNetwork.JoinLobby(oneWinnerLobby50);

            else redirectToPaymentOptions();
            Debug.Log("the joined lobby is : " + PhotonNetwork.CurrentLobby);

        }
        public async void joinoneWinner100()
        {
            await manageTheFee();

            if (playerPermData.getMoney() > entryFee)

                PhotonNetwork.JoinLobby(oneWinnerLobby100);

            else redirectToPaymentOptions();
            Debug.Log("the joined lobby is : " + PhotonNetwork.CurrentLobby);

        }


    }
}
