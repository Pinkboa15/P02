using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health = 100;
    PlayerController playerController;
    [SerializeField] AudioClip _hurtSound;
    private void Awake()
    {
        playerController = FindObjectOfType<PlayerController>();
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            DamagePlayer(5);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            HealPlayer(10);
        }
    }
    public void DamagePlayer(int _damageAmount)
    {
        health -= _damageAmount;
        if (health <= 0)
        {
            health = 0;
        }
        else
        {
            AudioHelper.PlayClip2D(_hurtSound, 1);
        }
        Debug.Log("Health is now " + health);
        playerController.UpdateHealthSlider();
    }
    public void HealPlayer(int _healAmount)
    {
        health += _healAmount;
        if (health >= 100)
        {
            health = 100;
        }
        Debug.Log("Health is now " + health);
        playerController.UpdateHealthSlider();
    }
}
