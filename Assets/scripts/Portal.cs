using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{    
    public Vector3 Destination;
    public AudioSource MusicAs;
    public AudioClip TeleportationSound;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destination.y = collision.transform.position.y;
        collision.transform.position = Destination;
        MusicAs.PlayOneShot(TeleportationSound);
    }
}
