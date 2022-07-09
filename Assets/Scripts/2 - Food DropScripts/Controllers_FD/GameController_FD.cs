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
    public int playerLife;

    [Header("Dependencies")]
    [SerializeField] private SpawnerController_IJ spawnerController;
    [SerializeField] private ScoreUI_FD scoreUI;
    [SerializeField] private LifeUI_FD lifeUI;
    [SerializeField] private GameObject mainCanvas;
    [SerializeField] private GameObject gameOverCanvas;
    public AudioClip foodDropMusic;

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

        AudioManager.Instance.PlayBgFoodDrop();
    }

    #region "My Methods"

    public void SetScore(int scorePoints)
    {
        score += scorePoints;        
        scoreUI.SetScoreValueText();

        if(scorePoints > 0)
        {
            AudioManager.Instance.PlayEating();
        }
    }

    public void SetPlayerLives(int value)
    {
        playerLife += value;
        AudioManager.Instance.PlayFailure();
        lifeUI.SetValueText();

        if (playerLife <= 0)
        {            
            OnGameOver();
        }
    }

    public void OnGameOver()
    {
        Debug.Log("GameOver!");
        AudioManager.Instance.PlayDeath();
        Time.timeScale = 0;

        if(score > GameManager.Instance.foodDropRecord)
        {
            GameManager.Instance.SetFoodDropRecord(score);
        }

        scoreUI.SetScoreValueText();

        mainCanvas.SetActive(false);
        gameOverCanvas.SetActive(true);
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
