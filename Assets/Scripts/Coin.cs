using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] AudioClip _coinSound;
    Level01Controller controller;
    // Start is called before the first frame update
    private void Awake()
    {
        controller = FindObjectOfType<Level01Controller>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            controller.IncreaseScore(5);
            AudioHelper.PlayClip2D(_coinSound,1);
            Destroy(this.gameObject);
        }

    }
}
