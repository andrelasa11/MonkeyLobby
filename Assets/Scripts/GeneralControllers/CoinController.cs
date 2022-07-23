using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{

    [Header("Configuration")]
    public int scorePoints;

    [Header("Dependencies")]
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private List<SOCoin> coinConfigs;

    [Header("Games")]
    [SerializeField] private bool infinityJump = false;
    [SerializeField] private bool hillDrive = false;

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
        if(infinityJump) GCInfinityJump.Instance.SetScore(scorePoints);
        if(hillDrive) GCHillDrive.Instance.SetScore(scorePoints);
    }

}