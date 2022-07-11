using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoEgg : MonoBehaviour
{
    public GameObject CrackedEggBottom, CrackedEggTop, DinoPrefab;
    [Range(1, 100)]
    public float EggTimeMin;
    [Range(1, 100)]
    public float EggTimeMax;
    public AudioSource MusicAs;
    public Sprite CrackedEggSprite, TopSprite, BottomSprite;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnDelayed());
        MusicAs = GameObject.Find("music").GetComponent<AudioSource>();
    }
    IEnumerator SpawnDelayed()
    {
        while (true)
        {   // подождать, пока яйцо треснет
            yield return new WaitForSeconds(Random.Range(EggTimeMin, EggTimeMax));
            // TODO Добавить звук треска!!!!!!!!!!!!!!!!!
            GetComponent<SpriteRenderer>().sprite = CrackedEggSprite;
            yield return new WaitForSeconds(Random.Range(2, 5));

            GetComponent<SpriteRenderer>().enabled = false; // делаем яйцо невидимым
            GetComponent<CapsuleCollider2D>().enabled = false; // отключаем коллайдер яйца

            CrackedEggBottom.transform.parent = null;
            CrackedEggBottom.SetActive(true);
            CrackedEggBottom.GetComponent<SpriteRenderer>().sprite = BottomSprite;


            CrackedEggTop.transform.parent = null;
            CrackedEggTop.SetActive(true);
            CrackedEggTop.GetComponent<SpriteRenderer>().sprite = TopSprite;

            yield return new WaitForSeconds(1);
            Instantiate(DinoPrefab, CrackedEggBottom.transform.TransformPoint(new Vector3(0, 0.488f, 0)), Quaternion.identity);
            Destroy(gameObject);
            break;
        }
    }
}