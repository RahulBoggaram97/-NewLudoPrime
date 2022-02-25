using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{
    public void PlayWith()
    {
        SceneManager.LoadScene("PlayWithScene");
    }

    public void NoOfPlayerScene()
    {
        SceneManager.LoadScene("NoOfPlayerScene");
    }

    public void MainScene()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void PlayerMatch()
    {
        SceneManager.LoadScene("PlayersMatching");
    }

    public void PlayerNo()
    {
        SceneManager.LoadScene("PlayerNos");
    }

    public void Phone()
    {
        SceneManager.LoadScene("PhoneScene");
    }

    public void DailyBonus()
    {
        SceneManager.LoadScene("DailyBonus");
    }

    public void Settings()
    {
        SceneManager.LoadScene("Settings");
    }

    public void PrivateRoom()
    {
        SceneManager.LoadScene("PrivateRoom");
    }

    public void PlayerType()
    {
        SceneManager.LoadScene("PlayerTypes");
    }
    public void Instruction1()
    {
        SceneManager.LoadScene("InstructionScene1");
    }
    public void Instruction2()
    {
        SceneManager.LoadScene("InstructionScene2");
    }

    public void GameMenu()
    {
        SceneManager.LoadScene("GameMenu");
    }
}
