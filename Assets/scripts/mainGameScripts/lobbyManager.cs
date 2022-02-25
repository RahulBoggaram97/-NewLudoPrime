using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using Photon.Realtime;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace com.impactionalGames.LudoPrime
{
    //added to the same object as game manager
    public class lobbyManager : MonoBehaviourPunCallbacks, IPunOwnershipCallbacks
    {
        public int totalPlayersCanPlay;

        [Header("Player names in lobby")]
        public Text[] lobbyText;

        [Header("Pieces and dice of particular color")]
        public LudoHomes[] colourPieces;

        [Header("Lobby Panel")]
        public GameObject lobbyPanel;

        public Text debugtextLobby;

        public Button startButton;

        [Header("Player images in lobby")]
        public GameObject[] playerLobyImageArray;

        [Header("In-Game UI")]
        public GameObject scoreGameObject;
        public GameObject inGameUserNameGameObject;

        

        

        private void Start()
        {
            checkWhichLobby();
           
            

            debugtextLobby.text = "the Room code is " + PhotonNetwork.CurrentRoom.Name;
        }

        private void Update()
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                if(PhotonNetwork.CurrentRoom.IsOpen != false)
                {
                    SceneManager.LoadScene("GameMenu");
                   
                    PhotonNetwork.LeaveRoom();
                    PhotonNetwork.LeaveLobby();
                }
            }
        }


        async Task updateLobbyDataCaller()
        {
            photonView.RPC("updateLobbyData", RpcTarget.AllBufferedViaServer);
            await Task.Yield();
        }

        [PunRPC]
        void updateLobbyData()
        {
            totalPlayersCanPlay = PhotonNetwork.PlayerList.Length;

            for(int i = 0; i < totalPlayersCanPlay; i++)
            {
                lobbyText[i].text = PhotonNetwork.PlayerList[i].NickName;
                
            }

        }

        public void lobbyStartButton()
        {
            

            photonView.RPC("ownershipTransferAtTheStart", RpcTarget.AllBufferedViaServer);
            
            
        }


        //transfer ownership to the pieces
        //set the dice active and then transer ownership and set inactive
        // 0= red, 1 = green 2=yellow 3=blue
        [PunRPC]
        void ownershipTransferAtTheStart()
        {
            
            //for two players
            if (PhotonNetwork.PlayerList.Length == 2)
            {
                //transferOwnershipOfPlayer(int indexForColourPieces(ludoHome), int player)
                transferOwnershipOfPlayerToColour(0, 0);

                transferOwnershipOfPlayerToColour(2, 1);

                colourPieces[2].dice.SetActive(true);
                colourPieces[2].dice.GetPhotonView().TransferOwnership(PhotonNetwork.PlayerList[1]);
                colourPieces[2].dice.SetActive(false);
                Debug.Log("it Enter the if condition");
                orientPlayerManager.orientPlayer.setGamePanelForTwo();


            }
            //for three players
            else if (PhotonNetwork.PlayerList.Length == 3)
            {
                transferOwnershipOfPlayerToColour(0, 0);

                transferOwnershipOfPlayerToColour(1, 1);
                colourPieces[1].dice.SetActive(true);
                colourPieces[1].dice.GetPhotonView().TransferOwnership(PhotonNetwork.PlayerList[1]);
                colourPieces[1].dice.SetActive(false);


                transferOwnershipOfPlayerToColour(2, 2);
                colourPieces[2].dice.SetActive(true);
                colourPieces[2].dice.GetPhotonView().TransferOwnership(PhotonNetwork.PlayerList[2]);
                colourPieces[2].dice.SetActive(false);
                orientPlayerManager.orientPlayer.setGamePanelForThree();

            }
            //for four players
            else if (PhotonNetwork.PlayerList.Length == 4)
            {
                transferOwnershipOfPlayerToColour(0, 0);

                transferOwnershipOfPlayerToColour(1, 1);
                colourPieces[1].dice.SetActive(true);
                colourPieces[1].dice.GetPhotonView().TransferOwnership(PhotonNetwork.PlayerList[1]);
                colourPieces[1].dice.SetActive(false);


                transferOwnershipOfPlayerToColour(2, 2);
                colourPieces[2].dice.SetActive(true);
                colourPieces[2].dice.GetPhotonView().TransferOwnership(PhotonNetwork.PlayerList[2]);
                colourPieces[2].dice.SetActive(false);

                transferOwnershipOfPlayerToColour(3, 3);
                colourPieces[3].dice.SetActive(true);
                colourPieces[3].dice.GetPhotonView().TransferOwnership(PhotonNetwork.PlayerList[4]);
                colourPieces[3].dice.SetActive(false);
                orientPlayerManager.orientPlayer.setGamePanelForFour();


            }
            else
            {
                return;
            }
            lobbyPanel.SetActive(false);

            this.gameObject.GetComponent<GameManager>().totalPlayersCanPlay = this.totalPlayersCanPlay;
            PhotonNetwork.CurrentRoom.IsOpen = false;
            PhotonNetwork.CurrentRoom.IsVisible = false;

            scoreGameObject.SetActive(true);
            inGameUserNameGameObject.SetActive(true);

        }

        //actives the parent object of the peices i.e. "ludo home"
        //then transfer the ownership of the peices
        void transferOwnershipOfPlayerToColour(int index, int player)
        {
            colourPieces[index].gameObject.SetActive(true);

            colourPieces[index].playerPieces[0].gameObject.GetPhotonView().TransferOwnership(PhotonNetwork.PlayerList[player]);
            colourPieces[index].playerPieces[1].gameObject.GetPhotonView().TransferOwnership(PhotonNetwork.PlayerList[player]);
            colourPieces[index].playerPieces[2].gameObject.GetPhotonView().TransferOwnership(PhotonNetwork.PlayerList[player]);
            colourPieces[index].playerPieces[3].gameObject.GetPhotonView().TransferOwnership(PhotonNetwork.PlayerList[player]);

        }

        //this one for rotating board
        //called in ownershipTransferAtTheStart()
       

        #region check which lobby
        //checks in which lobby we are then behave accordingly
        async void checkWhichLobby()
        {
            await updateLobbyDataCaller();

            if(checkIfItsOneVoneLobby() )
            {
                startButton.gameObject.SetActive(false);
                setUpForOneVOneLobby();

                
            }
            else if(!chechIfItsCustomLobby())
            {
                setUpForFourPlayerGame();
                startButton.gameObject.SetActive(false);
            }
            else
            {
               startButton.gameObject.SetActive(true);
                return;
            }
        }

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
        

        void setUpForOneVOneLobby()
        {
            debugtextLobby.gameObject.SetActive(false);
            startButton.gameObject.SetActive(false);


            playerLobyImageArray[2].SetActive(false);
            playerLobyImageArray[3].SetActive(false);
            


            if(PhotonNetwork.PlayerList.Length == 2)
            {
                lobbyStartButton();
            }
            else
            {
                return;
            }

        }

        void setUpForFourPlayerGame()
        {
            debugtextLobby.gameObject.SetActive(false);
            startButton.gameObject.SetActive(false);

            if (PhotonNetwork.PlayerList.Length == 4)
            {
                lobbyStartButton();
            }
            else
            {
                return;
            }
        }

        #endregion

        #region ipuncallbacks
        public void OnOwnershipRequest(PhotonView targetView, Player requestingPlayer)
        {
            throw new System.NotImplementedException();
        }

        public void OnOwnershipTransfered(PhotonView targetView, Player previousOwner)
        {
            
        }

        public void OnOwnershipTransferFailed(PhotonView targetView, Player senderOfFailedRequest)
        {
            throw new System.NotImplementedException();
        }
        #endregion

        
    }
}
