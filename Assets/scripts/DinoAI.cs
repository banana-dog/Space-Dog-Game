using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoAI : AI
{
    void Update()
    {
        RemainingTime -= Time.deltaTime;
        
        var distanceVector = player.position.x - transform.position.x;
        var direction = RemainingTime <= 0 ? Vector3.right : Vector3.Normalize(distanceVector * Vector3.right);
        _rb.velocity = direction * Speed;
    }
}
