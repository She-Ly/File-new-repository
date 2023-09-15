using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource soundEffectSource;
    public AudioSource musicSource;

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

    // Pausa la m�sica de fondo
    public void PauseMusic()
    {
        musicSource.Pause();
    }

    // Puedes agregar m�s funciones relacionadas con el manejo de m�sica y efectos de sonido aqu�

    // ...
}
