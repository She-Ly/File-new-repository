using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonControles : MonoBehaviour
{
    public GameObject panelControles;

    public void MostrarControles()
    {
        panelControles.SetActive(true);
    }

    public void OcultarControles()
    {
        panelControles.SetActive(false);
    }
}

