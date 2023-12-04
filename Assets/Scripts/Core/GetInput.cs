using UnityEngine;

public class GetInput : MonoBehaviour
{
    public static float horizontalInput;
    public static bool isSpacePressed;

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        isSpacePressed = Input.GetKeyDown(KeyCode.Space);
    }
}