using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBarManager : MonoBehaviour
{
    public Image energyBar;
    public Text energyCount;

    public static EnergyBarManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("there is more than one instance of EnergyBarManager");
            return;
        }

        instance = this;
    }

    public void SetEnergy(float energy, float maxEnergy)
    {
        energyBar.fillAmount = energy / maxEnergy;
    }
    
}