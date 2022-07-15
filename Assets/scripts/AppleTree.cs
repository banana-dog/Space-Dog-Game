using UnityEngine;
using UnityEngine.UI;

public class AppleTree : MonoBehaviour
{
    public float RepeatRate = 10;
    public Text AppleText, CollectedAppleText;
    public GameObject Apple;
    private int appleNum, collectedAppleNum;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnApple), 0, RepeatRate);
    }

    public int AppleNum
    {
        get
        {
            return appleNum;
        }
        set
        {
            appleNum = value;
            AppleText.text = "Яблочек на дереве: " + appleNum;
        }
    }

    public int CollectedAppleNum
    {
        get
        {
            return collectedAppleNum;
        }
        set
        {
            collectedAppleNum = value;
            CollectedAppleText.text = "Собрано яблочек: " + collectedAppleNum;
        }
    }

    public void SpawnApple()
    {
        if (AppleNum < 5)
        {
            var apple = Instantiate(Apple, transform);
            var randomPosition = new Vector3(Random.Range(-2.5f, 2.5f), Random.Range(-2.5f, 2.5f), -0.5f);
            apple.transform.localPosition = Vector3.ClampMagnitude(randomPosition, 2.5f) + Vector3.up;
        }
    }

    public void CollectApple()
    {
        AppleNum--;
        CollectedAppleNum++;
    }
}
