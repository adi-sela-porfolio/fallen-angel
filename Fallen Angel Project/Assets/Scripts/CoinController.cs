using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    public static bool isCoinOnScreen;
    public GameObject coinPrefab;

    void Start()
    {
        isCoinOnScreen = false;   
    }


    void Update()
    {
        if (!isCoinOnScreen && !PlayerControl.isBonus)
        {
            Instantiate(coinPrefab, new Vector3(Random.Range(-2.1f, 2.1f),-4f,0),transform.rotation);
            isCoinOnScreen = true;
        }
    }

}
