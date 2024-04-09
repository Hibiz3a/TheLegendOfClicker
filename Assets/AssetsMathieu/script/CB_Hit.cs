using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class CB_Hit : MonoBehaviour
{

    private bool collisionCheck;
    [SerializeField]
    private int health;
    Vector2 newPos;
    int index;

    private float timeCoolDown;
    [SerializeField]
    private int timer;

    [SerializeField]
    private List<Sprite> spriteColor = new List<Sprite>();

    private bool scored;
    private void Start()
    {
        timeCoolDown = timer;
    }
    private void FixedUpdate()
    {
        if (timeCoolDown < 0 && !scored)
        {
            Destroy(gameObject);
            MS_MouseClick.instance.Score--;
            timeCoolDown = timer;
        }
        else
        {
            timeCoolDown -= Time.fixedDeltaTime;
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && collisionCheck && health >= 1)
        {
            newPos = new Vector2(Random.Range(64, transform.parent.transform.position.x-64), Random.Range(64, transform.parent.transform.position.y-64));
            health--;
            transform.position = newPos;
            index++;
            gameObject.GetComponent<Image>().sprite = spriteColor[index];
            gameObject.GetComponent<Image>().SetNativeSize();

        }

        if (health <= 0)
        {
            scored = true;
            StartCoroutine(Destroy());
        }
    }

    IEnumerator Destroy()
    {
        transform.Rotate(new Vector3(0f, 0f, 1f));
        yield return new WaitForSeconds(2);
        MS_MouseClick.instance.Score++;
        Destroy(gameObject);
        StopCoroutine(Destroy());
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Mouse"))
        {
            collisionCheck = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Mouse"))
        {
            collisionCheck = false;
        }
    }
}
