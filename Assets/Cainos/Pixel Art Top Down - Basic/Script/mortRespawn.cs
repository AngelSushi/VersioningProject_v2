using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mortRespawn : MonoBehaviour
{
    public GameObject ObjectToDestroy;
   
    private Transform target;

    int damage = 1;

    //public Animator Enemy;

    private AudioSource Audio_SCREAM;

    [SerializeField] private AudioClip audioSCREAM = null;

    private void Awake()
    {
        Audio_SCREAM = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.tag == "Player")
        {
            Audio_SCREAM.PlayOneShot(audioSCREAM);
            
          
            StartCoroutine(TimeToDie(col));
           
            //Enemy.SetBool("DieEnemy",true);



            GameObject.Destroy(ObjectToDestroy, 2.0f);
        }

        if (col.tag == "Player")
        {
            Debug.Log("Toucher FRERO");
            TopDownCharacterController.instance.TakeDamage(damage);
            TopDownCharacterController.instance.die();
        }

    }



    public IEnumerator TimeToDie(Collider2D col)
    {
        yield return new WaitForSeconds(1f);
        col.transform.position = GameObject.FindGameObjectWithTag("PlayerSpawn").transform.position;
        
    }



}
