using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace com.impactionalGames.LudoPrime
{
    public class prizeDistibutor : MonoBehaviour
    {
        public WinnerDecider winDec;

        public tansactApiCaller transact;

        public UIHandlerEndGame uiHandler;

        public sendMatchDetails sendMatchdet;

        public void distributePrizeOneVOne()
        {
            switch (PhotonNetwork.CurrentLobby.Name)
            {
                case "oneVoneOne":

                   if(winDec.rank == winOrLossState.rankOne)
                    {
                        transact.transferMoney("2.4");
                        sendMatchdet.sendMatchDet("true");
                    }
                    else
                    {
                        transact.transferMoney("-2.4");
                        sendMatchdet.sendMatchDet("false");
                    }
                    break;


                case "oneVoneFive":

                    if (winDec.rank == winOrLossState.rankOne)
                    {
                        transact.transferMoney("12");
                        sendMatchdet.sendMatchDet("true");
                    }
                    else
                    {
                        transact.transferMoney("-12");
                        sendMatchdet.sendMatchDet("false");
                    }
                    break;


                case "oneVoneTen":

                    if (winDec.rank == winOrLossState.rankOne)
                    {
                        transact.transferMoney("24");
                        sendMatchdet.sendMatchDet("true");
                    }
                    else
                    {
                        transact.transferMoney("-24");
                        sendMatchdet.sendMatchDet("false");
                    }
                    break;

                case "oneVoneTwentyFive":

                    if (winDec.rank == winOrLossState.rankOne)
                    {
                        transact.transferMoney("60");
                        sendMatchdet.sendMatchDet("true");

                    }
                    else
                    {
                        transact.transferMoney("-60");
                        sendMatchdet.sendMatchDet("false");
                    }
                    break;

                case "oneVoneFifty":


                    if (winDec.rank == winOrLossState.rankOne)
                    {
                        transact.transferMoney("120");
                        sendMatchdet.sendMatchDet("true");
                    }
                    else
                    {
                        transact.transferMoney("-120");
                        sendMatchdet.sendMatchDet("false");
                    }
                    break;

                case "oneVoneHundred":


                    if (winDec.rank == winOrLossState.rankOne)
                    {
                        transact.transferMoney("240");
                        sendMatchdet.sendMatchDet("true");
                    }
                    else
                    {
                        transact.transferMoney("-240");
                        sendMatchdet.sendMatchDet("false");
                    }
                    break;

                default:
                    break;
            }

            uiHandler.UpdateLeaderBoard();
        }


        public void distributePrizeOneWinner()
        {
            switch (PhotonNetwork.CurrentLobby.Name)
            {
                case "oneWinnerOne":
                    OneWinnerPrizeDistAccordingToRank(1);
                    break;

                case "oneWinnerFive":
                    OneWinnerPrizeDistAccordingToRank(5);
                    break;

                case "oneWinnerTen":
                    OneWinnerPrizeDistAccordingToRank(10);
                    break;

                case "oneWinnerTwentyFive":
                    OneWinnerPrizeDistAccordingToRank(25);
                    break;

                case "oneWinnerFifty":
                    OneWinnerPrizeDistAccordingToRank(50);
                    break;

                case "oneWinnerHundred":
                    OneWinnerPrizeDistAccordingToRank(100);
                    break;

                    
            }
            uiHandler.UpdateLeaderBoard();
        }

        public void distributePrizeTwoWinners()
        {
            switch (PhotonNetwork.CurrentLobby.Name)
            {
                case "twoWinnersOne":
                    TwoWinnerPrizeDistAccordingToRank(1);
                    break;
                case "twoWinnersFive":
                    TwoWinnerPrizeDistAccordingToRank(5);
                    break;
                case "twoWinnersTen":
                    TwoWinnerPrizeDistAccordingToRank(10);
                    break;
                case "twoWinnersTwentyFive":
                    TwoWinnerPrizeDistAccordingToRank(25);
                    break;
                case "twoWinnersFifty":
                    TwoWinnerPrizeDistAccordingToRank(50);
                    break;
                case "twoWinnersHundred":
                    TwoWinnerPrizeDistAccordingToRank(100);
                    break;
               
            }
            uiHandler.UpdateLeaderBoard();
        }


        public void distributePrizeThreeWinners()
        {
            switch (PhotonNetwork.CurrentLobby.Name)
            {
                case "threeWinnersOne":
                    ThreeWinnerPrizeDistAccordingToRank(1);
                    break;
                case "threeWinnersFive":
                    ThreeWinnerPrizeDistAccordingToRank(5);
                    break;
                case "threeWinnersTen":
                    ThreeWinnerPrizeDistAccordingToRank(10);
                    break;
                case "threeWinnersTwentyFive":
                    ThreeWinnerPrizeDistAccordingToRank(25);
                    break;
                case "threeWinnersFifty":
                    ThreeWinnerPrizeDistAccordingToRank(50);
                    break;
                case "threeWinnersHundred":
                    ThreeWinnerPrizeDistAccordingToRank(100);
                    break;

            }
            uiHandler.UpdateLeaderBoard();
        }



        






        //HANDY FUNTION TO DISTRIBUTE PRIZE ACCORDING TO THE ENTRY FEE 
        // AND NUMBER OF WINNERS IN A FOUR PLAYER GAME
        void OneWinnerPrizeDistAccordingToRank(int entryFee)
        {
            float prizePool = (3 * entryFee) - ((3 * entryFee) * 0.2f);


            switch (winDec.rank)
            {
                case winOrLossState.rankOne:
                    transact.transferMoney(prizePool.ToString());
                    sendMatchdet.sendMatchDet("true");
                    break;

                case winOrLossState.rankTwo:
                    transact.transferMoney("-" + entryFee.ToString());
                    sendMatchdet.sendMatchDet("false");
                    break;

                case winOrLossState.rankThree:
                    transact.transferMoney("-" + entryFee.ToString());
                    sendMatchdet.sendMatchDet("false");
                    break;

                case winOrLossState.rankFour:
                    transact.transferMoney("-" + entryFee.ToString());
                    sendMatchdet.sendMatchDet("false");
                    break;

            }
  
        }

        void TwoWinnerPrizeDistAccordingToRank(int entryFee)
        {
            float prizePool = (3 * entryFee) - ((3 * entryFee) * 0.2f);

            float sixtyPerCentOfPrizePool = (60 * prizePool) / 100;
            float fortyPerCentOfPrizePool = (40 * prizePool) / 100;

            switch (winDec.rank)
            {
                case winOrLossState.rankOne:
                    transact.transferMoney(sixtyPerCentOfPrizePool.ToString());
                    sendMatchdet.sendMatchDet("true");
                    break;

                case winOrLossState.rankTwo:
                    transact.transferMoney(fortyPerCentOfPrizePool.ToString());
                    sendMatchdet.sendMatchDet("true");
                    break;

                case winOrLossState.rankThree:
                    transact.transferMoney("-" + entryFee.ToString());
                    sendMatchdet.sendMatchDet("false");
                    break;

                case winOrLossState.rankFour:
                    transact.transferMoney("-" + entryFee.ToString());
                    sendMatchdet.sendMatchDet("false");
                    break;

            }

        }

        void ThreeWinnerPrizeDistAccordingToRank(int entryFee)
        {
            float prizePool = (3 * entryFee) - ((3 * entryFee) * 0.2f);

            float fiftyPerCentOfPrizePool = (50 * prizePool) / 100;
            float thirtyPerCentOfPrizePool = (30 * prizePool) / 100;
            float twentyPerCentOfPrizePool = (20 * prizePool) / 100;


            switch (winDec.rank)
            {
                case winOrLossState.rankOne:
                    transact.transferMoney(fiftyPerCentOfPrizePool.ToString());
                    sendMatchdet.sendMatchDet("true");
                    break;

                case winOrLossState.rankTwo:
                    transact.transferMoney(thirtyPerCentOfPrizePool.ToString());
                    sendMatchdet.sendMatchDet("true");
                    break;

                case winOrLossState.rankThree:
                    transact.transferMoney(twentyPerCentOfPrizePool.ToString());
                    sendMatchdet.sendMatchDet("true");
                    break;

                case winOrLossState.rankFour:
                    transact.transferMoney("-" + entryFee.ToString());
                    sendMatchdet.sendMatchDet("false");
                    break;

            }

        }



    }
}
