using UnityEngine;
using UnityEngine.UI;

public class AppleTree : MonoBehaviour
{
    public Text AppleText, CollectedAppleText;
    public GameObject Apple;
    private int appleNum, collectedAppleNum;
    private void Start()
    {
        InvokeRepeating(nameof(SpawnApple), 0, 10f);
    }
    public int AppleNum
    {
        get => appleNum;
        set
        {
            appleNum = value;
            AppleText.text = "Яблочек на дереве: " + appleNum;
        }
    }

    public int CollectedAppleNum
    {
        get => collectedAppleNum;
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
            var apple = Instantiate(Apple, transform, false);
            apple.transform.localPosition = new Vector3(Random.Range(-2.5f, 2.5f), Random.Range(-1.5f, 3.5f), -0.5f);
        }
    }
    public void CollectApple()
    {
        AppleNum--;
        CollectedAppleNum++;
    }
}
