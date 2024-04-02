using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private int side; //1 means on the left, -1 means on the right
    private float speed,bobSpeed;
    private float originalY;
    private bool isDown, isBulletShot;
    public GameObject bulletPrefab;
    void Start()
    {
        speed = 3f;
        isBulletShot = false;
        bobSpeed = 0.1f;
        originalY = transform.position.y;
        isDown = false;
        if (transform.localScale.x > 0) {
            side = 1;
        }
        else
        {
            side = -1;
        }
        Invoke("Shoot", 1f);
        Invoke("RemoveEnemy", 2f);
    }

    void Update()
    {

        //move enemy into the screen
        if(!isBulletShot)
        {

            if(side == 1)
            {
                if(transform.position.x <-2.63f) 
                {
                    transform.Translate(new Vector3(side * speed * Time.deltaTime, 0, 0));
                }
                else
                {
                    transform.position = new Vector3(-2.62f, transform.position.y, -2);
                }
            }
            else
            {
                if (transform.position.x > 2.63f)
                {
                    transform.Translate(new Vector3(side * speed * Time.deltaTime, 0, 0));
                }
                else
                {
                    transform.position = new Vector3(2.62f, transform.position.y, -2);
                }
            }
        }
        //transform.Translate(new Vector3(side * speed * Time.deltaTime, 0, 0));

        //move enemy up and down
        if (isDown) //if enemy is moving down
        {
            if(transform.position.y> originalY - 0.2f)
            {
                transform.Translate(0, -bobSpeed*Time.deltaTime, 0);
            }
            else
            {
                isDown = false;
            }
        }
        else // if enemy is moving up
        {
            if (transform.position.y < originalY + 0.2f)
            {
                transform.Translate(0, bobSpeed*Time.deltaTime, 0);
            }
            else
            {
                isDown = true;
            }
        }
        if(isBulletShot)
        {
            RemoveEnemy();
        }

    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bullet.transform.localScale = new Vector2(side * bullet.transform.localScale.x, bullet.transform.localScale.y);
        isBulletShot = true;
    }

    private void RemoveEnemy()
    {
        if (side == 1)
        {
            if (transform.position.x > -3f)
            {
                transform.Translate(new Vector3(-side * speed * Time.deltaTime, 0, 0));
            }
            else
            {
                Destroy(gameObject);
            }
        }
        else
        {
            if (transform.position.x < 3f)
            {
                transform.Translate(new Vector3(-side * speed * Time.deltaTime, 0, 0));
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
