using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

namespace com.impactionalGames.LudoPrime
{
    public class orientPlayerManager : MonoBehaviour
    {
        public static orientPlayerManager orientPlayer;


        public GameObject ludoBoard;


        public SpriteRenderer[] playerColourSpriteRenderer;

        //contains the sprite that need to be swapped
        //while rotating board
        //// 0= red, 1 = green 2=yellow 3=blue
        public Sprite[] spriteCollection;

        public GameObject[] scoreArray;

        public Transform[] dicePostions;

        public Text[] inGameUsername;

        public GameObject[] dices;

        public lobbyManager lobMan;



        private void Start()
        {
            orientPlayer = this;
        }

        public void setGamePanelForTwo()
        {
            if (PhotonNetwork.LocalPlayer == PhotonNetwork.PlayerList[0])
            {
                //setting the userNames
                inGameUsername[0].text = PhotonNetwork.PlayerList[0].NickName;
                inGameUsername[1].gameObject.SetActive(false);
                inGameUsername[2].text = PhotonNetwork.PlayerList[1].NickName;
                inGameUsername[3].gameObject.SetActive(false);

                //setting the scores
                scoreArray[0].gameObject.SetActive(true);
                scoreArray[1].gameObject.SetActive(false);
                scoreArray[2].gameObject.SetActive(true);
                scoreArray[3].gameObject.SetActive(false);

                //setting up the box next to the dice
                playerColourSpriteRenderer[0].sprite = spriteCollection[0];
                playerColourSpriteRenderer[1].sprite = null;
                playerColourSpriteRenderer[2].sprite = spriteCollection[2];
                playerColourSpriteRenderer[3].sprite = null;


                //setting up the dices

                //setting up the player pieces


            }

            else if (PhotonNetwork.LocalPlayer == PhotonNetwork.PlayerList[1])
            {
                ludoBoard.transform.Rotate(0, 0, 180);

                //setting the userNames
                inGameUsername[0].text = PhotonNetwork.PlayerList[1].NickName;
                inGameUsername[1].gameObject.SetActive(false);
                inGameUsername[2].text = PhotonNetwork.PlayerList[0].NickName;
                inGameUsername[3].gameObject.SetActive(false);

                //setting the scores
                scoreArray[1].gameObject.SetActive(false);
                scoreArray[3].gameObject.SetActive(false);
                swapScoreArrays(0, 2);

                //setting up the box next to the dice
                playerColourSpriteRenderer[0].sprite = spriteCollection[2];
                playerColourSpriteRenderer[1].sprite = null;
                playerColourSpriteRenderer[2].sprite = spriteCollection[0];
                playerColourSpriteRenderer[3].sprite = null;

                //setting up the dices
                swapDicePosition(0, 2);

                //setting up the player pieces
                rotatePlayerPieces(0, 180);
                rotatePlayerPieces(2, 180);

            }
            else
            {
                return;
            }

        }

