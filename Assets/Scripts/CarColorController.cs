using UnityEngine;

public class CarColorController : MonoBehaviour
{
    public Renderer carRenderer;

    public void SetRed()
    {
        carRenderer.material.color = Color.red;
    }

    public void SetBlack()
    {
        carRenderer.material.color = Color.black;
    }

    public void SetBlue()
    {
        carRenderer.material.color = Color.blue;
    }
}