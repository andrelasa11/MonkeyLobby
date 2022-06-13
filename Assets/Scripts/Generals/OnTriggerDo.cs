using UnityEngine;
using UnityEngine.Events;

public class OnTriggerDo : MonoBehaviour
{
    [SerializeField] private UnityEvent onTriggerEnterDo;
    [SerializeField] private UnityEvent onTriggerExitDo;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            onTriggerEnterDo.Invoke();
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            onTriggerExitDo.Invoke();
        }
    }
}