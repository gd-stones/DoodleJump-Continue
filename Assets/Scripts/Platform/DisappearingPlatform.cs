using UnityEngine;

public class DisappearingPlatform : BasePlatform
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.GetComponent<Rigidbody2D>().velocity.y < 0f)
                gameObject.SetActive(false);
        }
    }
}
