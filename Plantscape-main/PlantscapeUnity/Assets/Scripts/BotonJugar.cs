using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonJugar : MonoBehaviour
{
    // Este m�todo se llama cuando el bot�n se hace clic
    public void OnClickJugar()
    {
        // Carga la escena "Plantscape" (reemplaza con el nombre de tu escena)
        SceneManager.LoadScene("Plantscape");
    }
}


