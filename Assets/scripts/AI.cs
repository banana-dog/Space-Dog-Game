using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class AI : MonoBehaviour
{
    [Range(0, 20)]
    public float Speed = 1;
    public AudioClip Hello;
    public float RemainingTime = 40;
    private AudioSource MusicAs;
    protected Rigidbody2D _rb;
    protected Transform player;

    void Start()
    {
        player = GameObject.Find("mishka-dog").transform;
        _rb = GetComponent<Rigidbody2D>();
        MusicAs = GameObject.Find("music").GetComponent<AudioSource>();
        MusicAs.PlayOneShot(Hello);
    }

    // Update is called once per frame
    void Update()
    {
        var distanceVector = player.position - transform.position;
        var direction = Vector3.Normalize(distanceVector);
        if (distanceVector.magnitude > player.localScale.x * 12)
        {
            _rb.velocity = direction * Speed;
        }
        else
        {
            _rb.velocity = direction * (-Speed);
        }
    }

    void OnBecameInvisible()
    {
        if (RemainingTime <= -10)
        {
            Destroy(gameObject);
        }
    }
}