        public void setGamePanelForThree()
        {
            if (PhotonNetwork.LocalPlayer == PhotonNetwork.PlayerList[0])
            {
                //setting the userNames
                inGameUsername[0].text = PhotonNetwork.PlayerList[0].NickName;
                inGameUsername[1].text = PhotonNetwork.PlayerList[1].NickName;
                inGameUsername[2].text = PhotonNetwork.PlayerList[2].NickName;
                inGameUsername[3].gameObject.SetActive(false);

                //setting the scores
                scoreArray[0].gameObject.SetActive(true);
                scoreArray[1].gameObject.SetActive(true);
                scoreArray[2].gameObject.SetActive(true);
                scoreArray[3].gameObject.SetActive(false);

                //setting up the box next to the dice
                playerColourSpriteRenderer[0].sprite = spriteCollection[0];
                playerColourSpriteRenderer[1].sprite = spriteCollection[1];
                playerColourSpriteRenderer[2].sprite = spriteCollection[2];
                playerColourSpriteRenderer[3].sprite = null;

            }

            else if (PhotonNetwork.LocalPlayer == PhotonNetwork.PlayerList[1])
            {
                //setting the userNames
                ludoBoard.transform.Rotate(0, 0, 90);
                inGameUsername[0].text = PhotonNetwork.PlayerList[1].NickName;
                inGameUsername[1].text = PhotonNetwork.PlayerList[2].NickName;
                inGameUsername[2].gameObject.SetActive(false);
                inGameUsername[3].text = PhotonNetwork.PlayerList[0].NickName;

                //setting the scores
                swapScoreArrays(0, 3);
                swapScoreArrays(1, 3);
                swapScoreArrays(3, 2);
                scoreArray[3].gameObject.SetActive(false);

                //setting up the box next to the dice
                playerColourSpriteRenderer[0].sprite = spriteCollection[1];
                playerColourSpriteRenderer[1].sprite = spriteCollection[2];
                playerColourSpriteRenderer[2].sprite = null;
                playerColourSpriteRenderer[3].sprite = spriteCollection[0];

                //setting up the dices
                swapDicePosition(0, 3);
                swapDicePosition(1, 3);
                swapDicePosition(3, 2);

                //setting up the player pieces
                rotatePlayerPieces(0, 90);
                rotatePlayerPieces(1, 90);
                rotatePlayerPieces(2, 90);

            }

            else if (PhotonNetwork.LocalPlayer == PhotonNetwork.PlayerList[2])
            {
                //setting the userNames
                ludoBoard.transform.Rotate(0, 0, 180);
                inGameUsername[0].text = PhotonNetwork.PlayerList[2].NickName;
                inGameUsername[1].gameObject.SetActive(false);
                inGameUsername[2].text = PhotonNetwork.PlayerList[0].NickName;
                inGameUsername[3].text = PhotonNetwork.PlayerList[1].NickName;

                //setting the scores
                swapScoreArrays(0, 2);
                swapScoreArrays(1, 3);
                scoreArray[3].gameObject.SetActive(false);

                //setting up the box next to the dice
                playerColourSpriteRenderer[0].sprite = spriteCollection[2];
                playerColourSpriteRenderer[1].sprite = null;
                playerColourSpriteRenderer[2].sprite = spriteCollection[0];
                playerColourSpriteRenderer[3].sprite = spriteCollection[1];

                //setting up the dices
                swapDicePosition(0, 2);
                swapDicePosition(1, 3);

                //setting up the player pieces
                rotatePlayerPieces(0, 180);
                rotatePlayerPieces(1, 180);
                rotatePlayerPieces(2, 180);

            }

            else
            {
                return;
            }
        }

