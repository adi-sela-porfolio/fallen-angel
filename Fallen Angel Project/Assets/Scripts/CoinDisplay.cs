using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinDisplay : MonoBehaviour
{
    public Sprite[] sprites;
    private Image imageComponent;
    void Start()
    {
       // sprites = new Sprite[8];
       imageComponent = GetComponent<Image>();
        imageComponent.sprite = sprites[0];
    }

    void Update()
    {
        imageComponent.sprite = sprites[PlayerControl.coins];
    }
}
