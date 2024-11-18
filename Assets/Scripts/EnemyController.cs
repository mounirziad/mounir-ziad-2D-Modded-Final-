using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
   // Public variables
   public float speed;
   public bool vertical;
   public float changeTime = 3.0f;
  
   // Private variables
   Rigidbody2D rigidbody2d;
   Animator animator;
   float timer;
   int direction = 1;
   bool aggressive = true;
   public ParticleSystem smokeEffect;

   // Reference to PlayerController, assigned on collision for score management
   public PlayerController scorecontroller;

   // Start is called before the first frame update
   void Start()
   {
       rigidbody2d = GetComponent<Rigidbody2D>();
       animator = GetComponent<Animator>();
       timer = changeTime;
   }

   // Update is called every frame
   void Update()
   {
       if (!aggressive)
       {
          return;
       }
   }

   // FixedUpdate has the same call rate as the physics system
   void FixedUpdate()
   {
      if (!aggressive)
      {
           return;
      }
     
      timer -= Time.deltaTime;

      if (timer < 0)
      {
           direction = -direction;
           timer = changeTime;
      }
     
      Vector2 position = rigidbody2d.position;
     
      if (vertical)
      {
           position.y = position.y + speed * direction * Time.deltaTime;
           animator.SetFloat("Move X", 0);
           animator.SetFloat("Move Y", direction);
      }
      else
      {
          position.x = position.x + speed * direction * Time.deltaTime;
          animator.SetFloat("Move X", direction);
          animator.SetFloat("Move Y", 0);
      }

      rigidbody2d.MovePosition(position);
   }

   // Detect collision with player
   void OnCollisionEnter2D(Collision2D other)
{
    PlayerController player = other.gameObject.GetComponent<PlayerController>();

    if (player != null)
    {
        player.ChangeHealth(-1);
        scorecontroller = player; // Assign player to scorecontroller for use in Fix
    }
}

   public void Fix()
{
    aggressive = false;
    GetComponent<Rigidbody2D>().simulated = false;
    animator.SetTrigger("Fixed");
    smokeEffect.Stop();

    // Use scorecontroller to update the score if it is valid
    if(scorecontroller != null && scorecontroller.score < scorecontroller.maxScore)
    {
        scorecontroller.ChangeScore(1);
        Debug.Log("Score Up 1");
    }
    else
    {
        Debug.Log("Scorecontroller is null or max score reached");
    }
}

}
