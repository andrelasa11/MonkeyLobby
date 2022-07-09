using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region "Singleton"

    private static GameManager instance;

    public static GameManager Instance { get { return instance; } }

    #endregion

    [Header("Records")]
    public float infinityJumpRecord;
    public float foodDropRecord;
    public float hillDriveRecord;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

    }

    public void SetInfinityJumpRecord(float value)
    {
        infinityJumpRecord = value;
    }

    public void SetFoodDropRecord(float value)
    {
        foodDropRecord = value;
    }

    public void SetHillDriveRecord(float value)
    {
        hillDriveRecord = value;
    }
}
