using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class Videoend : MonoBehaviour
{

    VideoPlayer video;
    public UnityEvent Videofinalizado;
    // Start is called before the first frame update
    void Start()
    {
        // Obtén la referencia al componente VideoPlayer en el RawImage
        video = GetComponentInChildren<VideoPlayer>();

        // Busca un componente AudioSource en toda la escena
        AudioSource audioSource = FindObjectOfType<AudioSource>();

        // Verifica si se encontró el componente AudioSource
        if (audioSource == null)
        {
            Debug.LogWarning("No se encontró el componente AudioSource en la escena.");
        }
        else
        {
            // Desactiva el componente AudioSource
            audioSource.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnEnable()
    {
        video = GetComponent<VideoPlayer>();
        StartCoroutine(RevisarFinal());
    }

    IEnumerator RevisarFinal()
    {

        yield return new WaitForSeconds(2f);
        yield return new WaitUntil(() => !video.isPlaying);
        //Videofinalizado.Invoke();
        SceneManager.LoadScene(1);
    }
}


