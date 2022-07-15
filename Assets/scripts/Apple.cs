using UnityEngine;

public class Apple : MonoBehaviour
{
    public float HP = 3;
    private AppleTree _appleTree;
    private const int strongHit = 190;
    private const int normalHit = 30;
    private bool isCollected = false;

    private void Start()
    {
        _appleTree = FindObjectOfType<AppleTree>();
        _appleTree.AppleNum++;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isCollected == true || collision.rigidbody == null) //  если яблоко уже упало или если нет rigidbody (у пола его нет!!!!)
        {
            return;
        }

        var impact = collision.relativeVelocity.magnitude * collision.rigidbody.mass;
        if (impact > strongHit)
        {
            HP = 0;
        }
        else if (impact > normalHit)
        {
            HP--;
            GetComponent<SpriteRenderer>().color = Random.ColorHSV(0, 1, 0.9f, 1, 0.7f, 1f);
        }

        if (HP <= 0)
        {
            collision.otherRigidbody.constraints = RigidbodyConstraints2D.None;
            _appleTree.CollectApple();
            isCollected = true;
        }
    }
}
