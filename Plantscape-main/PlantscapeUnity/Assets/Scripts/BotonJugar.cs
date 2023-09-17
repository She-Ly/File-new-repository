using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonJugar : MonoBehaviour
{
    // Este método se llama cuando el botón se hace clic
    public void OnClickJugar()
    {
        // Carga la escena "Plantscape" (reemplaza con el nombre de tu escena)
        SceneManager.LoadScene("Plantscape");
    }
}


