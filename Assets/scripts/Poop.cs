using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poop : MonoBehaviour
{
    public Sprite SadPoop;
    public bool destroyed;
    public Sprite Masha;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Contains("brick"))
        {
            var thecolor = collision.gameObject.GetComponent<SpriteRenderer>();
            var poopsprite = GetComponent<SpriteRenderer>();
            if (poopsprite.sprite == SadPoop)
            {
                transform.localScale *= 0.9f;
            }
            thecolor.color = Color.red;
            poopsprite.sprite = SadPoop;
        }
        if (collision.gameObject.name.Contains("ice"))
        {
            var poopsprite = GetComponent<SpriteRenderer>();
            poopsprite.sprite = Masha;
            transform.localScale *= 2;
        }
        if (collision.gameObject.name.Contains("poop"))
        {
            destroyed = true;
            transform.localScale += Vector3.one/20;
            if (collision.gameObject.GetComponent<Poop>().destroyed == false)
            {
            Destroy(collision.gameObject);
            }
        }
    }
}
