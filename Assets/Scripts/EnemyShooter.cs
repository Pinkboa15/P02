using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    [SerializeField] AudioClip _EnemySound;
    int health = 100;

    // Update is called once per frame
    public void TakeDamage(int _damgetoTake)
    {
        health -= _damgetoTake;
        AudioHelper.PlayClip2D(_EnemySound, 1);
        if (health == 0)
        {
            Destroy(this.gameObject);
        }
    }
}
