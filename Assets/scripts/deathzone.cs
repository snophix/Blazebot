using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathzone : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "Player")
        {
            EnergyManager.instance.DeathZoneRespawn();
        }
    }
}
