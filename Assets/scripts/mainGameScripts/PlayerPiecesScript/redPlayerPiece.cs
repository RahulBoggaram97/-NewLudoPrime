using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace com.impactionalGames.LudoPrime
{
    public class redPlayerPiece : PlayerPiece
    {
        public GameManager gm;
        public RollinDice redDice;
        public int individualScore;

        

        private void OnMouseDown()
        {
            photonCaller();

        }

        void photonCaller()
        {
            if (photonView.IsMine)
            {
                vibrationTest.vibrate(100);
                photonView.RPC("movePiece", RpcTarget.AllBufferedViaServer);
            }

        }

        

        [PunRPC]
        void movePiece()
        {
            if(gm.rolleddice == redDice && gm.rolleddice.hasRolled && !gm.rolleddice.hasMoved && redDice.gameObject.activeSelf)
            {
                if(gm.numOfStepsToMove != 0)
                {
                    canMove = true;
                    gm.rolleddice.hasMoved = true;
                    MoveSteps(pathsParent.redPathPoints);
                    individualsetScore(gm.numOfStepsToMove);

                }
                else
                {
                    Debug.Log("numOfSetpsToMove is zero, there is a problem with the dice");
                }

            }
            else
            {
                Debug.Log("rolled dice is " + gm.rolleddice.gameObject.name + "" +
                    "hasRolled value:"+ gm.rolleddice.hasRolled + "" +
                    "hasMoved value:" + gm.rolleddice.hasMoved + "" +
                    "redice activeSelf value:"+ redDice.gameObject.activeSelf);
            }
        }

        void individualsetScore(int individualScroeChanged)
        {
            individualScore = individualScore + individualScroeChanged;
        }
    }
}
