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

    [Header("UI")]
    [SerializeField] private DistanceUI_HD distanceUI;
    [SerializeField] private ScoreUI_HD scoreUI;
    public Image fuelUI;

    //private
    private Vector3 distanceReferencePoint;

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
        distanceReferencePoint = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
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
        scoreUI.SetScoreValueText();
    }

    public void SetFuel(float value)
    {
        fuel += value;

        if (fuel > 1)
        {
            fuel = 1;
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

}
