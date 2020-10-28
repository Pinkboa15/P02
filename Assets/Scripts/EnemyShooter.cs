using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    int health = 100;

    // Update is called once per frame
    public void TakeDamage(int _damgetoTake)
    {
        health -= _damgetoTake;
        if(health == 0)
        {
            Destroy(this.gameObject);
        }
    }
}
