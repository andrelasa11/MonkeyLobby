using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController_FD : MonoBehaviour
{

    #region "Singleton"

    private static GameController_FD instance;

    public static GameController_FD Instance { get { return instance; } }

    #endregion

    [Header("Configuration")]
    public float foodSpeed;

    [Header("Data")]
    public int score;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    #region "My Methods"

    public void SetScore(int scorePoints)
    {
        score += scorePoints;
        //scoreUI.SetScoreValueText();
    }

    #endregion

}
