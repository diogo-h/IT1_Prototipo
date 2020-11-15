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
    [SerializeField] private GameObject world;
    [SerializeField] private Text staminaText;

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
            worldSpeed.speed = 0.2f;
            characterSpeed.speed = 0.2f;
        }
        else
        {
            worldSpeed.speed = 1.0f;
            characterSpeed.speed = 1.0f;
        }

        staminaText.text = "Stamina:" + stamina.ToString("0");
    }

    void Update()
    {
        //Debug.Log(stamina);
    }
}
