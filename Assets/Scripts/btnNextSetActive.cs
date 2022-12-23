using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class btnNextSetActive : MonoBehaviour
{
    public Button btnNext;
    public float time;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("***** btnNext Start");
        btnNext.gameObject.SetActive(false);
        StartCoroutine(WaitForIt());
    }

    IEnumerator WaitForIt()
    {
        yield return new WaitForSeconds(time);

        btnNext.gameObject.SetActive(true);
        Debug.Log("***** btnNext");
    }
}
