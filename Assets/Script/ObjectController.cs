using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ObjectController : CoroutineSystem {
    
    public enum ObjectType {
        OBJECT,
        CHEST,
    }

    public ObjectType type;
    public AudioSource chestOpen;

    public Sprite useStatus; 
    private bool collideObj;
    void Start() { }

    void Update() { 

        if(collideObj) {
            if(Input.GetKeyDown(KeyCode.E)) {
                collideObj = false;
                
                if(type == ObjectType.CHEST) {
                    chestOpen.Play();
                    RunDelayed(8f,() =>  {
                        transform.GetComponent<SpriteRenderer>().sprite = useStatus;
                    });
                }
            }
        }

    }

    private void OnTriggerStay2D(Collider2D hit) {
        if(hit.gameObject.tag == "Player") 
            collideObj = true;
        
    }

    private void OnTriggerExit2D(Collider2D hit) {
        if(!collideObj) 
            collideObj = false;
        
    }

}
