using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarDetection : CoroutineSystem {

    private void OnTriggerEnter2D(Collider2D hit) {
        if(hit.gameObject.tag == "Pilars") 
            hit.gameObject.transform.GetChild(0).gameObject.SetActive(true);   
    }

    private void OnTriggerExit2D(Collider2D hit) {
        if(hit.gameObject.tag == "Pilars") 
            hit.gameObject.transform.GetChild(0).gameObject.SetActive(false); 
    }
}
