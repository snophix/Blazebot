using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health_manager : MonoBehaviour
{
    public float max_health = 100.0f;
    public float health;
    public bool lose;

    public Animator FadeInAnimation;
    public Animator Health;

    public static health_manager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("there is more than one instance of health_manager");
            return;
        }

        instance = this;
    }

    void Start()
    {
        health = max_health;
    }
    public void Damage(float amount)
    {
        if(health > 0f)
        {
            health -= amount;
        }
        if(health <= 0f)
        {
            health = max_health;
        }
    }
    public void Cure(float amount)
    {
        if((health + amount) < max_health)
        {
            health += amount;
        }
    }
    public void Respawn()
    {
        StartCoroutine(ReplacePlayer());       
    }

    private IEnumerator ReplacePlayer()
    {
        // FadeInAnimation.SetTrigger("FadeIn");
        Damage(12f);
        lose = true;
        yield return new WaitForSeconds(1f);
        transform.position = Player_spawn.instance.transform.position;
        lose = false;
    }
}
