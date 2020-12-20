using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonNavigation : MonoBehaviour
{
    [SerializeField] private string key;
    private Button firstButton;
    private float timer;

    private void Start()
    {
        firstButton = GetComponent<Button>();
        firstButton.Select();
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if(timer <= 0)
        {
            if (Input.GetKeyDown(key))
            {
                EventSystem.current.SetSelectedGameObject(gameObject);
                timer = 0.4f;
            }
        }
    }
}
