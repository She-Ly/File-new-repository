using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonCreditos : MonoBehaviour
{
    public GameObject panelCreditos;

    public void MostrarCreditos()
    {
        panelCreditos.SetActive(true);
    }

    public void OcultarCreditos()
    {
        panelCreditos.SetActive(false);
    }
}

