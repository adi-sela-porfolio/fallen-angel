using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverInfoScript : MonoBehaviour
{
    [SerializeField] private TMP_Text timeTxt, coinsTxt;
    public SceneInfo sceneInfo;
    void Start()
    {
        float timeCount = sceneInfo.overallTime;
        coinsTxt.text = sceneInfo.overallCoins.ToString();
        float minutes = Mathf.FloorToInt(timeCount / 60);
        float seconds = Mathf.FloorToInt(timeCount % 60);
        string currentTime = string.Format("{00:00}:{1:00}", minutes, seconds);
        print("time:" + currentTime);
        timeTxt.text = currentTime;
    }

    void Update()
    {
        
    }

    public void TryAgainButton()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene("OpeningScene");
    }

}
