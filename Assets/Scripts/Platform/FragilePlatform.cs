using UnityEngine;
using DG.Tweening;

public class FragilePlatform : BasePlatform
{
    [SerializeField] private Animator animator;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.GetComponent<Rigidbody2D>().velocity.y < 0f)
            {
                animator.SetBool("break", true);
                transform.DOMoveY(transform.position.y - 6f, 2.5f);
            }
        }
    }


    //new private void Start()
    //{
    //    base.Start(); // khong co dong nay thi sao
    //    // some code
    //}
}
