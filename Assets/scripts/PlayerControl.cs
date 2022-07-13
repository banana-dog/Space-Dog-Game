using UnityEngine;
using UnityEngine.UI;
using CnControls;
using System.Collections;

[System.Serializable]
public class Stuff
{
    public GameObject Prefab;
    public Sprite Icon;
    public AudioClip CreateAudio;
    public float Delay;
}
public class PlayerControl : MonoBehaviour
{
    public float MassFactor = 50;
    public float MaxSize = 7, MinSize = 0.5f;
    public float GrowthSize = 0.01f;
    public float speed;
    public Text score, message;
    public GameObject poop, brick, ball;
    public Stuff[] poops;
    public Image SwitchButtonIcon, CreateButtonIcon;
    public GameObject Popa;
    public AudioSource MusicAs, SfxAs, RocketAs;
    public AudioClip ChangeObjectSound;
    public AudioClip MishkaSizeSound;
    public Transform CoolDownAnim;
    public float limy = 30;
    private Stuff currentItem;
    private bool ready = true;//not ready
    private Rigidbody2D _rb;
    private int index = 0;

    void Start()
    {
        currentItem = poops[index];
        //SwitchButtonIcon.sprite = currentItem.Icon;
        CreateButtonIcon.sprite = currentItem.Icon;
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Spawn(GameObject go)
    {
        var new_g = Instantiate(go, Popa.transform.position, go.transform.rotation);
        if (go == brick || go == ball)
        {
            new_g.GetComponent<SpriteRenderer>().color = Random.ColorHSV(0, 1, 0.9f, 1, 0.7f, 1f);
        }
        MusicAs.PlayOneShot(currentItem.CreateAudio);
    }

    IEnumerator SpawnDelayed(GameObject go)
    {
        Spawn(go);
        ready = false;
        StartCoroutine(AnimateCoolDown(currentItem.Delay));
        yield return new WaitForSeconds(currentItem.Delay);
        ready = true;
    }

    /// <summary>
    /// перезарядка объектов!!!!!
    /// </summary>
    /// <param name="delay">время загрузки сек</param>
    IEnumerator AnimateCoolDown(float delay)
    {
        var remainingDelay = delay;
        CoolDownAnim.localScale = new Vector3(CoolDownAnim.localScale.x, CoolDownAnim.localScale.x, CoolDownAnim.localScale.y);
        while (remainingDelay > 0)
        {
            float step = CoolDownAnim.localScale.x * Time.deltaTime / delay;
            CoolDownAnim.localScale -= new Vector3(0, step, 0);
            remainingDelay -= Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
    }

    public void NextPoop()
    {
        index++;
        if (index >= poops.Length)
        {
            index = 0;
        }
        currentItem = poops[index];
       // SwitchButtonIcon.sprite = currentItem.Icon;
        CreateButtonIcon.sprite = currentItem.Icon;
    }
    private void Update()
    {
        if (CnInputManager.GetButton("Jump"))
        {
            if (ready)
            {
                if (currentItem.Prefab == poop)
                {
                    if (ChangeSize(-GrowthSize * 5))
                    {
                        StartCoroutine(SpawnDelayed(currentItem.Prefab));
                    }
                }
                else
                {
                    StartCoroutine(SpawnDelayed(currentItem.Prefab));
                }
            }

        }

        if (CnInputManager.GetButtonUp("Fire3"))
        {
            MusicAs.PlayOneShot(ChangeObjectSound);
            NextPoop();
        }

        if (CnInputManager.GetButton("zoom_in"))
        {
            ChangeSize(GrowthSize);
        }

        if (CnInputManager.GetButton("zoom_out"))
        {
            ChangeSize(-GrowthSize);
        }
    }

    private bool ChangeSize(float growth_size)
    {
        var scale = new Vector3(transform.localScale.x + growth_size, transform.localScale.y + growth_size, transform.localScale.z + growth_size);
        if (scale.x < MaxSize && scale.x > MinSize)
        {
            transform.localScale = scale;
            _rb.mass = MassFactor * scale.x;
            if (!SfxAs.isPlaying)
            {
                SfxAs.PlayOneShot(MishkaSizeSound);
            }

            return true;
        }
        return false;
    }

    void FixedUpdate()
    {
        var movX = CnInputManager.GetAxis("Horizontal");
        var movY = CnInputManager.GetAxis("Vertical");
        var movement = Vector2.zero;
        movement.x = movX;
        movement.y = movY;
        movement *= speed;
        if (transform.position.y > limy)
        {
            movement.y = 0;
        }
        _rb.velocity = Vector2.ClampMagnitude(movement, speed);
        RocketAs.volume = _rb.velocity.magnitude / speed;
    }
}


