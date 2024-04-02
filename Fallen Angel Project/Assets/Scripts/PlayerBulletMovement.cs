using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletMovement : MonoBehaviour
{
    private float speed;

   
    // Start is called before the first frame update
    void Start()
    {

        speed = 10.0f;

    }

    // Update is called once per frame
    void Update()
    {
        //destroy bullet if out of screen
        if(transform.position.y>5.1f || transform.position.y<-3.6f || transform.position.x > 2.3f || transform.position.x < -2.3f)
        {
            Destroy(gameObject);
        }
        //move bullet
        transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
    }

 

    
}
