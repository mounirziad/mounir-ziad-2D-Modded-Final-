using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageHealth : MonoBehaviour
{
    
 //This function is called when another gameobject collides with the damage collectable.
    //This could be an enemy or the playercharacter. OnTriggerEnter2D is a unity 
    //function that is called on the first frame when the physics system detects a gameobject
    //with rigidbody hitting the gameobject collider that is a trigger. The other will contain
    //the reference to the collider component that just entered the trigger. 
    void OnTriggerStay2D(Collider2D other)
    {
        //Creates the variable controller that References the player controller script 
        //
        PlayerController controller = other.GetComponent<PlayerController>();
        //If the controller contains the information from the playercontroller
        //Health is just currenthealth but not public. 
        if(controller != null)
        {
            //Controller accesses the changehealth method from our playercontroller script 
            //its able to do this because of the getcomponent. After that, the health 
            //of the character changes by one and the gameobject is destroyed.
            controller.ChangeHealth(-1);
            
            
        }

    }
}
