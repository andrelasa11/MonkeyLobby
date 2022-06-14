using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController_IR : MonoBehaviour
{

    #region "Singleton"

    private static GameController_IR instance;

    public static GameController_IR Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject go = new GameObject("GameManager");
                go.AddComponent<GameController_IR>();
            }

            return instance;
        }
    }

    #endregion

    [Header("Configuration")]
    [SerializeField] private float initialGroundSpeed;
    [SerializeField] private float secondStageSpeed;
    [SerializeField] private float thirdStageSpeed;
    [SerializeField] private float timeToSecondStage;
    [SerializeField] private float timeToThirdStage;

    // Ground Properties
    [HideInInspector] public float groundSpeed;


    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        StartCoroutine(StageCoroutine());
    }

    private IEnumerator StageCoroutine()
    {
        groundSpeed = initialGroundSpeed;

        yield return new WaitForSeconds(timeToSecondStage);

        groundSpeed = secondStageSpeed;

        yield return new WaitForSeconds(timeToThirdStage);

        groundSpeed = thirdStageSpeed;
    }
    
}
