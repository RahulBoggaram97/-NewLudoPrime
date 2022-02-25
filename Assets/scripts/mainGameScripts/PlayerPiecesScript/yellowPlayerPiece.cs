using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace com.impactionalGames.LudoPrime
{
    public class yellowPlayerPiece : PlayerPiece
    {
        public GameManager gm;
        public RollinDice yellowDice;



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
            if (gm.rolleddice == yellowDice && gm.rolleddice.hasRolled && !gm.rolleddice.hasMoved && yellowDice.gameObject.activeSelf)
            {
                if (gm.numOfStepsToMove != 0)
                {
                    canMove = true;
                    gm.rolleddice.hasMoved = true;
                    MoveSteps(pathsParent.yellowPathPoints);
                }
                else
                {
                    Debug.Log("numOfSetpsToMove is zero, there is a problem with the dice");
                }

            }
            else
            {
                Debug.Log("rolled dice is " + gm.rolleddice.gameObject.name + "" +
                    "hasRolled value:" + gm.rolleddice.hasRolled + "" +
                    "hasMoved value:" + gm.rolleddice.hasMoved + "" +
                    "redice activeSelf value:" + yellowDice.gameObject.activeSelf);
            }
        }
    }
}
