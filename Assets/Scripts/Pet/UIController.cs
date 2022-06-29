using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{

    [SerializeField] private Slider dirtSlider;
    [SerializeField] private Slider happinessSlider;
    [SerializeField] private Slider energySlider;
    [SerializeField] private Slider foodSlider;
    [SerializeField] private Image lampFilter;
    [SerializeField] private Image gameLobby;

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

    public void SetLampFilter()
    {
        if(lampFilter.isActiveAndEnabled)
        {
            lampFilter.gameObject.SetActive(false);
        }
        else
        {
            lampFilter.gameObject.SetActive(true);
        }
    }

    public void OffLampFilter()
    {
        if (lampFilter.isActiveAndEnabled)
        {
            lampFilter.gameObject.SetActive(false);
        }        
    }

    public void SetGameLobby()
    {
        if (gameLobby.isActiveAndEnabled)
        {
            gameLobby.gameObject.SetActive(false);
        }
        else
        {
            gameLobby.gameObject.SetActive(true);
        }
    }

    public void OffGameLobby()
    {
        if (gameLobby.isActiveAndEnabled)
        {
            gameLobby.gameObject.SetActive(false);
        }
    }

}
