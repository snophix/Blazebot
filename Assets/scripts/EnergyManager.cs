using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyManager : MonoBehaviour
{
    public float maxEnergy = 100f;
    public float energy;

    public Animator fadeSystem;

    public static EnergyManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("there is more than one instance of EnergyManager");
            return;
        }

        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        energy = maxEnergy;
    }

    public void UseEnergy(float amount)
    {
        if((energy - amount) > 0f)
        {
            energy -= amount;
            UpdateEnergyBar();
        }else if((energy - amount) <= 0f)
        {
            energy = 0f;
            UpdateEnergyBar();
            StartCoroutine(DeathRespawn());
        }
    }


    public void AddEnergy(float amount)
    {
        if((energy += amount) <= maxEnergy)
        {
            energy += amount;
            UpdateEnergyBar();
        }else if((energy + amount) > maxEnergy)
        {
            energy = maxEnergy;
            UpdateEnergyBar();
        }
    }

    private IEnumerator DeathRespawn()
    {
        fadeSystem.SetTrigger("FadeIn");
        yield return new WaitForSeconds(1f);
        energy = maxEnergy;
        transform.position = GameObject.FindGameObjectWithTag("Respawn").transform.position;
        UpdateEnergyBar();
    }

    private IEnumerator DeathZoneRespawnCo()
    {
        fadeSystem.SetTrigger("FadeIn");
        yield return new WaitForSeconds(1f);
        transform.position = GameObject.FindGameObjectWithTag("Respawn").transform.position;
    }

    public void UpdateEnergyBar()
    {
        EnergyBarManager.instance.SetEnergy(energy, maxEnergy);
        EnergyBarManager.instance.energyCount.text = energy.ToString() + "%";
    }

    public void DeathZoneRespawn()
    {
        StartCoroutine(DeathZoneRespawnCo());
    }
}
