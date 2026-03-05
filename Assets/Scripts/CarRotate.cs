using UnityEngine;
using UnityEngine.InputSystem;

public class CarRotate : MonoBehaviour
{
    public float rotationSpeed = 100f;

    private bool dragging = false;

    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            dragging = true;
        }

        if (Mouse.current.leftButton.wasReleasedThisFrame)
        {
            dragging = false;
        }

        if (dragging)
        {
            float mouseX = Mouse.current.delta.ReadValue().x;

            transform.Rotate(Vector3.up, -mouseX * rotationSpeed * Time.deltaTime);
        }
    }
}