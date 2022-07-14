using UnityEngine;

public class Apple : MonoBehaviour
{
    public float HP = 3;
    private AppleTree _appleTree;
    private void Start()
    {
        _appleTree = FindObjectOfType<AppleTree>();
        _appleTree.AppleNum++;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.otherRigidbody.constraints == RigidbodyConstraints2D.None)
        {
            return;
        }
        var impact = collision.relativeVelocity.magnitude * collision.rigidbody?.mass;
        if (impact > 190)
        {
            HP = 0;
        }
        else if (impact > 30)
        {
            HP--;
            GetComponent<SpriteRenderer>().color = Random.ColorHSV(0, 1, 0.9f, 1, 0.7f, 1f);
        }
        if (HP <= 0)
        {
            collision.otherRigidbody.constraints = RigidbodyConstraints2D.None;
            _appleTree.CollectApple();
        }
    }
}
