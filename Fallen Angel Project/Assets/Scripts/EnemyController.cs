using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject enemyBulletPrefab;
    //private float enemyExtraSpawnIncrement; //the amount of time between adding an extra enemy to each spawn
    private int currentMaxEnemies; //the current amount of enemies allowed at once
    void Start()
    {
        //enemyExtraSpawnIncrement = 30; //30 seconds until another enemy is added. then 30 seconds and another enemy is added
        currentMaxEnemies = 1;
        InvokeRepeating("CreateEnemy", 0f, 1f); //[maybe add an invoke of the function for each additional enemy, that way they also won't all be appearing on the same second]
    }

    void Update()
    {
       TimeCheck();
        //CreateEnemy();
    }

    private void CreateEnemy()
    {
        float enemySide;
        int leftOrRight = Random.Range(0, 2);//if on the left side or right side of the screen
        if (leftOrRight == 0)//if left
        {
            enemySide = 1;
        }
        else //if right
        {
            enemySide= -1;
        }
        for(int i = 0; i < 3; i++) { //make sure enemies don't overlap and try another location again twice if they overlap
            float height = Random.Range(-3.3f,4.7f);
            Collider2D overlapPotential = Physics2D.OverlapCircle(new Vector3(-3 * enemySide, height, 0), 0.5f);
            //Collider2D overlapPotential = Physics2D.OverlapCircle(new Vector3(-3 * enemySide, height, 0), 1f, 0, 2, 2);
            if(overlapPotential == null) {
                GameObject enemy =Instantiate(enemyPrefab, new Vector3(-3 * enemySide, height, -2), transform.rotation);
                enemy.transform.localScale = new Vector2(enemySide*enemy.transform.localScale.x, enemy.transform.localScale.y);//make the enemy face the other side from them
                print("enemy placed");

                //give the enemy the bullet prefab
                enemy.GetComponent<EnemyScript>().bulletPrefab = enemyBulletPrefab;

                break;
            }
            print("enemy overlapped: "+ height + " + "+ overlapPotential.transform.position.x+", "+ overlapPotential.transform.position.y);
        }
    }


    private void TimeCheck()
    {
        //after half a minute add a second enemy to each spawn
        if (TimerControl.timeCount >= 30 && currentMaxEnemies == 1)
        {
            currentMaxEnemies = 2;
            InvokeRepeating("CreateEnemy", 0f, 1f);
        }
        //after a minute add a third enemy to each spawn.
        else if (TimerControl.timeCount >= 60 &&currentMaxEnemies == 2)
        {
            currentMaxEnemies = 3;
            InvokeRepeating("CreateEnemy", 0f, 1f);
            //InvokeRepeating("CreateEnemy", 0f, 1f);
        }
    }
}
