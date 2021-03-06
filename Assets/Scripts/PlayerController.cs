﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 5f;
    public float gravity = -9.8f;
    public float jumpHeight = 3f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public ParticleSystem shoot;
    Vector3 velocity;
    bool isGrounded;
    public Slider healthSlider;
    public PlayerHealth playerHealth;

    private void Start()
    {
        shoot.Stop();
        healthSlider.value = playerHealth.health;
    }

    // Update is called once per frame 
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        if (Input.GetKey("left shift"))
        {
            speed = 20f;
        }
        else
        {
            speed = 5f;
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            shoot.Play();
        }
        else
        {
            shoot.Stop();
        }
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
    public void UpdateHealthSlider()
    {
        //set the slider value equal to the health
        healthSlider.value = playerHealth.health;
    }
}