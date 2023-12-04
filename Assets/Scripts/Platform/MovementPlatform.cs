using UnityEngine;

public class MovementPlatform : BasePlatform
{
    public float movementSpeed = 1f;
    private float movementDirection = 1f;

    private void Update()
    {
        MoveSideways();
    }

    private void MoveSideways()
    {
        transform.Translate(Vector3.right * movementSpeed * movementDirection * Time.deltaTime);

        if (transform.position.x >= 1.75f)
        {
            movementDirection = -1f;
        }
        else if (transform.position.x <= -1.75f)
        {
            movementDirection = 1f;
        }
    }
}