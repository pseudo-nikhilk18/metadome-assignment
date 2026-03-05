using UnityEngine;

public class WheelManager : MonoBehaviour
{
    public Renderer frontWheel;
    public Renderer rearWheel;

    public Material sportMaterial;
    public Material luxuryMaterial;
    public Material classicMaterial;

    public void SetSport()
    {
        frontWheel.material = sportMaterial;
        rearWheel.material = sportMaterial;
    }

    public void SetLuxury()
    {
        frontWheel.material = luxuryMaterial;
        rearWheel.material = luxuryMaterial;
    }

    public void SetClassic()
    {
        frontWheel.material = classicMaterial;
        rearWheel.material = classicMaterial;
    }
}