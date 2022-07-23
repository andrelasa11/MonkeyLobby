using UnityEngine;
using UnityEngine.UI;

public class LifeUI : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private Text valueText;

    private void Start()
    {
        
    }

    public void SetValueText(int playerLife)
    {
        valueText.text = playerLife.ToString();
    }
}
