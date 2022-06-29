using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CountdownController : MonoBehaviour
{
    [SerializeField] private Text countdownText;

    [SerializeField] private GameObject lobby3;

    [SerializeField] private GameObject lobby1;

    private int countdown = 6;

    private bool countdownOn = true;

    public void StartCountdown()
    {        
        countdownOn = true;
        StartCoroutine(CountdownCoroutine());
    }

    public void ExitCountdown()
    {
        countdownOn = false;
        countdown = 6;
        lobby3.SetActive(false);
        lobby1.SetActive(true);
    }

    public void PlayClickSound()
    {
        AudioManager.Instance.PlaySelect();
    }

    public IEnumerator CountdownCoroutine()
    {
        Debug.Log("Iniciou a corrotina");

        while (countdownOn)
        {
            Debug.Log("Entrou no while");

            countdown--;

            countdownText.text = countdown.ToString();
                        

            if (countdown <= 0)
            {
                ExitCountdown();

            }

            yield return new WaitForSeconds(1);

        }

    }
}
