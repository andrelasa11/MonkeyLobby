using UnityEngine;
using UnityEngine.UI;

public class ScoreUI_FD : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private Text scoreValueText;
    [SerializeField] private Text finalScoreValueText;

    private void Start()
    {
        SetScoreValueText();
    }

    public void SetScoreValueText()
    {
        scoreValueText.text = GameController_FD.Instance.score.ToString();
        finalScoreValueText.text = GameController_FD.Instance.score.ToString();
    }
        
}
