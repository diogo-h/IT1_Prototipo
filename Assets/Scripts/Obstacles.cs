using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            //SceneManager.LoadScene(0);
            //Destroy(other.gameObject);
            pause.DeathScreen();
            PlayerManager.stamina = 100.0f;
        }
    }
}
