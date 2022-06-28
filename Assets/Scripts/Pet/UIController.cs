using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{

    [SerializeField] private Slider dirtSlider;
    [SerializeField] private Slider happinessSlider;
    [SerializeField] private Slider energySlider;
    [SerializeField] private Slider foodSlider;

    public void SetDirt(int value)
    {
        dirtSlider.value = value;
    }

    public void SetHappiness(int value)
    {
        happinessSlider.value = value;
    }

    public void SetEnergy(int value)
    {
        energySlider.value = value;
    }

    public void SetFood(int value)
    {
        foodSlider.value = value;
    }
}
