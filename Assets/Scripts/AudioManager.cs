using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance {get; private set;}
    
    public AudioSource backgroundMusicSource;
    // public AudioSource playerSFXSource; - may be changed to be specifically clue finding sfx
    // public AudioSource worldSFXSource;

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

    public void PlayBackgroundMusic(AudioClip clip)
    {
        if (backgroundMusicSource.isPlaying)
        {
            backgroundMusicSource.Stop();
        }
        backgroundMusicSource.clip = clip;
        backgroundMusicSource.Play();
    }
    
    // public void PlayPlayerSFX(AudioClip clip)
        // playerSFXSource.PlayClueSound(clip); - for playing individual musical sting and/or pickup sound
}
