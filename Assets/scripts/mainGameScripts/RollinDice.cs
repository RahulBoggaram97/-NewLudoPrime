using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.Threading.Tasks;
using UnityEngine.UI;


namespace com.impactionalGames.LudoPrime
{
    //contains the score of the palyer
    public class RollinDice : MonoBehaviourPun, IPunObservable
    {

        public GameManager gm;

        [SerializeField] int numberGot;
        [SerializeField] GameObject rollinDiceAnime;
        [SerializeField] Sprite[] diceSprites;
        [SerializeField] SpriteRenderer dicRender;

        public bool hasRolled = false;
        public bool hasMoved = false;


        public int score = 0;

        public Text scoreText;

        private void OnMouseDown()
        {
            photonDiceRoll();
            numberGot = Random.Range(0, 6);
        }

        #region extracodeforPhoton

        //call in onMouseDown to enable Photon
        void photonDiceRoll()
        {
            if (photonView.IsMine)
            {
                
                photonView.RPC("onTapDiceRollFuntionCaller", RpcTarget.AllBufferedViaServer);
               
            }
        }

        //call in onMouseDown to disable Photon
        [PunRPC]
        void onTapDiceRollFuntionCaller()
        {
            
            preRollDice();
           
        }
        #endregion

        //set the info after or befor rolling dice
        async void preRollDice()
        {
            if (!this.hasRolled && !this.hasMoved)
            {

                await rollDice();


                gm.numOfStepsToMove = numberGot + 1;

                setScore(gm.numOfStepsToMove);  

                gm.rolleddice = this;
                this.hasRolled = true;
                //changetocallphoton
                gm.rollingDiceManagerCaller();
            }
            else
            {
                Debug.Log("has rolled value:" + this.hasRolled + "" +
                    "has moved value:" + this.hasMoved);
            }

            

        }

        //to set the score
        public void setScore(int scoreChange)
        {
            score = score + scoreChange;
            scoreText.text = score.ToString();
        }



        //changeTheway dice roll here
        async Task rollDice()
        {
            dicRender.gameObject.SetActive(false);
            rollinDiceAnime.SetActive(true);
            await Task.Delay(1000);

            rollinDiceAnime.SetActive(false);
            dicRender.gameObject.SetActive(true);
            dicRender.sprite = diceSprites[numberGot];

        }

        public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
        {
            if (stream.IsWriting)
            {
                stream.SendNext(numberGot);
                stream.SendNext(score);
            }
            else if (stream.IsReading)
            {
                numberGot = (int)stream.ReceiveNext();
                score = (int)stream.ReceiveNext();
            }
        }
    }
}
