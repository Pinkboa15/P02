using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] GameObject player;
    private PlayerHealth healthBonus;
    private int healamount = 20;
    // Start is called before the first frame update
    private void Awake()
    {
        healthBonus = player.GetComponent<PlayerHealth>();
    }
    private void OnTriggerEnter(Collider other)
    {
        healthBonus.HealPlayer(healamount);
        Destroy(this.gameObject);
    }
}
