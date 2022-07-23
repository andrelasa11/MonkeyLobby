using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private Text scoreValueText;
    [SerializeField] private Text finalScoreValueText;
    [SerializeField] private Text totalValueText;
    [SerializeField] private Text recordValueText;

    [Header("Games")]
    [SerializeField] private bool infinityJump = false;
    [SerializeField] private bool foodDrop = false;
    [SerializeField] private bool hillDrive = false;

    public void SetScoreValueText(int scoreValue)
    {
        scoreValueText.text = scoreValue.ToString();
    }

    public void SetTotalValueText(int scoreValue, float totalScoreValue)
    {
        finalScoreValueText.text = scoreValue.ToString();
        totalValueText.text = totalScoreValue.ToString();

        if(infinityJump) recordValueText.text = GameManager.Instance.infinityJumpRecord.ToString();
        if(foodDrop) recordValueText.text = GameManager.Instance.foodDropRecord.ToString();
        if(hillDrive) recordValueText.text = GameManager.Instance.hillDriveRecord.ToString();
    }
}
