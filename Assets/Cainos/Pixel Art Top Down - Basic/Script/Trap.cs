using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    int damage = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Debug.Log("Toucher FRERO");
            TopDownCharacterController.instance.TakeDamage(damage);
            TopDownCharacterController.instance.die();
        }
            

    }
}
