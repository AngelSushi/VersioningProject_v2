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

    private Transform lastParent;
    private bool startDropping;

    private Vector3 beginPos;
    void Start() { }

    void Update() { 
        if(Input.GetKeyDown(KeyCode.E)) {
            Debug.Log("obj: " + hitObj);
//            Debug.Log("size: " + hitObj.gameObject.transform.childCount);

            if(hitObj != null && hitObj.gameObject.transform.childCount == 1) {
                if(transform.GetComponent<SpriteRenderer>().sprite != useStatus && collideObj) {
                    collideObj = false;
                    switch(type) {
                        case ObjectType.CHEST: 
                            transform.GetComponent<SpriteRenderer>().sprite = useStatus;
                            chestOpen.Play();
                            hitObj.GetComponent<TopDownCharacterController>().freeze = true;
                            RunDelayed(8f,() =>  {
                                hitObj.GetComponent<TopDownCharacterController>().freeze = false;
                            });
                            break;
                        
                        case ObjectType.DOOR:
                            transform.GetComponent<SpriteRenderer>().sprite = useStatus;
                            break;

                        case ObjectType.OBJECT:
                            lastParent = transform.parent;
                            transform.parent = hitObj.transform;
                            transform.localPosition = new Vector3(0,0.75f,-1);
                            break;
                    }
                }
            }
            else if(hitObj != null && hitObj.gameObject.transform.childCount == 2) {
                transform.localPosition = new Vector3(0,-0.3f,-1);
                beginPos = transform.position;
                transform.parent = lastParent;
                startDropping = true;               
            }
        }
        
        if(startDropping) {

                Vector3 forward = hitObj.transform.forward;
                if(forward.z != 0) {
                    forward.y = forward.z;
                    forward.z = 0;
                }

                Vector3 pos = new Vector3(beginPos.x + forward.x * -1.5f,beginPos.y + forward.y * -1.5f,-1f);
                transform.position = Vector2.MoveTowards(transform.position,pos,4 * Time.deltaTime);

                if(transform.position.x == pos.x && transform.position.y == pos.y) {
                    startDropping = false;
                    transform.GetComponent<SpriteRenderer>().sprite = useStatus;

                    RunDelayed(5f,() =>  {
                        transform.gameObject.SetActive(false);
                    });

                    
                }           
        }

    }

    private void OnTriggerStay2D(Collider2D hit) {
        if(hit.gameObject.tag == "Player" && !collideObj) {
            collideObj = true;
            hitObj = hit.gameObject;
        }        
    }

    private void OnTriggerExit2D(Collider2D hit) {
        if(!collideObj) 
            collideObj = false;
        
    }

}
