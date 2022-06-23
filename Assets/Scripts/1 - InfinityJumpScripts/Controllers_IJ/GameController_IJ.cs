using System.Collections;
using UnityEngine;

public class GameController_IJ : MonoBehaviour
{

    #region "Singleton"

    private static GameController_IJ instance;

    public static GameController_IJ Instance { get { return instance; } }

    #endregion

    [Header("Configuration")]
    [SerializeField] private float initialPlatformSpeed;
    [SerializeField] private float secondStageSpeed;
    [SerializeField] private float thirdStageSpeed;
    [SerializeField] private float timeToSecondStage;
    [SerializeField] private float timeToThirdStage;
    [SerializeField] private float respawnTime;
    [SerializeField] private float distancePerSecond;
    [SerializeField] private float playerGravity;

    [Header("Cadence Configuration")]
    [SerializeField] private float cadenceToDecrease;

    [Header("Data")]
    public int score;
    public float distance;
    public int playerLives;
    public float totalScore;

    [Header("Dependencies")]
    [SerializeField] private AutoScroller autoScroller;
    [SerializeField] private GameObject player;
    [SerializeField] private SpawnerController_IJ spawnerController;
    [SerializeField] private GameObject mainCanvas;
    [SerializeField] private GameObject gameOverCanvas;

    [Header("UI")]
    [SerializeField] private DistanceUI distanceUI;
    [SerializeField] private ScoreUI scoreUI;
    [SerializeField] private LifeUI lifeUI;

    // Platform Properties
    [HideInInspector] public float platformSpeed;
    
    //private
    private Vector3 startPosition;
    private bool isDead = false;

    #region "Awake/Start/Update"

    private void Awake()
    {
        instance = this;
        score = 0;
        distance = 0;
        Time.timeScale = 1f;
    }

    private void Start()
    {
        mainCanvas.SetActive(true);
        gameOverCanvas.SetActive(false);
        isDead = false;
        player.GetComponent<Rigidbody2D>().gravityScale = playerGravity;
        StartCoroutine(StageCoroutine());
        startPosition = player.transform.position;
        StartCoroutine(DistanceCoroutine());
        StartCoroutine(RespawnPlayer());
    }

    #endregion

    #region "My Methods"

    public void SetScore(int scorePoints)
    {
        score += scorePoints;
        AudioManager.Instance.PlayCoin();
        scoreUI.SetScoreValueText();
    }

    public void SetPlayerLives(int value)
    {
        playerLives += value;
        lifeUI.SetValueText();

        if (playerLives <= 0)
        {             
            StopCoroutine(DistanceCoroutine());
            isDead = true;
            OnGameOver();
        }
        else
        {
            StartCoroutine(RespawnPlayer());
        }
    }

    public void OnGameOver()
    {
        Debug.Log("GameOver!");
        Time.timeScale = 0;
        totalScore = score + distance;
        scoreUI.SetTotalValueText();
        mainCanvas.SetActive(false);
        gameOverCanvas.SetActive(true);
    }

    #endregion

    #region "Coroutines"

    private IEnumerator StageCoroutine()
    {
        platformSpeed = initialPlatformSpeed;

        yield return new WaitForSeconds(timeToSecondStage);

        autoScroller.scrollSpeed *= 2;
        platformSpeed = secondStageSpeed;
        distancePerSecond += 1.5f;
        spawnerController.cadence -= cadenceToDecrease;

        yield return new WaitForSeconds(timeToThirdStage);

        autoScroller.scrollSpeed *= 1.5f;
        platformSpeed = thirdStageSpeed;
        distancePerSecond += 2.5f;
        spawnerController.cadence -= cadenceToDecrease;
    }

    private IEnumerator RespawnPlayer()
    {
        player.GetComponentInChildren<SpriteRenderer>().enabled = false;
        player.layer = 3;

        yield return new WaitForSeconds(respawnTime);

        player.transform.position = startPosition;
        player.GetComponent<Rigidbody2D>().gravityScale = 0;
        player.GetComponent<Rigidbody2D>().velocity = Vector3.zero;


        for (float i = 0; i < 3; i += 0.1f)
        {
            player.GetComponentInChildren<SpriteRenderer>().enabled = !player.GetComponentInChildren<SpriteRenderer>().enabled;
            yield return new WaitForSeconds(0.1f);
        }

        player.layer = 7;

        player.GetComponent<Rigidbody2D>().gravityScale = playerGravity;
        player.GetComponentInChildren<SpriteRenderer>().enabled = true;  
    }

    private IEnumerator DistanceCoroutine()
    {
        while(isDead == false)
        {
            distance += (distancePerSecond/2);

            distanceUI.SetValueText();

            yield return new WaitForSeconds(0.5f);
        }
    }

    #endregion

}