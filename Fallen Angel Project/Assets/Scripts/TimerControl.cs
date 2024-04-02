using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerControl : MonoBehaviour
{
    // Start is called before the first frame update
    public static float timeCount;
    [SerializeField] private TMP_Text minuteText1;
    [SerializeField] private TMP_Text minuteText2;
    //[SerializeField] private TMP_Text separetorText;
    [SerializeField] private TMP_Text SecondText1;
    [SerializeField] private TMP_Text SecondText2;
    void Start()
    {
        ResetTimer();
    }

    // Update is called once per frame
    void Update()
    {
        timeCount += Time.deltaTime;
        DisplayTimer();
    }

    public static void ResetTimer()
    {
        timeCount = 0;
    }

    private void DisplayTimer()
    {
        float minutes = Mathf.FloorToInt( timeCount / 60);
        float seconds = Mathf.FloorToInt(timeCount % 60);
        string currentTime = string.Format("{00:00}{1:00}",minutes,seconds);
        minuteText1.text = currentTime[0].ToString();
        minuteText2.text = currentTime[1].ToString();
        SecondText1.text = currentTime[2].ToString();
        SecondText2.text = currentTime[3].ToString();
        //print(currentTime);
    }

}
