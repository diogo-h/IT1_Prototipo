using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public static float stamina;
    private Animator worldSpeed;
    private Animator characterSpeed;
    public Slider staminaBar;
    [SerializeField] private GameObject world;
    [SerializeField] private Text staminaText;
    [SerializeField] private SpeedPreference speedChoice;
    public static float speedPicked;

    private void Start()
    {
        stamina = 100f;
    }

    private void FixedUpdate()
    {
        worldSpeed = GameObject.Find("World").GetComponent<Animator>();
        characterSpeed = GetComponentInParent<Animator>();
        
        stamina -= 0.1f;
        
        if(stamina < 0) stamina = 0;
        if(stamina > 100) stamina = 100;
        if(stamina == 0)
        {
            worldSpeed.speed = 0.4f;
            characterSpeed.speed = 0.4f;
        }
        else
        {
            worldSpeed.speed = speedPicked;
            characterSpeed.speed = speedPicked;
        }

        staminaText.text = "Stamina:" + stamina.ToString("0");
    }

    private void IncrementStaminaBar()
    {
        staminaBar.value = stamina / 100;
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name != "MainMenu")
        {
            staminaBar.gameObject.SetActive(true);
            IncrementStaminaBar();
        }
        else
            staminaBar.gameObject.SetActive(false);

        //Debug.Log(stamina);
    }
}
