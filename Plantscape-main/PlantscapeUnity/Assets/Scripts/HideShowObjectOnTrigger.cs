using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideShowObjectOnTrigger : MonoBehaviour
{
    public GameObject objectToHideShow;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            objectToHideShow.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            objectToHideShow.SetActive(true);
        }
    }
}
