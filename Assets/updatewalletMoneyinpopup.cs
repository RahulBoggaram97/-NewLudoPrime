using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


namespace com.impactionalGames.LudoPrime
{
    public class updatewalletMoneyinpopup : MonoBehaviour
    {
        public List<TextMeshProUGUI> amount = new List<TextMeshProUGUI>();

        

        public void Start()
        {
            foreach (var item in amount)
            {
                item.text = "Tottal Wallet amount : " + playerPermData.getMoney();

            }

        }

    }
}
