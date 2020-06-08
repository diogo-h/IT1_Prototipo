using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    public bool isAlive {get; private set;}
    private void OnTriggerEnter(Collider other)
    {
        UIManager pause = new UIManager();

        if(other.gameObject.name == "Player")
        {
            isAlive = false;
            Debug.Log("Omaewa mo shindeiru");
            Destroy(other.gameObject);
            pause.DeathScreen();
        }
    }
}
