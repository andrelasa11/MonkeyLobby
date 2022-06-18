using UnityEngine;

public class FuelController_HD : MonoBehaviour
{
    [Header("Configuration")]
    public float fuelToAdd;

    public void AddFuel()
    {
        GameController_HD.Instance.SetFuel(fuelToAdd);
    }
}
