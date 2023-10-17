using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableOrEnableObject : MonoBehaviour
{
    public GameObject button2;

    void Start()
    {

    }

    void Update()
    {

    }

    public void whenButtonClicked()
    {
        if (button2.activeInHierarchy == true)
        {
            button2.SetActive(false);
        }
        else
        {
            button2.SetActive(true);
        }
    }
}
