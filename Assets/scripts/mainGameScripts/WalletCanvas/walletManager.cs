using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace com.impactionalGames.LudoPrime
{

    public class walletManager : MonoBehaviour
    {

        [Header("Panles")]
        public GameObject profilePanel;
        public GameObject walletPanel;
        public GameObject addMoneyPanel;
        public GameObject settingsPanel;
        public GameObject rulesPanel;
        public GameObject withdrawPanel;

        public GameObject popUpPanel;
        

        public GameObject debugPanel;

       

        
       


        public static walletManager instance;
        public static event Action<walletState> onWalletStateChanged;

        private void Awake()
        {
            instance = this;
            
        }

        private void Start()
        {
            updateWalletState(walletState.intial);
        }

        private void Update()
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                IntialOnClick();
            }
        }


        public walletState State;

        public void updateWalletState(walletState newstate)
        {
            this.State = newstate;

            switch (State)
            {
                case walletState.intial:
                    handleIntialState();
                    break;
                case walletState.profile:
                    handleProfileState();
                    break;
                case walletState.walletPanel:
                    handleWalletPanelState();
                    break;
                case walletState.addMoney:
                    handleAddMoneyState();
                    break;
                case walletState.withdraw:
                    handleWithdrawState();
                    break;
                case walletState.settings:
                    handleSettingsState();
                    break;
                case walletState.rules:
                    handleRulesState();
                    break;
                
            }

            onWalletStateChanged?.Invoke(State);
        }

       

        private void handleIntialState()
        {
            profilePanel.SetActive(false);
            walletPanel.SetActive(false);
            addMoneyPanel.SetActive(false);
            settingsPanel.SetActive(false);
            rulesPanel.SetActive(false);
            popUpPanel.SetActive(false);
            withdrawPanel.SetActive(false);



        }

        private void handleProfileState()
        {
            profilePanel.SetActive(true);
            walletPanel.SetActive(false);
            addMoneyPanel.SetActive(false);
            settingsPanel.SetActive(false);
            rulesPanel.SetActive(false);
            popUpPanel.SetActive(false);
            withdrawPanel.SetActive(false);
        }
        private void handleWalletPanelState()
        {
            profilePanel.SetActive(false);
            walletPanel.SetActive(true);
            addMoneyPanel.SetActive(false);
            settingsPanel.SetActive(false);
            rulesPanel.SetActive(false);
            popUpPanel.SetActive(false);
            withdrawPanel.SetActive(false);

        }
        private void handleAddMoneyState()
        {
            profilePanel.SetActive(false);
            walletPanel.SetActive(false);
            addMoneyPanel.SetActive(true);
            settingsPanel.SetActive(false);
            rulesPanel.SetActive(false);
            popUpPanel.SetActive(false);
            withdrawPanel.SetActive(false);

        }

        private void handleWithdrawState()
        {
            profilePanel.SetActive(false);
            walletPanel.SetActive(false);
            addMoneyPanel.SetActive(false);
            settingsPanel.SetActive(false);
            rulesPanel.SetActive(false);
            popUpPanel.SetActive(false);
            withdrawPanel.SetActive(true);

        }
        private void handleSettingsState()
        {
            profilePanel.SetActive(false);
            walletPanel.SetActive(false);
            addMoneyPanel.SetActive(false);
            settingsPanel.SetActive(true);
            rulesPanel.SetActive(false);
            popUpPanel.SetActive(false);
            withdrawPanel.SetActive(false);

        }
        private void handleRulesState()
        {
            profilePanel.SetActive(false);
            walletPanel.SetActive(false);
            addMoneyPanel.SetActive(false);
            settingsPanel.SetActive(false);
            rulesPanel.SetActive(true);
            popUpPanel.SetActive(false);
            withdrawPanel.SetActive(false);

        }


        public void toggleDebugPanel()
        {
            if (debugPanel.activeSelf == true)
            {
                debugPanel.SetActive(false);
            }
            else
            {
                debugPanel.SetActive(true);
            }
        }
       
        public void IntialOnClick()
        {
           walletManager.instance.updateWalletState(walletState.intial);
        }

        public void ProfileOnClick()
        {
            walletManager.instance.updateWalletState(walletState.profile);
            Debug.Log("profile button called");
        }

        public void WalletPanelOnClick()
        {
            walletManager.instance.updateWalletState(walletState.walletPanel);
        }

        public void AddMoneyOnClick()
        {
            walletManager.instance.updateWalletState(walletState.addMoney);
        }

        public void WithdrawOnClick()
        {
            walletManager.instance.updateWalletState(walletState.withdraw);
        }

        public void SettingsOnClick()
        {
            walletManager.instance.updateWalletState(walletState.settings);
        }

        public void RulesOnClick()
        {
            walletManager.instance.updateWalletState(walletState.rules);
        }

    }


    public enum walletState
    {
        intial,
        profile,
        walletPanel,
        addMoney,
        withdraw,
        settings,
        rules
   
    }
}