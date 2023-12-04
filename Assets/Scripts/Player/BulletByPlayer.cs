using System.Collections.Generic;
using UnityEngine;

public class BulletByPlayer : MonoBehaviour
{
    [Header("Bullet Specifications")]
    [SerializeField] private float speed;
    [SerializeField] private float resetTime;
    private float lifetime;

    private CircleCollider2D circleCol;
    private bool hit;

    private void Awake()
    {
        circleCol = gameObject.GetComponent<CircleCollider2D>();
    }

    public void ActivateBullet()
    {
        hit = false;
        lifetime = 0;
        gameObject.SetActive(true);
        circleCol.enabled = true;
    }

    private void Update()
    {
        if (hit) return;

        float bulletSpeed = speed * Time.deltaTime;
        transform.Translate(bulletSpeed, 0, 0);

        lifetime += Time.deltaTime;
        if (lifetime > resetTime)
            gameObject.SetActive(false);
    }

    List<string> tagsToCheck = new List<string> { "Enemy" };
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (tagsToCheck.Contains(collision.gameObject.tag))
        {
            hit = true;
            circleCol.enabled = false;

            collision.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}