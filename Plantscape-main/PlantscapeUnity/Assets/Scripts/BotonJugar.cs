using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class BotonJugar : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public Camera videoCamera;

    // Este m�todo se llama cuando el bot�n se hace clic
    public void OnClickJugar()
    {
        // Reproduce el video
        videoPlayer.Play();

        // Espera hasta que el video termine
        StartCoroutine(WaitForVideoToEnd());
    }

    IEnumerator WaitForVideoToEnd()
    {
        while (videoPlayer.isPlaying)
        {
            yield return null;
        }

        // Carga la escena "Plantscape" despu�s de que termine el video
        SceneManager.LoadScene("Plantscape");
    }
}



