using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletScript : MonoBehaviour
{
    private int direction; //1 means going right, -1 means going left
    private float speed;
    void Start()
    {
        speed = 10f;
        if (transform.localScale.x > 0)
        {
            direction = 1;
        }
        else
        {
            direction = -1;
        }
    }

    void Update()
    {
        transform.Translate(speed * direction*Time.deltaTime,0,0);

        if(direction == 1 && transform.position.x>2.36f)
        {
            Destroy(gameObject);
        }
        else if(direction == -1 && transform.position.x < -2.36f)
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
