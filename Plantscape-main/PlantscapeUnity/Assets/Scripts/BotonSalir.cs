using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonSalir : MonoBehaviour
{
    public void SalirDelJuego()
    {
        // Cierra la aplicación en una compilación standalone para PC
        UnityEngine.Application.Quit();
    }
}


