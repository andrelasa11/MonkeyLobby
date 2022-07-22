using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController_HD : MonoBehaviour
{

    #region "Singleton"

    private static GameController_HD instance;

    public static GameController_HD Instance { get { return instance; } }

    #endregion

    [Header("Fuel Configuration")]
    public float fuel;
    public float fuelConsumption;

    [Header("Data")]
    public int score;
    public float distance;
    public float totalScore;

    [Header("Dependencies")]
    [SerializeField] private PlayerController_HD player;
    [SerializeField] private GameObject mainCanvas;
    [SerializeField] private GameObject gameOverCanvas;
    [SerializeField] private AudioSource audioSource;    

    [Header("UI")]
    [SerializeField] private DistanceUI_HD distanceUI;
    [SerializeField] private ScoreUI_HD scoreUI;
    public Image fuelUI;

    [SerializeField] private List<GameObject> startGrounds;

    //private
    private Vector3 distanceReferencePoint;
    private Vector3 startGenerationPosition;

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
        startGenerationPosition = new Vector3(this.transform.position.x, -7.5f, this.transform.position.z);
        mainCanvas.SetActive(true);
        gameOverCanvas.SetActive(false);
        distanceReferencePoint = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);

        GenerateStartGround();

        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }

    private void Update()
    {
        distance = Vector3.Distance(distanceReferencePoint, player.transform.position);
        distanceUI.SetValueText();
    }

    #endregion

    #region "My Methods"

    public void SetScore(int scorePoints)
    {
        score += scorePoints;
        AudioManager.Instance.PlayCoin();
        scoreUI.SetScoreValueText();
    }

    public void SetFuel(float value)
    {
        fuel += value;
        AudioManager.Instance.PlayFuel();

        if (fuel > 1)
        {
            fuel = 1;
        }
    }

    public void OnGameOver()
    {

        Debug.Log("GameOver!");
        audioSource.Stop();
        Time.timeScale = 0;
        totalScore = score + distance;

        DateTime now = DateTime.Now;

        GameManager.Instance.AddHappinessValue(15, now);

        if (totalScore > GameManager.Instance.hillDriveRecord)
        {
            GameManager.Instance.SetHillDriveRecord(totalScore);
        }

        scoreUI.SetTotalValueText();
        mainCanvas.SetActive(false);
        gameOverCanvas.SetActive(true);
    }

    public void NoFuelGameOver()
    {
        StartCoroutine(GameOverCoroutine());
    }

    #endregion

    #region "Coroutines"

    private IEnumerator GameOverCoroutine()
    {
        yield return new WaitForSeconds(2);
        OnGameOver();
    }

    #endregion

    public void GenerateStartGround()
    {        
        int startGroundIndex = UnityEngine.Random.Range(0, startGrounds.Count);
        Debug.Log("StartGroundIndex: " + startGroundIndex + " StartGrounds.Count: " + startGrounds.Count);
        Debug.Log(startGroundIndex);
        Instantiate(startGrounds[startGroundIndex], startGenerationPosition, Quaternion.identity);
    }

}
