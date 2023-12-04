using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 10f;
    private Rigidbody2D rb;
    private Vector2 velocity;
    public float jumpForce = 10f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        PlayerPosXReversal();
    }

    // Split this function to the small function
    private void FixedUpdate()
    {
        velocity = rb.velocity;
        velocity.x = GetInput.horizontalInput * movementSpeed * Time.deltaTime;

        rb.velocity = velocity;

        if (GetInput.horizontalInput < -0.01f)
            transform.localScale = new Vector3(-1f, transform.localScale.y, transform.localScale.z);
        else if (GetInput.horizontalInput > 0.01f)
            transform.localScale = new Vector3(1f, transform.localScale.y, transform.localScale.z);
    }

    private void PlayerPosXReversal()
    {
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(Camera.main);
        Vector3 currentPosPlayer = transform.position;
        Vector3 newPosPlayer = currentPosPlayer;

        if (currentPosPlayer.x > planes[0].distance)
            newPosPlayer.x = -planes[1].distance;
        else if (currentPosPlayer.x < -planes[1].distance)
            newPosPlayer.x = planes[0].distance;

        transform.position = newPosPlayer;
    }

    private bool isActiveSword = false;
    private bool isActiveShield = false;
    private bool isActiveSprings = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Player will jump upwards on impact
        if (collision.CompareTag("Platform"))
        {
            if (rb.velocity.y < 0)
            {
                if (isActiveSprings)
                    Jump(1.5f);
                else
                    Jump(1);
            }
        }

        if (collision.CompareTag("Springs"))
        {
            if (rb.velocity.y < 0)
                StartCoroutine(ToggleItemSprings());
        }
        else if (collision.CompareTag("Rocket"))
        {
            Jump(3);
        }
        else if (collision.CompareTag("Shield"))
        {
            StartCoroutine(ToggleItemShield());
        }
        else if (collision.CompareTag("Sword"))
        {
            isActiveSword = true;
            EventManager.EnableSwordFeature();
        }
        else if (collision.CompareTag("BuffPlatf")) // done
        {
            StartCoroutine(ToggleItemBuffPlatf());
        }

        if (collision.CompareTag("Enemy"))
        {
            if (!isActiveSword && !isActiveShield)
            {
                GameManager.Instance.isGameOver = true;
            }

            isActiveSword = false;
        }
    }

    private void Jump(float scale)
    {
        Vector2 velocity = rb.velocity;
        velocity.y = jumpForce * scale;
        rb.velocity = velocity;
    }

    private IEnumerator ToggleItemSprings()
    {
        isActiveSprings = true;

        yield return new WaitForSeconds(5f);
        isActiveSprings = false;
    }

    private IEnumerator ToggleItemBuffPlatf()
    {
        EventManager.ScalePlatforms();

        yield return new WaitForSeconds(5f);
        EventManager.DescalePlatforms();
    }

    private IEnumerator ToggleItemShield()
    {
        EventManager.EnableShieldFeature();
        isActiveShield = true;

        yield return new WaitForSeconds(5f);
        EventManager.DisableShieldFeature();
        isActiveShield = false;
    }
}
