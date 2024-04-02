using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudsMOvement : MonoBehaviour
{
    // Start is called before the first frame update
    private float speed;
    [SerializeField] private GameObject clouds1, clouds2;
    void Start()
    {
        clouds1.transform.position = new Vector3(0, 5, 9);
        clouds2.transform.position = new Vector3(0, -15, 9);
        speed = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        clouds1.transform.Translate(new Vector2(0, speed * Time.deltaTime));
        clouds2.transform.Translate(new Vector2(0, speed * Time.deltaTime));
        if(clouds1.transform.position.y > 25) {
            clouds1.transform.position = new Vector3(0, -15, 9);
        }
        else if (clouds2.transform.position.y > 25)
        {
            clouds2.transform.position = new Vector3(0, -15, 9);
        }
    }
}
