using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController_IJ : MonoBehaviour
{

    [Header("Configuration")]
    public int scorePoints;

    public void AddScore()
    {
        GameController_IJ.Instance.SetScore(scorePoints);
    }


}
