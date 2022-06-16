using System.Collections.Generic;
using UnityEngine;

public class InedibleController_FD : MonoBehaviour
{

    [Header("Configuration")]
    public int scoreToDecrease;

    [Header("Dependencies")]
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private List<SOInedible_FD> inedibleConfigs;

    //private
    private int inedibleConfigIndex;

    // Start is called before the first frame update
    void Start()
    {
        if (inedibleConfigs != null)
        {
            inedibleConfigIndex = Random.Range(0, inedibleConfigs.Count);

            spriteRenderer.sprite = inedibleConfigs[inedibleConfigIndex].sprite; // Instanciamento do SO;
            scoreToDecrease = inedibleConfigs[inedibleConfigIndex].scoreToDecrease; // Instanciamento do SO;
        }

    }

    public void DecreaseScore()
    {
        GameController_FD.Instance.SetScore(scoreToDecrease * -1);
    }

    public void DecreaseLife()
    {
        GameController_FD.Instance.SetPlayerLives(-1);
    }

}
