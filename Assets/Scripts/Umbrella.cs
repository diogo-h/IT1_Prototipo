using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Umbrella : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player")
        {
            PlayerManager.stamina += 10.0f;
            Debug.Log("Hit");
            Destroy(gameObject);
        }
    }
}