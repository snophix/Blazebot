using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    public GameObject[] MainMenuObjects;

    public static CanvasManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("there is more than one instance of CanvasManager");
            return;
        }

        instance = this;
    }

    public void DisableMainMenu()
    {
        foreach(var element in MainMenuObjects)
        {
            element.SetActive(false);
        }
    }
}
