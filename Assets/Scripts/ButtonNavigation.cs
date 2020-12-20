using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonNavigation : MonoBehaviour
{
    [SerializeField] private string key;

    private void Update()
    {
        if(Input.GetKeyDown(key))
        {
            EventSystem.current.SetSelectedGameObject(gameObject);
        }
    }
}
