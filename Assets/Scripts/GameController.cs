using com.rfilkov.components;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityEditor.Animations;

public class GameController : MonoBehaviour
{
    public GameObject explanationPanel;
    public GameObject panelSuccess;
    public GameObject levelFailed;
    public GameObject levelEndedPanel;

    public int poseMatchedTimes = 0;

    public GameObject placementSpot;

    public Animator granny;

    public RuntimeAnimatorController[] controller;

    public GameObject[] AvatarPrefabs;

    public TextMeshProUGUI firstCountdown;
    public TextMeshProUGUI failureCountdown;

    public StaticPoseDetector detector;

    private GameObject spawnedObject;

    private float poseCounter = 0;

    List<int> numberSpawnedCharacter;

    private void Awake()
    {
        CharacterSelected(PlayerPrefs.GetInt("CharacterSelected")); 
    }

    private void Start()
    {
        numberSpawnedCharacter = new List<int>();
        explanationPanel.SetActive(true);
        ChangeDanceController();
        StartCoroutine(Countdown());
        StartCoroutine(CountdownTillFailure());
    }

    private void Update()
    {
         if(detector.IsPoseMatched() == true && poseCounter<3)
        {
            Debug.Log(poseCounter);
            poseCounter += Time.deltaTime;
            if (poseCounter > 3)
                StartCoroutine(SuccessPoseMatched());
        }

        if (poseMatchedTimes == 3)
        {
            levelEndedPanel.SetActive(true);
            StartCoroutine(ReturnToMainMenu());
        }
    }


    private IEnumerator Countdown()
    {
        float duration = 6f; 
        float totalTime = 0;
        while (totalTime <= duration)
        {    
            totalTime += Time.deltaTime;
            firstCountdown.text = ((int)duration-(int)totalTime).ToString();
            yield return null;
        }

        explanationPanel.SetActive(false);
    }

    private IEnumerator CountdownTillFailure()
    {
        float duration = 90f;
        float totalTime = 0;
        while (totalTime <= duration)
        {
            totalTime += Time.deltaTime;
            failureCountdown.text = ((int)duration - (int)totalTime).ToString();
            yield return null;
        }

        levelFailed.gameObject.SetActive(true);
        StartCoroutine(ReturnToMainMenu());
    }

    private IEnumerator ReturnToMainMenu()
    {
        float duration = 4f;
        float totalTime = 0;
        while (totalTime <= duration)
        {
            totalTime += Time.deltaTime;
            yield return null;
        }

        SceneManager.LoadScene("MainMenu");
    }

    private IEnumerator SuccessPoseMatched()
    {
        float duration = 2f;
        float totalTime = 0;
        while (totalTime <= duration)
        {
            totalTime += Time.deltaTime;
            panelSuccess.SetActive(true);
            yield return null;
        }

        panelSuccess.SetActive(false);
        poseMatchedTimes++;
        ChangeDanceController();
    }


    private void ChangeDanceController()
    {
        int spawnedDance = Random.Range(0,controller.Length);

        if (!(numberSpawnedCharacter.Contains(spawnedDance)))
        {
            numberSpawnedCharacter.Add(spawnedDance);
            granny.runtimeAnimatorController = controller[spawnedDance];
            //StartSuccessPoseMatch();
            poseCounter = 0;
        }
        else
        {
            ChangeDanceController();
        }

    }


    private void CharacterSelected(int characterInt)
    {
        switch (characterInt)
        {
            case 6:
                spawnedObject = Instantiate(AvatarPrefabs[5],placementSpot.gameObject.transform);
                detector.FillAvatarModel(spawnedObject.GetComponent<PoseModelHelper>());
                detector.CallAvatars();
                print("Picked TheBoss");
                break;
            case 5:
                spawnedObject = Instantiate(AvatarPrefabs[4], placementSpot.gameObject.transform);
                detector.FillAvatarModel(spawnedObject.GetComponent<PoseModelHelper>());
                detector.CallAvatars();
                print("Picked zombie");
                break;
            case 4:
                spawnedObject = Instantiate(AvatarPrefabs[3], placementSpot.gameObject.transform);
                detector.FillAvatarModel(spawnedObject.GetComponent<PoseModelHelper>());
                detector.CallAvatars();
                print("Picked Ogreish");
                break;
            case 3:
                spawnedObject = Instantiate(AvatarPrefabs[2], placementSpot.gameObject.transform);
                detector.FillAvatarModel(spawnedObject.GetComponent<PoseModelHelper>());
                detector.CallAvatars();
                print("Picked Rasta");
                break;
            case 2:
                spawnedObject = Instantiate(AvatarPrefabs[1], placementSpot.gameObject.transform);
                detector.FillAvatarModel(spawnedObject.GetComponent<PoseModelHelper>());
                detector.CallAvatars();
                print("Picked Girl");
                break;
            case 1:
                spawnedObject = Instantiate(AvatarPrefabs[0], placementSpot.gameObject.transform);
                detector.FillAvatarModel(spawnedObject.GetComponent<PoseModelHelper>());
                detector.CallAvatars();
                print("Picked Mousey");
                break;
            default:
                print("Incorrect intelligence level.");
                break;
        }
    }

}


