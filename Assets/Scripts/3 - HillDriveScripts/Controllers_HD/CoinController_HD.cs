using System.Collections.Generic;
using UnityEngine;

public class CoinController_HD : MonoBehaviour
{

    [Header("Configuration")]
    public int scorePoints;

    [Header("Dependencies")]
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private List<SOCoin_IJ> coinConfigs;

    //private
    private int coinConfigIndex;

    // Start is called before the first frame update
    void Start()
    {
        if (coinConfigs != null)
        {
            coinConfigIndex = Random.Range(0, coinConfigs.Count);

            spriteRenderer.sprite = coinConfigs[coinConfigIndex].sprite; // Instanciamento do SO;
            scorePoints = coinConfigs[coinConfigIndex].scorePoints; // Instanciamento do SO;
        }

    }

    public void AddScore()
    {
        GameController_HD.Instance.SetScore(scorePoints);
    }

}
