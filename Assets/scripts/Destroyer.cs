using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public float delay = 5;
    void Start()
    {
        Destroy(gameObject, delay);
    }
    void OnBecameInvisible()
    {
        //player.Score--;
        Destroy(gameObject, delay);
    }
}