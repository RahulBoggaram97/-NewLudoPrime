using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using System.Threading.Tasks;
using System;

namespace com.impactionalGames.LudoPrime
{
    public class lobbyUITemplate : MonoBehaviourPunCallbacks
    {
        public GameObject gO;

        public float Timer = 60;

        public int entryFee;
        public float prizePool;

        public Text timerText;
        public Text prizeText;
        public Text entryFeeText;

        public onlineLobbyCreater olC;


        public static event Action<int> manageFee;

        private void Start()
        {
            olC = GameObject.Find("PlayOnlinePanel").GetComponent<onlineLobbyCreater>();
            manualSetEnteryFee(entryFee);
        }


        private void Update()
        {
            updateTimer();
        }

        void updateTimer()
        {
            Timer = Timer - Time.deltaTime;
            timerText.text = Timer.ToString();
            if (Timer < 0f)
            {
                handleTimeRunOut();
            }
        }

        void handleTimeRunOut()
        {
            //Destroy(gO);
        }

        public void setEnterFee()
        {
            int[] entryFeeArray = { 1, 5, 10, 25, 50, 100 };

            entryFee = entryFeeArray[UnityEngine.Random.Range(0, entryFeeArray.Length)];

            prizePool = (3 * entryFee) - ((3 * entryFee) * 0.2f);

            entryFeeText.text = entryFee.ToString();

            prizeText.text = prizePool.ToString();
        }

        public void manualSetEnteryFee(int enteryFee)
        {
            prizePool = (3 * entryFee) - ((3 * entryFee) * 0.2f);

            entryFeeText.text = entryFee.ToString();

            prizeText.text = prizePool.ToString();

        }

        public async Task manageTheFee()
        {
            
            

                olC.entryFee = entryFee;
                manageFee?.Invoke(entryFee);
                Debug.Log("fee managed");
                await Task.Yield();
            
        }

        public void redirectToPaymentOptions()
        {
            manageFee?.Invoke(entryFee);
        }

       
    }
}
