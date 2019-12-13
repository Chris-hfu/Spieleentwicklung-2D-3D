using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    public int startingHealth = 100;            
    public int currentHealth;                   
                
    public int scoreValue = 10;                 
    public AudioClip deathClip;                 


    Animator anim;                             
    AudioSource enemyAudio;                     
    ParticleSystem hitParticles;                
    CapsuleCollider capsuleCollider;           
    bool isDead;                                
   


    void Awake()
    {
        
        anim = GetComponent<Animator>();
        enemyAudio = GetComponent<AudioSource>();
        hitParticles = GetComponentInChildren<ParticleSystem>();
        capsuleCollider = GetComponent<CapsuleCollider>();

       
        currentHealth = startingHealth;
    }

    void Update()
    {
        
    }


    public void TakeDamage(int amount, Vector3 hitPoint)
    {
       
        if (isDead)
            
            return;

        //hurt sound 
        enemyAudio.Play();

        // damage taken
        currentHealth -= amount;

        // position of the particle system 
        hitParticles.transform.position = hitPoint;

       
        hitParticles.Play();

       // check if the enemy is dead 
        if (currentHealth <= 0)
        {
            
            Death();
        }
    }


    void Death()
    {
      
        isDead = true;
     

        // Turn the collider into a trigger so shots can pass through
        capsuleCollider.isTrigger = true;

       
        anim.SetTrigger("Dead");
      

      
        enemyAudio.clip = deathClip;
        enemyAudio.Play();
        ScoreManager.score += scoreValue;
        ScoreStatic.points += scoreValue;
        Destroy(gameObject, 0.3f);

    }


}