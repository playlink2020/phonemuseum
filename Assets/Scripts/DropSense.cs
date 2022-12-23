using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropSense : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Drag1")
        {
            //Debug.Log("Drag1 OnTriggerEnter");
        }
        else if (other.tag == "Drag2")
        {
            //Debug.Log("Drag2 OnTriggerEnter");
        }
        else if (other.tag == "Drag3")
        {
            //Debug.Log("Drag3 OnTriggerEnter");
        }
        else if (other.tag == "Drag4")
        {
            //Debug.Log("Drag4 OnTriggerEnter");
        }
    }


    /*
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.CompareTag("Drag1"))
        {
            Debug.Log("Drag1");
        }

        else if (collision.collider.gameObject.CompareTag("Drag2"))
        {
            Debug.Log("Drag2");
        }
        else if (collision.collider.gameObject.CompareTag("Drag3"))
        {
            Debug.Log("Drag3");
        }
        else if (collision.collider.gameObject.CompareTag("Drag4"))
        {
            Debug.Log("Drag4");
        }
    }
    */
}

