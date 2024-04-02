using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubbleController : MonoBehaviour
{
    public GameObject rubblePrefab;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CreateRubble", 1f, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CreateRubble()
    {
        Instantiate(rubblePrefab, new Vector3(Random.Range(-2.1f, 2.1f), 5.5f, 0), transform.rotation);
    }
}