        public void setGamePanelForFour()
        {
            if (PhotonNetwork.LocalPlayer == PhotonNetwork.PlayerList[0])
            {
                //setting the userNames
                inGameUsername[0].text = PhotonNetwork.PlayerList[0].NickName;
                inGameUsername[1].text = PhotonNetwork.PlayerList[1].NickName;
                inGameUsername[2].text = PhotonNetwork.PlayerList[2].NickName;
                inGameUsername[3].text = PhotonNetwork.PlayerList[3].NickName;

                //setting the scores
                scoreArray[0].gameObject.SetActive(true);
                scoreArray[1].gameObject.SetActive(true);
                scoreArray[2].gameObject.SetActive(true);
                scoreArray[3].gameObject.SetActive(true);

                //setting up the box next to the dice
                playerColourSpriteRenderer[0].sprite = spriteCollection[0];
                playerColourSpriteRenderer[1].sprite = spriteCollection[1];
                playerColourSpriteRenderer[2].sprite = spriteCollection[2];
                playerColourSpriteRenderer[3].sprite = spriteCollection[3];

            }

            else if (PhotonNetwork.LocalPlayer == PhotonNetwork.PlayerList[1])
            {
                ludoBoard.transform.Rotate(0, 0, 90);

                //setting the userNames
                inGameUsername[0].text = PhotonNetwork.PlayerList[1].NickName;
                inGameUsername[1].text = PhotonNetwork.PlayerList[2].NickName;
                inGameUsername[2].text = PhotonNetwork.PlayerList[3].NickName;
                inGameUsername[3].text = PhotonNetwork.PlayerList[0].NickName;

                //setting the scores
                swapScoreArrays(0, 3);
                swapScoreArrays(1, 3);
                swapScoreArrays(3, 2);

                //setting up the box next to the dice
                playerColourSpriteRenderer[0].sprite = spriteCollection[1];
                playerColourSpriteRenderer[1].sprite = spriteCollection[2];
                playerColourSpriteRenderer[2].sprite = spriteCollection[3];
                playerColourSpriteRenderer[3].sprite = spriteCollection[0];

                //setting up the dices
                swapDicePosition(0, 3);
                swapDicePosition(1, 3);
                swapDicePosition(3, 2);

                //setting up the player pieces
                rotatePlayerPieces(0, 90);
                rotatePlayerPieces(1, 90);
                rotatePlayerPieces(2, 90);
                rotatePlayerPieces(3, 90);

            }

            else if (PhotonNetwork.LocalPlayer == PhotonNetwork.PlayerList[2])
            {
                ludoBoard.transform.Rotate(0, 0, 180);

                //setting the userNames
                inGameUsername[0].text = PhotonNetwork.PlayerList[2].NickName;
                inGameUsername[1].text = PhotonNetwork.PlayerList[3].NickName;
                inGameUsername[2].text = PhotonNetwork.PlayerList[0].NickName;
                inGameUsername[3].text = PhotonNetwork.PlayerList[1].NickName;

                //setting the scores
                swapScoreArrays(0, 2);
                swapScoreArrays(1, 3);

                //setting up the box next to the dice
                playerColourSpriteRenderer[0].sprite = spriteCollection[2];
                playerColourSpriteRenderer[1].sprite = spriteCollection[3];
                playerColourSpriteRenderer[2].sprite = spriteCollection[0];
                playerColourSpriteRenderer[3].sprite = spriteCollection[1];

                //setting up the dices
                swapDicePosition(0, 2);
                swapDicePosition(1, 3);

                //setting up the player pieces
                rotatePlayerPieces(0, 180);
                rotatePlayerPieces(1, 180);
                rotatePlayerPieces(2, 180);
                rotatePlayerPieces(3, 180);

            }

            else if (PhotonNetwork.LocalPlayer == PhotonNetwork.PlayerList[3])
            {
                ludoBoard.transform.Rotate(0, 0, 270);

                //setting the userNames
                inGameUsername[0].text = PhotonNetwork.PlayerList[3].NickName;
                inGameUsername[1].text = PhotonNetwork.PlayerList[0].NickName;
                inGameUsername[2].text = PhotonNetwork.PlayerList[1].NickName;
                inGameUsername[3].text = PhotonNetwork.PlayerList[2].NickName;

                //setting the scores
                swapScoreArrays(1, 0);
                swapScoreArrays(1, 3);
                swapScoreArrays(2, 1);

                //setting up the box next to the dice
                playerColourSpriteRenderer[0].sprite = spriteCollection[3];
                playerColourSpriteRenderer[1].sprite = spriteCollection[0];
                playerColourSpriteRenderer[2].sprite = spriteCollection[1];
                playerColourSpriteRenderer[3].sprite = spriteCollection[2];

                //setting up the dices
                swapDicePosition(1, 0);
                swapDicePosition(1, 3);
                swapDicePosition(2, 1);

                //setting up the player pieces
                rotatePlayerPieces(0, 270);
                rotatePlayerPieces(1, 270);
                rotatePlayerPieces(2, 270);
                rotatePlayerPieces(3, 270);

            }


        }


        void swapScoreArrays(int index1, int index2)
        {
            Vector3 temp = scoreArray[index1].transform.position;

            scoreArray[index1].transform.position = scoreArray[index2].transform.position;
            scoreArray[index2].transform.position = temp;
        }

        void swapDicePosition(int index1, int index2)
        {
            Vector3 temp = dices[index1].transform.position;

            dices[index1].transform.position = dices[index2].transform.position;
            dices[index2].transform.position = temp;
        }

        void rotatePlayerPieces(int colourIndex, float zRotation)
        {
            lobMan.colourPieces[colourIndex].playerPieces[0].transform.Rotate(0f, 0f, zRotation);
            lobMan.colourPieces[colourIndex].playerPieces[1].transform.Rotate(0f, 0f, zRotation);
            lobMan.colourPieces[colourIndex].playerPieces[2].transform.Rotate(0f, 0f, zRotation);
            lobMan.colourPieces[colourIndex].playerPieces[3].transform.Rotate(0f, 0f, zRotation);
        }
    }

}