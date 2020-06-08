using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public static float stamina;
    [SerializeField] private GameObject world;
    private Animator worldSpeed;
    [SerializeField] private Text staminaText;

    private void Start()
    {
        stamina = 100f;
        worldSpeed = world.GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        stamina -= 0.3f;

        if(stamina < 0) stamina = 0;
        if(stamina == 0)
        {
            worldSpeed.speed = 0.5f;
        }
        staminaText.text = "Stamina:" + stamina.ToString("0"); 
    }
}
