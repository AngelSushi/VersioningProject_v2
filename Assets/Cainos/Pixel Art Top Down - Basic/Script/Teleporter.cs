using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public GameObject Player;
    public GameObject TeleportTo;
    public GameObject StartTeleporter;

    public Animator fadeSystem;
    //public PlayerMovement movePlayer;
    
    private int speedLost = 5;
    private float speedDuration = 1f;

    public AudioSource Audio_Tp;

    [SerializeField] private AudioClip audioTp;

    private void Awake()
    {
        Audio_Tp = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Teleporter"))
        {
                StartCoroutine(TimeToTeleport());

            //movePlayer.moveSpeed -= speedLost;
            StartCoroutine(RecupSpeed(speedLost, speedDuration));

        }
     

        if (collision.gameObject.CompareTag("SecondTeleporter"))
        {
            
            StartCoroutine(TimeToTeleport2());
          
            //movePlayer.moveSpeed -= speedLost;
            StartCoroutine(RecupSpeed(speedLost, speedDuration));
        }

      


    }


    public IEnumerator RecupSpeed(int speedLost, float speedDuration)
    {
        yield return new WaitForSeconds(speedDuration);
      //  movePlayer.moveSpeed += speedLost;
       

    }

    public IEnumerator TimeToTeleport()
    {

       Audio_Tp.PlayOneShot(audioTp);
        fadeSystem.SetTrigger("FadeIn");
        yield return new WaitForSeconds(1f);
        
        Player.transform.position = TeleportTo.transform.position;
      


    }

    public IEnumerator TimeToTeleport2()
    {
      
        fadeSystem.SetTrigger("FadeIn");
        yield return new WaitForSeconds(1f);
        Player.transform.position = StartTeleporter.transform.position;
       
    }

}
