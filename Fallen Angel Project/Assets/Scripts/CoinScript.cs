using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    private float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(0.5f, 2.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < 5)
        {

            transform.Translate(0, speed * Time.deltaTime, 0);
        }
        else
        {
            Destroy(gameObject);
            CoinController.isCoinOnScreen = false;
        }
    }
}
