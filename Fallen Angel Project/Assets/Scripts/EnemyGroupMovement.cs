using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGroupMovement : MonoBehaviour
{
    private float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        //if player is in last chance then lower the group to show them
        if (PlayerControl.isLastChance)
        {
            if(transform.position.y > 4.5f)
            {
                transform.Translate(new Vector3(0, -speed*Time.deltaTime, 0));
            }
        }
        //if player is out of last chance raise the group to hide it
        else
        {
            if (transform.position.y < 5.5f)
            {
                transform.Translate(new Vector3(0, speed * Time.deltaTime, 0));
            }
        }
    }
}
