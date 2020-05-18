using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Umbrella : MonoBehaviour
{
    private float stamina = 50;

    private void FixedUpdate()
    {
        stamina -= 0.03f;
        Debug.Log(stamina);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player")
        {
            stamina += 1.0f;
            Debug.Log("Hit");
            Destroy(gameObject);
        }
    }
}