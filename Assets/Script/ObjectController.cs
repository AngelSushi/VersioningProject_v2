using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ObjectController : CoroutineSystem {
    
    public enum ObjectType {
        OBJECT,
        CHEST,
        DOOR,
    }

    public ObjectType type;
    public AudioSource chestOpen;

    public Sprite useStatus; 
    private bool collideObj;
    private GameObject hitObj;
    void Start() { }

    void Update() { 

        if(collideObj) {
            if(Input.GetKeyDown(KeyCode.E)) {
                collideObj = false;
                if(transform.GetComponent<SpriteRenderer>().sprite != useStatus) {
                    transform.GetComponent<SpriteRenderer>().sprite = useStatus;
                    if(type == ObjectType.CHEST) {
                        chestOpen.Play();
                        hitObj.GetComponent<Cainos.PixelArtTopDown_Basic.TopDownCharacterController>().freeze = true;
                        RunDelayed(8f,() =>  {
                            hitObj.GetComponent<Cainos.PixelArtTopDown_Basic.TopDownCharacterController>().freeze = false;
                        });
                    }
                }
                
            }
        }

    }

    private void OnTriggerStay2D(Collider2D hit) {
        if(hit.gameObject.tag == "Player") {
            collideObj = true;
            hitObj = hit.gameObject;
        }        
    }

    private void OnTriggerExit2D(Collider2D hit) {
        if(!collideObj) 
            collideObj = false;
        
    }

}
