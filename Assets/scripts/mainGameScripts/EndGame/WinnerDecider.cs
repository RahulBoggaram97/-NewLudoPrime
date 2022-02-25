using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Photon.Pun;
using System;

namespace com.impactionalGames.LudoPrime
{
    public class WinnerDecider : MonoBehaviour
    {
        public RollinDice[] scoreDice;

        public winOrLossState rank;

        public prizeDistibutor distributor;

        [Header("Variables")]
        public int rank1Index = 0;
        public int rank2Index = 0;
        public int rank3Index = 0;
        public int rank4Index = 0;

        //FOR 2 PLAYERS
        public void decideOnevOneWinner()
        {
            int[] scorArr = new int[] {scoreDice[0].score, scoreDice[2].score};

            int maxScore = scorArr.Max();
             
           
           
            //finding rank1
            for (int i = 0; i < scoreDice.Length; i++)
            {
                if( i != 1 &&  i !=3)
                {
                    if (maxScore == scoreDice[i].score)
                    {
                        rank1Index = i;
                    }

                }

                
            }


            //finding rank2
            if( rank1Index == 0)
            {
                rank2Index = 1;
            }
            else if( rank1Index == 2)
            {
                rank1Index = 1;
                rank2Index = 0;
            }

            if(PhotonNetwork.LocalPlayer == PhotonNetwork.PlayerList[rank1Index])
            {
                rank = winOrLossState.rankOne;
            }
            else
            {
                rank = winOrLossState.rankTwo;
            }

            //directs to the distributor
            distributor.distributePrizeOneVOne();
        }


        //FOR FOUR PLAYERS
        public void decideFourPlayerGameWinner()
        {
            List<int> scorArr = new List<int> { scoreDice[0].score, scoreDice[1].score, scoreDice[2].score, scoreDice[3].score };

            

            int maxScore = (from number in scorArr
                                 orderby number descending
                                 select number).Distinct().First();
            //finding rank1
            for (int i = 0; i < scoreDice.Length; i++)
            {
                if (maxScore == scoreDice[i].score)
                {
                    rank1Index = i;
                   
                }
            }

            if (PhotonNetwork.LocalPlayer == PhotonNetwork.PlayerList[rank1Index])
            {
                rank = winOrLossState.rankOne;
            }
            
             //finding rank2
             maxScore = (from number in scorArr
                            orderby number descending
                            select number).Distinct().Skip(1).First();

             for (int i = 0; i < scoreDice.Length; i++)
             {
                 if (maxScore == scoreDice[i].score)
                 {
                     rank2Index = i;
                        
                 }
             }

             if (PhotonNetwork.LocalPlayer == PhotonNetwork.PlayerList[rank2Index])
             {
                  rank = winOrLossState.rankTwo;
             }

             //finding rank3  
             maxScore = (from number in scorArr
                         orderby number descending
                         select number).Distinct().Skip(2).First();

            for (int i = 0; i <= scoreDice.Length; i++)
            {
                 if (maxScore == scoreDice[i].score)
                 {
                      rank3Index = i;
                            
                 }
            }

            if (PhotonNetwork.LocalPlayer == PhotonNetwork.PlayerList[rank3Index])
            {
                        rank = winOrLossState.rankThree;
            }


            //finding rank4    
            maxScore = (from number in scorArr
                        orderby number descending
                        select number).Distinct().Skip(3).First();

            for (int i = 0; i <= scoreDice.Length; i++)
            {
                if (maxScore == scoreDice[i].score)
                {
                    rank4Index = i;

                }
            }

            if (PhotonNetwork.LocalPlayer == PhotonNetwork.PlayerList[rank4Index])
            {
                rank = winOrLossState.rankFour;
            }





            //checking if the lobby is one winner, two winner or three winner to distribute the prize accordingly
            checkWhichLobby();
        }

        private void checkWhichLobby()
        {
            if (checkIfItsOneWinnerLobby())
            {
                distributor.distributePrizeOneWinner();
            }
            else if (checkIfItsTwoWinnersLobby())
            {
                distributor.distributePrizeTwoWinners();
            }
            else
            {
                distributor.distributePrizeThreeWinners();
            }
        }


        bool checkIfItsOneWinnerLobby()
        {
            switch (PhotonNetwork.CurrentLobby.Name)
            {
                case "oneWinnerOne":
                    return true;
                case "oneWinnerFive":
                    return true;
                case "oneWinnerTen":
                    return true;
                case "oneWinnerTwentyFive":
                    return true;
                case "oneWinnerFifty":
                    return true;
                case "oneWinnerHundred":
                    return true;
                default:
                    return false;
            }
        }

        bool checkIfItsTwoWinnersLobby()
        {
            switch (PhotonNetwork.CurrentLobby.Name)
            {
                case "twoWinnersOne":
                    return true;
                case "twoWinnersFive":
                    return true;
                case "twoWinnersTen":
                    return true;
                case "twoWinnersTwentyFive":
                    return true;
                case "twoWinnersFifty":
                    return true;
                case "twoWinnersHundred":
                    return true;
                default:
                    return false;
            }
        }
    }


    public enum winOrLossState
    {
        rankOne,
        rankTwo,
        rankThree,
        rankFour
    }
}
