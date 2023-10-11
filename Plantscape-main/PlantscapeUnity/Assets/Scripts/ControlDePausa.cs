using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlDePausa : MonoBehaviour
{
    public GameObject panelPausa;
    private bool juegoPausado = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (juegoPausado)
            {
                ReanudarJuego();
            }
            else
            {
                PausarJuego();
            }
        }
    }

    public void PausarJuego()
    {
        Time.timeScale = 0f; // Pausar el tiempo
        panelPausa.SetActive(true);
        juegoPausado = true;
    }

    public void ReanudarJuego()
    {
        Time.timeScale = 1f; // Reanudar el tiempo
        panelPausa.SetActive(false);
        juegoPausado = false;
    }

    public void Reiniciar(int idscene)
    {
        SceneManager.LoadScene(idscene);
    }
}


