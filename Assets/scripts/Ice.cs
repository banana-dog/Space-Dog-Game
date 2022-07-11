using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ice : MonoBehaviour
{
    private bool isSqueezing = false;
    public float Duration = 5;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<DragonAI>() != null)
        {
            if (!isSqueezing)
            {
                StartCoroutine(squeeze());
            }
        }
    }

    private IEnumerator squeeze()
    {
        isSqueezing = true;
        for (float t = 0; t < Duration; t += Time.deltaTime)
        {
            float progress = t / Duration;
            transform.localScale -= progress*Vector3.one*Time.deltaTime;
            if (transform.localScale.x < 0)
            {
                Destroy(gameObject);
            }
            yield return new WaitForEndOfFrame();
        }
    }
}
