using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance {get; private set;}
    
    public AudioSource backgroundMusicSource;
    public AudioClip caseFileClip;
    public AudioClip keyClip;
    public AudioClip screwdriverClip;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

    private void OnEnable()
    {
        PlayerInteraction.OnFileFound += PlayCaseFileSFX;
        Collectable.OnKeyUsed +=  PlayKeySFX;
        Collectable.OnScrewdriverUsed += PlayScrewdriverSFX;
        Inventory.OnKeyPickup += PlayKeySFX;
    }

    private void OnDisable()
    {
        PlayerInteraction.OnFileFound -= PlayCaseFileSFX;
        Collectable.OnKeyUsed -= PlayKeySFX;
        Collectable.OnScrewdriverUsed -= PlayScrewdriverSFX;
        Inventory.OnKeyPickup -= PlayKeySFX;
    }

    public void PlayBackgroundMusic(AudioClip clip)
    {
        if (backgroundMusicSource.isPlaying)
        {
            backgroundMusicSource.Stop();
        }
        backgroundMusicSource.clip = clip;
        backgroundMusicSource.Play();
    }

    public void PlayCaseFileSFX()
    {
        backgroundMusicSource.clip = caseFileClip;
        backgroundMusicSource.Play();
    }

    private void PlayKeySFX()
    {
        backgroundMusicSource.clip = keyClip;
        backgroundMusicSource.Play();
    }

    private void PlayScrewdriverSFX()
    {
        backgroundMusicSource.clip = screwdriverClip;
        backgroundMusicSource.Play();
    }
}
