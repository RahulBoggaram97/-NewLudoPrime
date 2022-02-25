using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace com.impactionalGames.LudoPrime
{

    public class CreateAndJoinRooms : MonoBehaviourPunCallbacks
    {
        string gameVersion = "1";
        [Header("Input Field For Creating Private Room")]
        [SerializeField] private InputField createFeild;
        [SerializeField] private InputField joinFeild;

        public byte maxPlayerPerRoom = 4;

        public string levelToLoad;

        [Header("Panels:")]
        public GameObject loadingPanel;
        public GameObject mainMenuPanel;
        public GameObject playOnlinePanel;
        public GameObject playWithFriendsMenuPanel;

        

        [Header("debug:")]
        public Text debugText;
        public string roomCode;

        

        TypedLobby customLobby = new TypedLobby("customLobby", LobbyType.Default);


        [Header("Scenes")]
        public string walletCanvasUi;

        private void Awake()
        {
            PhotonNetwork.AutomaticallySyncScene = true;
           
        }

        private void Start()
        {
            loadingPanel.SetActive(true);
            mainMenuPanel.SetActive(false);
            playOnlinePanel.SetActive(false);
            playWithFriendsMenuPanel.SetActive(false);

            playerPermData.setPhoneNumber("9876543210");
            connect();

           
            
        }

       

        public void connect()
        {

            if (PhotonNetwork.IsConnected)
            {

                Debug.Log(PhotonNetwork.CurrentLobby.Name + " is the lobby and  the room is " + PhotonNetwork.CurrentRoom.Name);
            }
            else
            {

                PhotonNetwork.ConnectUsingSettings();
                PhotonNetwork.GameVersion = gameVersion;
            }
            loadingPanel.SetActive(true );
        }



        public override void OnConnectedToMaster()
        {


            //have to wait for this message in order to use the create button
            Debug.Log("the server has made or connected, now we can create room");
            loadingPanel.SetActive(false);
            mainMenuPanel.SetActive(true);
            //walletBarPanel.SetActive(true);
            SceneManager.LoadSceneAsync(walletCanvasUi, LoadSceneMode.Additive);
            

            


        }

       


        //playerwithfriends create room
        public  void joinLobby()
        {
            PhotonNetwork.JoinLobby(customLobby);
        }

        public void createRoom()
        {
            PhotonNetwork.NickName = playerPermData.getUserName();
            Debug.Log("current lobby is " + PhotonNetwork.CurrentLobby.Name);

            roomCode = gernrateRandomRoomCode();

            PhotonNetwork.NickName = playerPermData.getUserName();

            PhotonNetwork.CreateRoom(roomCode);



        }


        //genrated a random 4 alphabets code for the room name
        private string gernrateRandomRoomCode()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            char[] stringchars = new char[4];



            for (int i = 0; i < stringchars.Length; i++)
            {
                stringchars[i] = chars[Random.Range(0, chars.Length -1)];
                Debug.Log(i);
                Debug.Log(chars[i]);
                
            }

            string finalRoomCode = new string(stringchars);

            return finalRoomCode;
        }


        

        public override void OnCreateRoomFailed(short returnCode, string message)
        {
            debugText.text = message + " " + returnCode.ToString();

            Debug.Log(returnCode.ToString());
        }




        //playewithFriends join Room
        public void joinRoom()
        {
            PhotonNetwork.NickName = playerPermData.getUserName();
            PhotonNetwork.JoinRoom(joinFeild.text);
        }

        public override void OnJoinRoomFailed(short returnCode, string message)
        {
            debugText.text = message + " " + returnCode.ToString();

            Debug.Log(returnCode.ToString());
        }


        public void onPressBackForPlayWithFriendsButton()
        {
            if (PhotonNetwork.CurrentRoom != null)
            {
                PhotonNetwork.LeaveRoom();
            }
            PhotonNetwork.LeaveLobby();
            
        }

        //takes you to the other 
        public override void OnJoinedRoom()
        {
            //meaning that you have created or joined room;
            
            PhotonNetwork.LoadLevel(levelToLoad);

        }

       

    }
}
