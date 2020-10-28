using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] AudioClip _healthSound;
    private PlayerHealth healthBonus;
    private int healamount = 20;
    // Start is called before the first frame update
    private void Awake()
    {
        healthBonus = player.GetComponent<PlayerHealth>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            healthBonus.HealPlayer(healamount);
            AudioHelper.PlayClip2D(_healthSound, 1);
            Destroy(this.gameObject);
        }
        
    }
}
