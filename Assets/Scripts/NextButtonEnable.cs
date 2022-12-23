using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextButtonEnable : MonoBehaviour
{
    public Button btnNext;
    public bool isBtnEnable = true;
    
    // Start is called before the first frame update
    void Start()
    {
        
        //AudioSource audioSource = gameObject.AddComponent<AudioSource>();
        Debug.Log("*****" + "start");
        
        //btnNext.gameObject.SetActive(true);

    }

    private void Update()
    {
        Debug.Log("*****" + "update");
        if (isBtnEnable == true)
        {
            isBtnEnable = false;
            Debug.Log("*****" + "btn");
            btnNext.gameObject.SetActive(true);
        }
        
    }
}
