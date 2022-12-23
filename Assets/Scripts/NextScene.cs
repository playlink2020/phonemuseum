using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextScene : MonoBehaviour
{
    public string strNextScene;
    public Image panel;
    float fades = 0f;
    float time = 0;
    
    public void btnNextScene()
    {
        Debug.Log("**** btnNextScene :");
        // fade out
        StartCoroutine(WaitForIt());
    }

    IEnumerator WaitForIt()
    {
        yield return new WaitForSeconds(0.05f);
        if( (fades < 1.0f) && (time <= 2.0f) )
        {
            fades += 0.05f;
            time += 0.05f;
            panel.color = new Color(0, 0, 0, fades);
            StartCoroutine(WaitForIt());
        } else
        {
            SceneManager.LoadScene(strNextScene);
        }
        
    }

    /*
    public void btnNextScene()
    {
        Debug.Log("**** btnNextScene :");

        SceneManager.LoadScene(strNextScene);
    }
    */
}
