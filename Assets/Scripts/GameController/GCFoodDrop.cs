using System.Collections;
using UnityEngine;

public class GCFoodDrop : GameController
{

    #region "Singleton"

    private static GCFoodDrop instance;

    public static GCFoodDrop Instance { get { return instance; } }

    #endregion


    [Header("Food Speed Configuration")]
    [SerializeField] private float initialFoodSpeed;
    [SerializeField] private float secondStageSpeed;
    [SerializeField] private float thirdStageSpeed;
    [SerializeField] private float timeToSecondStage;
    [SerializeField] private float timeToThirdStage;

    [Header("Cadence Configuration")]
    [SerializeField] private float cadenceToDecrease;

    [Header("Exclusive Dependencies")]
    [SerializeField] private SpawnerController spawnerController;
    public AudioClip foodDropMusic;

    // Food Properties
    [HideInInspector] public float foodSpeed;

    private void Awake()
    {
        instance = this;
        score = 0;
        totalScore = 0;
        Time.timeScale = 1f;
    }

    // Start is called before the first frame update
    void Start()
    {            
        StartCoroutine(StageCoroutine());

        scoreUI.SetScoreValueText(score);

        lifeUI.SetValueText(playerLife);

        AudioManager.Instance.PlayBgFoodDrop();
    }

    #region "My Methods"

    public override void SetScore(int scorePoints)
    {
        score += scorePoints;        
        scoreUI.SetScoreValueText(score);

        if(scorePoints > 0)
        {
            AudioManager.Instance.PlayEating();
        }
    }

    public override void OnGameOver()
    {
        AudioManager.Instance.PlayDeath();
        totalScore = score;

        if (totalScore > GameManager.Instance.foodDropRecord)
        {
            GameManager.Instance.SetFoodDropRecord(totalScore);
        }

        base.OnGameOver();
        
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
