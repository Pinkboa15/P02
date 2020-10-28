using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWeapon : MonoBehaviour
{
    [SerializeField] Camera cameraController;
    [SerializeField] Transform rayOrigin;
    [SerializeField] float shootDistance = 10f;
    [SerializeField] GameObject visualFeebackobject;
    [SerializeField] int weaponDamge = 25;
    RaycastHit objectHit;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }
    }
    void Shoot()
    {
        //calculate direction to shoot the ray 
        Vector3 rayDirection = cameraController.transform.forward;
        // cast a debug ray
        Debug.DrawRay(rayOrigin.position, rayDirection * shootDistance, Color.blue, 1f);
        //do the raycast
        if(Physics.Raycast(rayOrigin.position, rayDirection, out objectHit, shootDistance))
        {
            Debug.Log("You Hit the "+ objectHit.transform.name);
            visualFeebackobject.transform.position = objectHit.point;
            EnemyShooter enemy = objectHit.transform.gameObject.GetComponent<EnemyShooter>();
            if(enemy != null)
            {
                enemy.TakeDamage(weaponDamge);
            }
        }
        else
        {
            Debug.Log("Miss.");
        }
    }
}
