using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource soundEffectSource;
    public AudioSource musicSource;

    // Agrega un campo para tu música de fondo en el Inspector
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
        // Reproduce la música de fondo en bucle si no hay otra música en reproducción
        if (backgroundMusic != null && !musicSource.isPlaying)
        {
            PlayBackgroundMusic();
        }
    }

    public void PlaySoundEffect(AudioClip clip)
    {
        soundEffectSource.PlayOneShot(clip);
    }

    public void PlayBackgroundMusic()
    {
        if (backgroundMusic != null)
        {
            musicSource.clip = backgroundMusic;
            musicSource.loop = true;
            musicSource.Play();
        }
    }
    public void PlayMusic(AudioClip music)
    {
        musicSource.clip = music;
        musicSource.Play();
    }

    // Pausa la música de fondo
    public void PauseMusic()
    {
        musicSource.Pause();
    }

    // Puedes agregar más funciones relacionadas con el manejo de música y efectos de sonido aquí

    // ...
}
