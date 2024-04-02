using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubbleScript : MonoBehaviour
{
    // Start is called before the first frame update
    private float speed;
    void Start()
    {
        speed = Random.Range(0.5f, 2.5f);

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, -speed * Time.deltaTime, 0);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "SouthBorder")
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerBullet")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
