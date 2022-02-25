using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;


namespace com.impactionalGames.LudoPrime
{

    public class GameManager : MonoBehaviourPun, IPunObservable
    {

        [Header("Completed Players")]
        public int yellowCompletedPlayers = 0;
        public int redCompletedPlayers = 0;
        public int blueCompletedPlayers = 0;
        public int greenCompletedPlayers = 0;

        [Header("Total Players Can Play")]
        public int totalPlayersCanPlay;

        int nextDice;
        public static GameManager gm;
        List<PathPoints> playerOnPathPointsList = new List<PathPoints>();
    
        [Header("Bools to track Dice")]
        public bool canDiceRoll = true;
        public bool transferDice = false;
        public bool selfDice = false;
        public bool CanPlayerMove;

        [Header("Dice List")]
        public List<RollinDice> rollingDiceList;
        public RollinDice rolleddice;

        [Header("Number of steps to move")]
        public int numOfStepsToMove;

        [Header("Scenes")]
        public string walletCanvasname;


        private void Start()
        {
            gm = this;

            SceneManager.LoadSceneAsync(walletCanvasname, LoadSceneMode.Additive);
            
        }

        public void AddPathPoint(PathPoints pathPoint_)
        {
            playerOnPathPointsList.Add(pathPoint_);
        }

        public void RemovePathPoint(PathPoints pathPoint_)
        {
            if (playerOnPathPointsList.Contains(pathPoint_))
            {
                playerOnPathPointsList.Remove(pathPoint_);
            }

            else
            {
                Debug.Log("Path point not found");
            }
        }

      
        public void rollingDiceManagerCaller()
        {
            photonView.RPC("RollingDiceManager", RpcTarget.AllBufferedViaServer);
        }

        [PunRPC]
        public void RollingDiceManager()
        {
            if (transferDice && rolleddice.hasMoved)
            {
                shiftDice();
                rolleddice.hasMoved = false;
                rolleddice.hasRolled = false;
                Debug.Log("hasMoved set to false");
            }
            else if (selfDice)
            {
                selfDice = false;
                rolleddice.hasMoved = false;
                rolleddice.hasRolled = false;
                numOfStepsToMove = 0;
            }
            else
            {
                return;
            }

        }

        void shiftDice()
        {
            if (totalPlayersCanPlay == 1)
            {
                return;

            }
            else if (totalPlayersCanPlay == 2)
            {
                if (rolleddice == rollingDiceList[0])
                {
                    rollingDiceList[0].gameObject.SetActive(false);
                    rollingDiceList[2].gameObject.SetActive(true);
                    rollingDiceList[2].hasMoved = false;
                }
                else
                {
                    rollingDiceList[0].gameObject.SetActive(true);
                    rollingDiceList[0].hasMoved = false;
                    rollingDiceList[2].gameObject.SetActive(false);
                }
            }
            else if (totalPlayersCanPlay == 3)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (i == 0)
                    {
                        nextDice = 1;
                    }
                    if (i == 1)
                    {
                        nextDice = 2;
                    }

                    if (i == 2)
                    {
                        nextDice = 0;
                    }
                    if (rolleddice == rollingDiceList[i])
                    {
                        rollingDiceList[i].gameObject.SetActive(false);
                        rollingDiceList[nextDice].gameObject.SetActive(true);
                        rollingDiceList[nextDice].hasMoved = false;
                    }
                }
            }
            else
            {
                for (int i = 0; i < 4; i++)
                {
                    if (i == 0) { nextDice = 1; }
                    if (i == 1) { nextDice = 2; }
                    if (i == 2) { nextDice = 3; }
                    if (i == 3) { nextDice = 0; }
                    if (rolleddice == rollingDiceList[i])
                    {
                        rollingDiceList[i].gameObject.SetActive(false);
                        rollingDiceList[nextDice].gameObject.SetActive(true);
                        rollingDiceList[nextDice].hasMoved = false;
                    }
                }
            }
        }

        public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
        {
            if (stream.IsWriting)
            {
                stream.SendNext(totalPlayersCanPlay);
                stream.SendNext(nextDice);
                stream.SendNext(canDiceRoll);
                stream.SendNext(transferDice);
                stream.SendNext(selfDice);
                stream.SendNext(CanPlayerMove);
                stream.SendNext(numOfStepsToMove);
            }
            if (stream.IsReading)
            {
                totalPlayersCanPlay = (int)stream.ReceiveNext();
                nextDice = (int)stream.ReceiveNext();
                canDiceRoll = (bool)stream.ReceiveNext();
                transferDice = (bool)stream.ReceiveNext();
                selfDice = (bool)stream.ReceiveNext();
                CanPlayerMove = (bool)stream.ReceiveNext();
                numOfStepsToMove = (int)stream.ReceiveNext();
            }
        }
    }
}
