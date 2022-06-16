using UnityEngine;
using UnityEngine.UI;

public class DistanceUI : MonoBehaviour
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
        valueText.text = GameController_IJ.Instance.distance.ToString();
        finalText.text = GameController_IJ.Instance.distance.ToString();
    }
}
