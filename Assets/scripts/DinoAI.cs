using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoAI : AI
{
    void Update()
    {
        RemainingTime -= Time.deltaTime;
        var differenceX = player.position.x - transform.position.x;
        Vector2 direction;
        if (RemainingTime <= 0)
        {
            direction = Vector2.right;
        }
        else
        {
            direction = Vector3.Normalize(differenceX * Vector2.right);
        }
        _rb.velocity = direction * Speed;
        if (Mathf.Abs(differenceX) > 1)
        {
            TurnIfNeeded();
        }
    }

    private void TurnIfNeeded()
    {
        bool isGoingLeft = _rb.velocity.x < 0;
        bool isLookingRight = transform.localScale.x > 0;
        if (isGoingLeft && isLookingRight)
        {
            TurnAround();
        }
        if (!isGoingLeft && !isLookingRight)
        {
            TurnAround();
        }
    }

    private void TurnAround()
    {
        transform.localScale *= new Vector2(-1, 1);
    }
}
