using UnityEngine;
using UnityEngine.UI;

public class ScoreUI_HD : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private Text scoreValueText;
    [SerializeField] private Text finalScoreValueText;
    [SerializeField] private Text totalValueText;

    private void Start()
    {
        SetScoreValueText();
        SetTotalValueText();
    }

    public void SetScoreValueText()
    {
        scoreValueText.text = GameController_HD.Instance.score.ToString("N2");
    }

    public void SetTotalValueText()
    {
        finalScoreValueText.text = GameController_HD.Instance.score.ToString("N2");
        totalValueText.text = GameController_HD.Instance.totalScore.ToString("N2");
    }
}
