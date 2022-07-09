using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private Text scoreValueText;
    [SerializeField] private Text finalScoreValueText;
    [SerializeField] private Text totalValueText;
    [SerializeField] private Text recordValueText;

    private void Start()
    {
        SetScoreValueText();
        SetTotalValueText();
    }

    public void SetScoreValueText()
    {
        scoreValueText.text = GameController_IJ.Instance.score.ToString();
        recordValueText.text = GameManager.Instance.infinityJumpRecord.ToString();
    }

    public void SetTotalValueText()
    {
        finalScoreValueText.text = GameController_IJ.Instance.score.ToString();
        totalValueText.text = GameController_IJ.Instance.totalScore.ToString();
        recordValueText.text = GameManager.Instance.infinityJumpRecord.ToString();
    }
}
