using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using TMPro;

namespace com.impactionalGames.LudoPrime
{
    public class MoneyManager : MonoBehaviour
    {
        public Text moneyText;

        public GameObject popUpPanel;

        [Header("My wallet screen")]
        public TextMeshProUGUI totalBalanceText;

        private void Awake()
        {
            lobbyUITemplate.manageFee += HandleFeeManagement;
        }

        private void OnDestroy()
        {
            lobbyUITemplate.manageFee -= HandleFeeManagement;
        }

        private void Start()
        {
            
            moneyText.text = playerPermData.getMoney().ToString();
            totalBalanceText.text = playerPermData.getMoney().ToString();
        }

        public void HandleFeeManagement(int enteryFee)
        {

            if (playerPermData.getMoney() > enteryFee)
            {

                int currentMoney = playerPermData.getMoney();

                currentMoney = currentMoney - enteryFee;

                playerPermData.setMoney(currentMoney);

                moneyText.text = playerPermData.getMoney().ToString();

            }

            else
            {
                popUpPanel.SetActive(true);
            }

        }


        public void recharge()
        {
            walletManager.instance.updateWalletState(walletState.addMoney);
        }

       
    }
}
