using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonSalir : MonoBehaviour
{
    public void SalirDelJuego()
    {
        // Cierra la aplicaci�n en una compilaci�n standalone para PC
        UnityEngine.Application.Quit();
    }
}


