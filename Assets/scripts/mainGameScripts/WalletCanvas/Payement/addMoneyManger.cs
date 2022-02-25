using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace com.impactionalGames.LudoPrime
{
    public class addMoneyManger : MonoBehaviour
    {
        public InputField amountField;

        public webVeiwManager webViewMan;

        public void AddMoney()
        {
            webViewMan.Url = "https://ludogame-backend.herokuapp.com/paynow/" + playerPermData.getPhoneNumber() + "/" + amountField.text;

            webViewMan.openPayTmGateway();
        }
    }
}
