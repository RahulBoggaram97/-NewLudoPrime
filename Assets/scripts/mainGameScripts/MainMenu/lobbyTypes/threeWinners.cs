using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;


namespace com.impactionalGames.LudoPrime
{
    public class threeWinners : lobbyUITemplate
    {
        public TypedLobby threeWinnersLobby1 = new TypedLobby("threeWinnersOne", LobbyType.Default);
        public TypedLobby threeWinnersLobby5 = new TypedLobby("threeWinnersFive", LobbyType.Default);
        public TypedLobby threeWinnersLobby10 = new TypedLobby("threeWinnersTen", LobbyType.Default);
        public TypedLobby threeWinnersLobby25 = new TypedLobby("threeWinnersTwentyFive", LobbyType.Default);
        public TypedLobby threeWinnersLobby50 = new TypedLobby("threeWinnersFifty", LobbyType.Default);
        public TypedLobby threeWinnersLobby100 = new TypedLobby("threeWinnersHundred", LobbyType.Default);


        public async void jointhreeWinners1()
        {
            await manageTheFee();

            if (playerPermData.getMoney() > entryFee)

                PhotonNetwork.JoinLobby(threeWinnersLobby1);

            else redirectToPaymentOptions();
            Debug.Log("the joined lobby is : " + PhotonNetwork.CurrentLobby);

        }
        public async void jointhreeWinners5()
        {
            await manageTheFee();

            if (playerPermData.getMoney() > entryFee)

                PhotonNetwork.JoinLobby(threeWinnersLobby5);

            else redirectToPaymentOptions();
            Debug.Log("the joined lobby is : " + PhotonNetwork.CurrentLobby);

        }
        public async void jointhreeWinners10()
        {
            await manageTheFee();

            if (playerPermData.getMoney() > entryFee)

                PhotonNetwork.JoinLobby(threeWinnersLobby10);

            else redirectToPaymentOptions();
            Debug.Log("the joined lobby is : " + PhotonNetwork.CurrentLobby);

        }
        public async void jointhreeWinners25()
        {
            await manageTheFee();

            if (playerPermData.getMoney() > entryFee)

                PhotonNetwork.JoinLobby(threeWinnersLobby25);

            else redirectToPaymentOptions();
            Debug.Log("the joined lobby is : " + PhotonNetwork.CurrentLobby);

        }
        public async void jointhreeWinners50()
        {
            await manageTheFee();


            if (playerPermData.getMoney() > entryFee)

                PhotonNetwork.JoinLobby(threeWinnersLobby50);

            else redirectToPaymentOptions();
            Debug.Log("the joined lobby is : " + PhotonNetwork.CurrentLobby);

        }
        public async void jointhreeWinners100()
        {
            await manageTheFee();

            if (playerPermData.getMoney() > entryFee)

                PhotonNetwork.JoinLobby(threeWinnersLobby100);

            else redirectToPaymentOptions();
            Debug.Log("the joined lobby is : " + PhotonNetwork.CurrentLobby);

        }

    }
}
