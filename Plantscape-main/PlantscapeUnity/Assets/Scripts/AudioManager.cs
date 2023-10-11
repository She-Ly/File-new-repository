using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource soundEffectSource;
    public AudioSource musicSource;
    private bool isMusicPlaying;


    // Agrega un campo para tu m�sica de fondo en el Inspector
    public AudioClip backgroundMusic;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Reproduce la m�sica de fondo en bucle si no hay otra m�sica en reproducci�n
        if (backgroundMusic != null && !musicSource.isPlaying)
        {
            PlayBackgroundMusic();
        }
    }

    public void PlaySoundEffect(AudioClip effect)
    {
        soundEffectSource.clip = effect;
        soundEffectSource.Play();
    }

    public void PlayBackgroundMusic()
    {
        if (backgroundMusic != null)
        {
            musicSource.clip = backgroundMusic;
            musicSource.loop = true;
            musicSource.Play();
            isMusicPlaying = true;

        }
    }
    public void PlayMusic(AudioClip music)
    {
        musicSource.Stop();
        if (music.name.Equals("setRoom"))
        {
            musicSource.loop = true;
        }
        else {
            musicSource.loop = false;
        }

        musicSource.clip = music;
        musicSource.Play();
        isMusicPlaying = true;

    }
    public void PlayBasemusic()
    {
        musicSource.clip = backgroundMusic;
        musicSource.loop = true;
        musicSource.Play();
        isMusicPlaying = true;

    }
    // Pausa la m�sica de fondo
    public void PauseMusic()
    {
        musicSource.Pause();
        isMusicPlaying = false;

    }
    public void StopMusic()
    {
        musicSource.Stop();
        isMusicPlaying = false;

    }

    public void PauseMusic(AudioClip _clip)
    {
        musicSource.clip = _clip;
        musicSource.Play();
        isMusicPlaying = false;

    }
    public bool IsMusicPlaying()
    {
        return isMusicPlaying;
    }
    public void ResumeMusic()
    {
        if (!isMusicPlaying)
        {
            musicSource.UnPause();
            isMusicPlaying = true;
        }
    }
}
    
