using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
    //[SerializeField] public static InputActionReference moveAction;
    [SerializeField] private InputActionReference moveAction;
    [SerializeField] private float speed;
    public GameObject enemyGroup, bulletPrefab;
    public static bool isLastChance,isBonus;
    public static int coins;
    private int allCoins;
    //[SerializeField] private int Coins;
    private float bonusStartTime;
    public SceneInfo sceneInfo;
    [SerializeField] Light2D playerLight, GlobalLight;
    public AudioSource playerAudioSource;
    public AudioClip rubbleAudio, coinAudio, gameOverAudio;
    void Start()
    {
        speed = 5;
        isLastChance = false;
        isBonus = false;
        allCoins = 0;
        coins = 0;
        playerLight.enabled = false;
    }

    void Update()
    {
        Vector2 movementDirection = moveAction.action.ReadValue<Vector2>();
        transform.Translate(movementDirection*speed*Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Rubble")
        {
            if (!isBonus)
            {
                ColorRed();
                Invoke("ColorBack", 0.2f);

            }
            if(coins > 0 && !isBonus)
            {
                coins--;
            }
            Destroy(collision.gameObject);
            playerAudioSource.PlayOneShot(rubbleAudio,0.5f);
            if (!isLastChance) {
            
                isLastChance =true;

                Invoke("CancelLastChance", 10f);
            }
            else
            {

                GameOver();
            }
        }
    }

    private void CancelLastChance() 
    { 
        isLastChance =false;
        print("cancel last chance");

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Coin")
        {

            playerAudioSource.PlayOneShot(coinAudio, 0.5f);
            Destroy(collision.gameObject);
            coins++;
            allCoins++;
            CoinController.isCoinOnScreen = false;
            print("coins: "+ coins);
            if(coins == 7)
            {
                CoinBonusActivate();

            }
        }
        else if (collision.gameObject.tag == "EnemyBullet")
        {
            GameOver();
        }
    }
    private void CoinBonusActivate()
    {
        isBonus=true;
        bonusStartTime = TimerControl.timeCount;
        InvokeRepeating("ShotCheck",0f,0.2f);
        playerLight.enabled = true;
    }

    private void PlayerShoot()
    {

        Vector2 movementDirection = moveAction.action.ReadValue<Vector2>();

        float angle = Mathf.Atan2(movementDirection.y, movementDirection.x) * Mathf.Rad2Deg;
        GameObject bullet = Instantiate(bulletPrefab,transform.position, Quaternion.identity);
        //if the player isn't moving, shoot up
        if (Mathf.Approximately(movementDirection.x, 0f) && Mathf.Approximately(movementDirection.y, 0f))
        {
           bullet.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90));
        }
        else //if the player is moving shooting in the direction of the player's movement
        {
            print(angle);
            bullet.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }
    }

    //shoot bonus but if 20 seconds have passed cancel the bonus.
    private void ShotCheck()
    {
            if (bonusStartTime+8 <= TimerControl.timeCount)//10 // the +number is how long the bonus lasts
            {
                //once 8 seconds since the bonus start have passed, end the player shots and start flickering the light for 2 seconds and then end the bonus

                Invoke("EndBonus", 2f);
                CancelInvoke("ShotCheck");

                InvokeRepeating("FlickerPlayerLight", 0f, 0.05f);
            }
            else
            {
                PlayerShoot();
            }
    }

    private void GameOver() 
    {
        if (!isBonus)
        {
            playerAudioSource.PlayOneShot(gameOverAudio);
            Time.timeScale = 0f;
            sceneInfo.overallTime = TimerControl.timeCount;
            sceneInfo.overallCoins = allCoins;
            playerLight.enabled = true;
            playerLight.intensity = 2f;
            playerLight.color = Color.red;
            print("gameOver");

            StartCoroutine(LightFadeCoroutine());

        }
    }
    private void LoadGameOverScreen()
    {
        SceneManager.LoadScene("GameOverScene");
    }

    private void EndBonus()
    {
        isBonus = false;
        coins = 0;
        playerLight.intensity = 1.2f;
        playerLight.enabled = false;
        CancelInvoke("FlickerPlayerLight");

    }

    private void FlickerPlayerLight()
    {
            float intense = Random.Range(0.5f, 1.21f);
            playerLight.intensity = intense;

    }

    private IEnumerator LightFadeCoroutine()
    {
        float i = 0.8f;
        while (i > 0)
        {
            print("lightFade");
            i-=0.002f;
            GlobalLight.intensity = i;
            yield return null;
        }
        LoadGameOverScreen();
        Time.timeScale = 1;
    }

    private void ColorBack()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }
    private void ColorRed()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.red;
    }
}
