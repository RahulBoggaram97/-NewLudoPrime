
using UnityEngine;

public static class vibrationTest 
{
#if UNITY_ANDROID && !UNITY_EDITOR
    public static AndroidJavaClass unityplayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
    public static AndroidJavaObject currentActivity = unityplayer.GetStatic<AndroidJavaObject>("currentActivity");
    public static AndroidJavaObject vibrator = currentActivity.Call<AndroidJavaObject>("getSystemService", "vibrator");
#else
    public static AndroidJavaClass unityplayer;
    public static AndroidJavaObject currentActivity;
    public static AndroidJavaObject vibrator;
#endif

    public static void vibrate(long milliseconds = 250)
    {
        if (IsAndroid())
        {
            vibrator.Call("vibrate", milliseconds);

        }
        else
        {
            Handheld.Vibrate();
        }
    }

    public static  void cancel()
    {
        if (IsAndroid())
        {
            vibrator.Call("cancel");
        }
    }



    public static bool IsAndroid()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        return true;
#else
        return false;
#endif
    }

}
