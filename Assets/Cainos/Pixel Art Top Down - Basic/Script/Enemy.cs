using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 3f;
    private Transform target;
   
    
    private void Update()
    {
        if (target != null)
        {
            StartCoroutine(WaitToStep());

        }
        else
        {
            StopAllCoroutines();
        }
    }



  

 

    public IEnumerator WaitToStep()
    {
        yield return new WaitForSeconds(1f);
        float step = speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, target.position, step);
       
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {

            target = col.transform;


        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            target = null;

            Debug.Log(target);
        }
    }
}
