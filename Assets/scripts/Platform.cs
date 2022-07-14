using UnityEngine;

public class Platform : MonoBehaviour
{
    private void Update()
    {
        transform.Rotate(0, 0, 50 * Time.deltaTime);
    }
}
