using UnityEngine;
using UnityEngine.UI;

public class DistanceUI_HD : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private Text valueText;
    [SerializeField] private Text finalText;

    private void Start()
    {
        SetValueText();
    }

    public void SetValueText()
    {
        valueText.text = GameController_HD.Instance.distance.ToString("N2");
        finalText.text = GameController_HD.Instance.distance.ToString("N2");
    }
}
