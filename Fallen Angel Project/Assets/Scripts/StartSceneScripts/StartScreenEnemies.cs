using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreenEnemies : MonoBehaviour
{
    private float speed;
    public static bool isAnimStart;
    //public static bool isAnimDonet;
    // Start is called before the first frame update
    void Start()
    {
        speed = 10f;
        Time.timeScale = 1;
        //isAnimDone = false;
        isAnimStart = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isAnimStart)
        {

            if (transform.position.y > -4.6f)
            {
                transform.Translate(0, -speed * Time.deltaTime, 0);
            }
            else
            {
                //isAnimDone = true;
                SceneManager.LoadScene("SampleScene");
            }
        }
    }
}
