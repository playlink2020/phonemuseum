using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class imgSetActive : MonoBehaviour
{
    //public SpriteRenderer imgObj;
    public float time;
    public GameObject mObj;
    //float fades = 0f;
    //Color newColor;

    Renderer r;
    // Start is called before the first frame update
    void Start()
    {
        mObj = GetComponent<GameObject>();
        //Renderer r = mObj.GetComponent<Renderer>();
        mObj.SetActive(false);
        StartCoroutine(WaitForIt());
    }
    /*
    IEnumerator WaitForIt()
    {
        yield return new WaitForSeconds(0.05f);
        if ((fades < 1.0f) && (time <= 2.0f))
        {
            fades += 0.05f;
            time += 0.05f;
            newColor.a = fades;
            r.material.color = newColor;
            StartCoroutine(WaitForIt());
        }

    }
    */

    
    IEnumerator WaitForIt()
    {
        yield return new WaitForSeconds(time);

        mObj.SetActive(true);

    }
    
}
