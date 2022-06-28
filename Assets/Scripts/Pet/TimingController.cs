using UnityEngine;

public class TimingController : MonoBehaviour
{
    public float gameHourTimer;

    public float hourLength;

    private void Update()
    {
        if(gameHourTimer <= 0)
        {
            gameHourTimer = hourLength;
        }
        else
        {
            gameHourTimer -= Time.deltaTime;
        }
    }
}
