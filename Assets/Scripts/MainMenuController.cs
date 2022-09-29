using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{

    public GameObject startingPanel;
    public GameObject avatarSelection;

    public void StartExperience()
    {
        startingPanel.SetActive(false);
    }

    public void pickMousey()
    {
        PlayerPrefs.SetInt("CharacterSelected",1);
        SceneManager.LoadScene("PoseDetectionDemo1");
    }

    public void pickGirl()
    {
        PlayerPrefs.SetInt("CharacterSelected", 2);
        SceneManager.LoadScene("PoseDetectionDemo1");
    }

    public void pickRasta()
    {
        PlayerPrefs.SetInt("CharacterSelected", 3);
        SceneManager.LoadScene("PoseDetectionDemo1");
    }

    public void pickOgreish()
    {
        PlayerPrefs.SetInt("CharacterSelected", 4);
        SceneManager.LoadScene("PoseDetectionDemo1");
    }

    public void pickZombie()
    {
        PlayerPrefs.SetInt("CharacterSelected", 5);
        SceneManager.LoadScene("PoseDetectionDemo1");
    }

    public void pickTheBoss()
    {
        PlayerPrefs.SetInt("CharacterSelected", 6);
        SceneManager.LoadScene("PoseDetectionDemo1");
    }


}
