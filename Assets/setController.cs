using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class setController : MonoBehaviour
{
    public Slider slider;
    private float value;
    PlayerController player;
    GameManager gameManager;

    private void OnEnable()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        value = gameManager.rotValue;

        //value = player.rotValue;
        slider.value = value;
    }

    public void SetLevel(float sliderValue)
    {
        player.rotSpeed = 60f * slider.value;
       // player.rotValue = slider.value;
        value = slider.value;
        gameManager.rotValue = value;

    }

}
