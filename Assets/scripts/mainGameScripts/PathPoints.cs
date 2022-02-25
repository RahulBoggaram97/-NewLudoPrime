using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace com.impactionalGames.LudoPrime
{
    public class PathPoints : MonoBehaviour
    {
       

        PathPoints[] pathpointToMoveon_;
        public PathObjectsParent pathObjectParent;
        public List<PlayerPiece> playerPieces = new List<PlayerPiece>();

        void Start()
        {
            pathObjectParent = GetComponentInParent<PathObjectsParent>();
        }

        public bool AddPlayerPiece(PlayerPiece playerPiece_)
        {
            if (this.name == "CentreHomePoint") { Completed(playerPiece_); }
            else if (this.name != "PathPoints" && this.name != "PathPoints (8)" && this.name != "PathPoints (13)" && this.name != "PathPoints (21)" && this.name != "PathPoints (26)" && this.name != "PathPoints (34)" && this.name != "PathPoints (39)" && this.name != "PathPoints (47)" && this.name != "CentreHomePoint")
            {
                if (playerPieces.Count == 1)
                {
                    string prePlayerPieceName = playerPieces[0].name;
                    string curPlayerPieceName = playerPiece_.name;
                    curPlayerPieceName = curPlayerPieceName.Substring(0, curPlayerPieceName.Length - 4);

                    if (!prePlayerPieceName.Contains(curPlayerPieceName))
                    {
                        

                        StartCoroutine(revertOnStart(playerPieces[0]));


                        playerPieces[0].numberOfStepsAlreadyMoved = 0;

                        
                        RemovePlayerPiece(playerPieces[0]);
                        playerPieces.Add(playerPiece_);

                        

                        ////playerpiece.dice.setScore(-previousPlayer.indivdualScore);
                        return false;
                    }

                    else if(prePlayerPieceName.Contains(curPlayerPieceName))
                    {
                        //if they are of same colour we lower the scale and offsets them a bit
                        playerPieces[0].gameObject.transform.localScale = new Vector3(0.06f, 0.06f, 0.06f);


                        playerPieces[0].transform.position = playerPieces[0].transform.position + new Vector3(0.07f, 0f, 0f);

                        playerPiece_.gameObject.transform.localScale = new Vector3(0.06f, 0.06f, 0.06f);


                        playerPiece_.transform.position = playerPieces[0].transform.position + new Vector3(-0.14f, 0f, 0f);


                        addPlayer(playerPiece_);
                        return true;
                    }
                }

               
            }
            addPlayer(playerPiece_);
            return true;
        }

        IEnumerator revertOnStart(PlayerPiece playerPiece_)
        {
            if (playerPiece_.name.Contains("Yellow")) 
            {  
                pathpointToMoveon_ = pathObjectParent.yellowPathPoints;
            }
            else if (playerPiece_.name.Contains("Green")) 
            {
                 pathpointToMoveon_ = pathObjectParent.greenPathPoints; 
            }
            else if (playerPiece_.name.Contains("Red")) 
            {
                 pathpointToMoveon_ = pathObjectParent.redPathPoints; 
            }
            else if (playerPiece_.name.Contains("Blue")) 
            {
                 pathpointToMoveon_ = pathObjectParent.bluePathPoints; 
            }

            for (int i = playerPiece_.numberOfStepsAlreadyMoved - 1; i >= 0; i--)
            {
                playerPiece_.transform.position = pathpointToMoveon_[i].transform.position;
                yield return new WaitForSeconds(0.03f);
            }

            playerPiece_.transform.position = pathObjectParent.BasePoints[BasePointPosition(playerPiece_)].transform.position;
            playerPiece_.transform.localScale  = new Vector3(0.06f, 0.06f, 0.06f);
        }


        int BasePointPosition(PlayerPiece playerPiece_)
        {
            if (playerPiece_.name.Contains("Yellow")) 
            { 
               for(int i = 0; i<=3; i++)
                {
                    if(pathObjectParent.BasePoints[i].playerPieces.Count == 0)
                    {
                        addPlayer(playerPiece_);
                        return i;
                    }
                }
            }
            else if (playerPiece_.name.Contains("Green"))
            {
                for (int i = 4; i <=7; i++)
                {
                    if (pathObjectParent.BasePoints[i].playerPieces.Count == 0)
                    {
                        addPlayer(playerPiece_);
                        return i;
                    }
                }
            }
            else if (playerPiece_.name.Contains("Red")) 
            {
                for (int i = 8; i <= 11; i++)
                {
                    if (pathObjectParent.BasePoints[i].playerPieces.Count == 0)
                    {
                        addPlayer(playerPiece_);
                        return i;
                    }
                }
            }
            else if (playerPiece_.name.Contains("Blue")) 
            {
                for (int i = 12; i <= 15; i++)
                {
                    if (pathObjectParent.BasePoints[i].playerPieces.Count == 0)
                    {
                        addPlayer(playerPiece_);
                        return i;
                    }
                }
            }

            return -1;
        }


        void addPlayer(PlayerPiece playerPiece_)
        {
            playerPieces.Add(playerPiece_);
        }

        public void RemovePlayerPiece(PlayerPiece playerPiece_)
        {
            if (playerPieces.Contains(playerPiece_))
            {
                playerPieces.Remove(playerPiece_);
            }
            else
            {
                return;
            }
        }

        private void Completed(PlayerPiece playerPiece_)
        {
            if (playerPiece_.name.Contains("Yellow"))
            {
                GameManager.gm.yellowCompletedPlayers += 1;
                
                if (GameManager.gm.yellowCompletedPlayers == 4)
                {
                    manageWin();
                }
            }
            else if (playerPiece_.name.Contains("Green")) 
            { 
                GameManager.gm.greenCompletedPlayers += 1;

                if (GameManager.gm.greenCompletedPlayers == 4) 
                {
                    manageWin();
                } 
            }
            else if (playerPiece_.name.Contains("Red"))
            { 
                GameManager.gm.redCompletedPlayers += 1;
                if (GameManager.gm.redCompletedPlayers == 4)
                {
                    manageWin();
                } 
            }
            else if (playerPiece_.name.Contains("Blue"))
            { 
                GameManager.gm.blueCompletedPlayers += 1;
                if (GameManager.gm.blueCompletedPlayers == 4)
                {
                    manageWin();
                }
            }

        }

        void manageWin()
        {
            EndGameManager.egm.winStarterMethod();
        }
    }
}
