using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class BotonJugar : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public Camera videoCamera;

    // Este método se llama cuando el botón se hace clic
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

        // Carga la escena "Plantscape" después de que termine el video
        SceneManager.LoadScene("Plantscape");
    }
}



