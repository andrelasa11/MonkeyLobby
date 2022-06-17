using UnityEngine;
using UnityEngine.UI;

public class LifeUI_FD : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private Text valueText;

    private void Start()
    {
        SetValueText();
    }

    public void SetValueText()
    {
        valueText.text = GameController_FD.Instance.playerLife.ToString();
    }
}