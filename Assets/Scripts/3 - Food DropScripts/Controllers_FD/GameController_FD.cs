using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController_FD : MonoBehaviour
{

    #region "Singleton"

    private static GameController_FD instance;

    public static GameController_FD Instance { get { return instance; } }

    #endregion


    [Header("Speed Configuration")]
    [SerializeField] private float initialFoodSpeed;
    [SerializeField] private float secondStageSpeed;
    [SerializeField] private float thirdStageSpeed;
    [SerializeField] private float timeToSecondStage;
    [SerializeField] private float timeToThirdStage;

    [Header("Cadence Configuration")]
    [SerializeField] private float cadenceToDecrease;

    [Header("Data")]
    public int score;
    public int maxLives;
    public int currentLife;

    [Header("Dependencies")]
    [SerializeField] private SpawnerController_IJ spawnerController;

    // Food Properties
    [HideInInspector] public float foodSpeed;

    private void Awake()
    {
        instance = this;
        score = 0;
        Time.timeScale = 1f;
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StageCoroutine());
        currentLife = maxLives;
    }

    #region "My Methods"

    public void SetScore(int scorePoints)
    {
        score += scorePoints;
        //scoreUI.SetScoreValueText();
    }

    public void SetPlayerLives(int value)
    {
        currentLife += value;
        //lifeUI.SetValueText();

        if (currentLife <= 0)
        {            
            //OnGameOver();
        }
    }

    #endregion

    #region "Coroutines"

    private IEnumerator StageCoroutine()
    {
        foodSpeed = initialFoodSpeed;

        yield return new WaitForSeconds(timeToSecondStage);

        foodSpeed = secondStageSpeed;
        spawnerController.cadence -= cadenceToDecrease;

        yield return new WaitForSeconds(timeToThirdStage);

        foodSpeed = thirdStageSpeed;
        spawnerController.cadence -= cadenceToDecrease;
    }

    #endregion

}
