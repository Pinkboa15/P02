using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] GameObject player;
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
            Destroy(this.gameObject);
        }

    }
}
