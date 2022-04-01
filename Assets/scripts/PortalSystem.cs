using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalSystem : MonoBehaviour
{
    public string LevelName;

    private void OnTriggerEnter(Collider collider)
    {
        Debug.Log("Trigger");
        if(collider.tag == "Player")
        {
            Debug.Log("Player");
            LoadSpecificLevel.instance.LoadLevel(LevelName);
        }
    }
}
