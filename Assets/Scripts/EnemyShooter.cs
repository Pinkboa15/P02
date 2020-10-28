using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    [SerializeField] AudioClip _EnemySound;
    [SerializeField] Transform player;
    [SerializeField] Transform raycastStartPos = null;
    
    int health = 100;
    public float range = 20.0f;
    private bool onRange = false;
    public PlayerHealth playerHealth;
    void Start()
    {
        float rand = Random.Range(1.0f, 2.0f);
        InvokeRepeating("Shoot", 2, rand);
    }
    void Update()
    {

        onRange = Vector3.Distance(transform.position, player.position) < range;

        if (onRange)
            transform.LookAt(player);
    }
    public void TakeDamage(int _damgetoTake)
    {
        health -= _damgetoTake;
        AudioHelper.PlayClip2D(_EnemySound, 2);
        if (health == 0)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Shoot();
    }
    public void Shoot()
    {
        if (onRange)
        {
            RaycastScan();
        }
    }
    public void RaycastScan()
    {
        Vector3 rayStartPos = raycastStartPos.position;
        Vector3 rayDirection = transform.forward;
        float rayLength = 10;
        RaycastHit hit;
        if (Physics.Raycast(rayStartPos, rayDirection, out hit, rayLength))
        {
            string objName = hit.collider.gameObject.name;
            playerHealth.DamagePlayer(5);
            Debug.Log("Hit Object - " + objName);
        }
        else
        {
            Debug.Log("No object detected");
        }
    }
}
