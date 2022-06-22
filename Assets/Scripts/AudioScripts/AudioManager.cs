using UnityEngine;

public class AudioManager : MonoBehaviour
{
    #region "Singleton"

    private static AudioManager instance;

    public static AudioManager Instance { get { return instance; } }

    #endregion

    [Header("Lobby")]
    public AudioClip select;

    [Header("InfinityJump")]
    public AudioClip jumping;

    [Header("FoodDrop")]
    public AudioClip eating;
    public AudioClip failure;

    [Header("HillDrive")]
    public AudioClip fuel;

    [Header("Generals")]
    public AudioClip coin;
    public AudioClip death;

    [Header("Dependencies")]
    [SerializeField] private AudioSource audioSource;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }        
    }

    private void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }

    #region "Lobby Methods"

    public void PlaySelect()
    {
        PlaySound(select);
    }

    #endregion

    #region "Infinity Jump Methods"

    public void PlayJump()
    {
        PlaySound(jumping);
    }

    #endregion

    #region "Food Drop Methods"

    public void PlayEating()
    {
        PlaySound(eating);
    }

    public void PlayFailure()
    {
        PlaySound(failure);
    }

    #endregion

    #region "Hill Drive Methods"

    public void PlayFuel()
    {
        PlaySound(fuel);
    }

    #endregion

    #region "Generals"

    public void PlayCoin()
    {
        PlaySound(coin);
    }

    public void PlayDeath()
    {
        PlaySound(death);
    }

    #endregion
}
