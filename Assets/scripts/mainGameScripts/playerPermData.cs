using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.impactionalGames.LudoPrime
{
    public static class playerPermData 
    {
        //id made by firebase during registration
        public const string LOCAL_ID_PREF_KEY = "firebaseAuthenticatedLocalID";
        public const string EMAIL_ID_PREF_KEY = "firebaseGoolgeAuthenticatedID";
        public const string USERNAME_PREF_KEY = "userName";
        public static string MONEY_PREF_KEY = "money";
        public static string PHONE_NO_PREF_KEY = "phoneNumber";

        public const string WON_MATCHES_PREF_KEY = "won";
        public const string LOSE_MATCHES_PREF_KEY = "lose";
        public const string DRAWN_MATCHES_PREF_KEY = "drawn";
        public const string TOTAL_MATCHES_PREF_KEY = "total";

        public const string REFER_CODE_PREF_KEY = "referCode";
        public const string REFERED_BY_CODE_PREF_KEY = "referedBy";


        //setting prefkeys
        public const string LANGUAGE_PREF_KEY = "language";
        public const string ENGLISH_KEY = "english";
        public const string HINDI_KEY = "hindi";



        public const string SOUNDS_PREF_KEY = "sounds";
        public const string MUSIC_PREF_KEY = "music";
        public const string VIBRATION_PREF_KEY = "vibration";



        //EMAIL
        public static void setEmail(string value)
        {
            PlayerPrefs.SetString(EMAIL_ID_PREF_KEY, value);
        }

        public static string getEmail()
        {
            return PlayerPrefs.GetString(EMAIL_ID_PREF_KEY);
        }

        //LOCAL ID
        public static void setLocalId(string value)
        {
            PlayerPrefs.SetString(LOCAL_ID_PREF_KEY, value);
        }

        public static string getLocalId()
        {
            return PlayerPrefs.GetString(LOCAL_ID_PREF_KEY);
        }

        //USER NAME
        public static void setUserName(string value)
        {
            PlayerPrefs.SetString(USERNAME_PREF_KEY, value);
        }

        public static string getUserName()
        {
            return PlayerPrefs.GetString(USERNAME_PREF_KEY);
        }

        //MONEY
        public static void setMoney(int value)
        {
            PlayerPrefs.SetInt(MONEY_PREF_KEY, value);
        }

        public static int getMoney()
        {
            return PlayerPrefs.GetInt(MONEY_PREF_KEY);  
        }

        //PHONE NUM
        public static void setPhoneNumber(string value)
        {
            PlayerPrefs.SetString(PHONE_NO_PREF_KEY , value);
        }

        public static string getPhoneNumber()
        {
            return PlayerPrefs.GetString(PHONE_NO_PREF_KEY);
        }


        //WON MATCHES
        public static void setWonMatches(string value)
        {
            PlayerPrefs.SetString(WON_MATCHES_PREF_KEY, value);
        }

        public static string getWonMatches()
        {
            return PlayerPrefs.GetString(WON_MATCHES_PREF_KEY);
        }

        //LOSE MATCHES
        public static void setLoseMatches(string value)
        {
            PlayerPrefs.SetString(LOSE_MATCHES_PREF_KEY, value);
        }

        public static string getLoseMatches()
        {
            return PlayerPrefs.GetString(LOSE_MATCHES_PREF_KEY);
        }

        //DRAWN MATCHES
        public static void setDrawnMatches(string value)
        {
            PlayerPrefs.SetString(DRAWN_MATCHES_PREF_KEY, value);
        }

        public static string getDrawnMatches()
        {
            return PlayerPrefs.GetString(DRAWN_MATCHES_PREF_KEY);
        }

        //TOTAL MATCHES
        public static void setTotalMatches(string value)
        {
            PlayerPrefs.SetString(TOTAL_MATCHES_PREF_KEY, value);
        }

        public static string getTotalMatches()
        {
            return PlayerPrefs.GetString(TOTAL_MATCHES_PREF_KEY);
        }









        //LANGUAGE
        public static void setLanguage(string value)
        {
            PlayerPrefs.SetString(LANGUAGE_PREF_KEY, value);
        }

        public static string getLanguage()
        {
            return PlayerPrefs.GetString(LANGUAGE_PREF_KEY);
        }

        //SOUNDS
        public static void setSoundsOnOrOff(bool value)
        {
            PlayerPrefs.SetString(SOUNDS_PREF_KEY, value.ToString());
        }

        public static bool getSoundsOnOrOff()
        {
            return System.Convert.ToBoolean(PlayerPrefs.GetString(SOUNDS_PREF_KEY));
        }

        //MUSIC
        public static void setMusicOnOrOff(bool value)
        {
            PlayerPrefs.SetString(MUSIC_PREF_KEY, value.ToString());
        }

        public static bool getMusicOnOrOff()
        {
            return System.Convert.ToBoolean(PlayerPrefs.GetString(MUSIC_PREF_KEY));
        }

        //SOUNDS
        public static void setVibrationOnOrOff(bool value)
        {
            PlayerPrefs.SetString(VIBRATION_PREF_KEY, value.ToString());
        }

        public static bool getVibrationOnOrOff()
        {
            return System.Convert.ToBoolean(PlayerPrefs.GetString(VIBRATION_PREF_KEY));
        }

        //REFER CODE
        public static void setReferCode(string value)
        {
            PlayerPrefs.SetString(REFER_CODE_PREF_KEY, value);
        }

        public static string getReferCode()
        {
            return PlayerPrefs.GetString(REFER_CODE_PREF_KEY);
        }

        //REFERED BY
        public static void setReferdBy(string value)
        {
            PlayerPrefs.SetString(REFERED_BY_CODE_PREF_KEY, value);
        }

        public static string getReferedBy()
        {
            return PlayerPrefs.GetString(REFERED_BY_CODE_PREF_KEY);
        }

    }
}
