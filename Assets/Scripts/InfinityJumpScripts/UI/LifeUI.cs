using UnityEngine;
using UnityEngine.UI;

public class LifeUI : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private Text valueText;

    private void Start()
    {
        SetValueText();
    }

    public void SetValueText()
    {
        valueText.text = GameController_IJ.Instance.playerLives.ToString();
    }
}
