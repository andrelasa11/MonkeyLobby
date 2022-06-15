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
    [SerializeField] private float spawnTime;

    [Header("Data")]
    public int score;
    public float distance;
    public int playerLives;

    [Header("Dependencies")]
    [SerializeField] private AutoScroller autoScroller;
    [SerializeField] private GameObject player;

    // Ground Properties
    [HideInInspector] public float groundSpeed;

    //private
    private Vector3 startPosition;

    #region "Awake/Start/Update"

    private void Awake()
    {
        instance = this;
        score = 0;
        distance = 0;
    }

    private void Start()
    {
        StartCoroutine(StageCoroutine());
        startPosition = player.transform.position;
    }

    #endregion

    #region "My Methods"

    public void SetScore(int scorePoints)
    {
        score += scorePoints;
    }

    public void SetPlayerLives(int value)
    {
        playerLives += value;

        if(playerLives <= 0)
        {
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
    }

    #endregion

    #region "Coroutines"

    private IEnumerator StageCoroutine()
    {
        groundSpeed = initialPlatformSpeed;

        yield return new WaitForSeconds(timeToSecondStage);

        autoScroller.scrollSpeed *= 2;
        groundSpeed = secondStageSpeed;

        yield return new WaitForSeconds(timeToThirdStage);

        autoScroller.scrollSpeed *= 1.5f;
        groundSpeed = thirdStageSpeed;
    }

    private IEnumerator RespawnPlayer()
    {
        player.GetComponentInChildren<SpriteRenderer>().enabled = false;
        player.layer = 3;

        yield return new WaitForSeconds(spawnTime);

        player.transform.position = startPosition;
        player.GetComponent<Rigidbody2D>().gravityScale = 0;
        player.GetComponent<Rigidbody2D>().velocity = Vector3.zero;


        for (float i = 0; i < 3; i += 0.1f)
        {
            player.GetComponentInChildren<SpriteRenderer>().enabled = !player.GetComponentInChildren<SpriteRenderer>().enabled;
            yield return new WaitForSeconds(0.1f);
        }

        player.layer = 7;

        player.GetComponent<Rigidbody2D>().gravityScale = 1;
        player.GetComponentInChildren<SpriteRenderer>().enabled = true;  
    }

    #endregion

}