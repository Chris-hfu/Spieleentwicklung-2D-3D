﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public int startingHealth = 100;                            
    public int currentHealth;                                 
    public Slider healthSlider;                                 
    public Image damageImage;                                   
    public AudioClip deathClip;                                 
    public float flashSpeed = 5f;                               
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);     


    Animator anim;                                             
    AudioSource playerAudio;                                  
    PlayerMovement playerMovement;                             
    PlayerShooting playerShooting;                              
    bool isDead;                                               
    bool damaged;                                             


    void Awake()
    {
       
        anim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        playerMovement = GetComponent<PlayerMovement>();
        playerShooting = GetComponentInChildren<PlayerShooting>();

   
        currentHealth = startingHealth;
    }


    void Update()
    {
      
        if (damaged)
        {
         
            damageImage.color = flashColour;
        }
        
        else
        {
          
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }

     
        damaged = false;
    }


    public void TakeDamage(int amount)
    {
        // Set the damaged flag so the screen flash
        damaged = true;

        // damage taken
        currentHealth -= amount;

        // Set the health bar to the current health
        healthSlider.value = currentHealth;

        // hurt sound effect
        playerAudio.Play();

       
        if (currentHealth <= 0 && !isDead)
        {
          
            Death();
        }
    }

    
    void Death()
    {
       
        isDead = true;

       
        playerShooting.DisableEffects();

      
        anim.SetTrigger("Die");

       
        playerAudio.clip = deathClip;
        playerAudio.Play();

      
        playerMovement.enabled = false;
        playerShooting.enabled = false;
    }
    
}