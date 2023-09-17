using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticDoor : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Equals("Player"))

        {
            animator.Play("OpenDoor");
            Debug.Log("Entro player");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name.Equals("Player"))

        {
            animator.Play("CloseDoor");
            //Debug.Log("Entro player");
        }
    }
}
