using UnityEngine;

public class ItemSprings : ItemBase
{
    new private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (collision.GetComponent<Rigidbody2D>().velocity.y < 0)
                base.OnTriggerEnter2D(collision);
        }
    }
}
