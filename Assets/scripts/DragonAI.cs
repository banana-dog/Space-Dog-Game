using UnityEngine;

public class DragonAI : AI
{
    public ParticleSystem ps;

    void Update()
    {
        RemainingTime -= Time.deltaTime;
        var distanceVector = player.position - transform.position;
        Vector3 direction;
        if (RemainingTime <= 0)
        {
            direction = Vector3.up;
            var e = ps.emission;
            e.enabled = true;
        }
        else
        {
            direction = Vector3.Normalize(distanceVector);
        }

        if (distanceVector.magnitude > player.localScale.x * 3)
        {
            _rb.velocity = direction * Speed;
        }
        else
        {
            _rb.velocity = direction * (-Speed);
        }
    }
}