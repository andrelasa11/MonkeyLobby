using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController_HD : MonoBehaviour
{

    #region "Singleton"

    private static GameController_HD instance;

    public static GameController_HD Instance { get { return instance; } }

    #endregion

    [Header("Data")]
    public int score;
    public float distance;
    public float totalScore;

    [Header("Dependencies")]
    [SerializeField] private PlayerController_HD player;

    [Header("UI")]
    [SerializeField] private DistanceUI_HD distanceUI;
    [SerializeField] private ScoreUI_HD scoreUI;

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

    //Gameover inicia um loop: enquanto rigidbody2d.velocity.x != 0, nada acontece. Quando chegar a 0 = ativa o canvas do gameover.
    

    #endregion

}
