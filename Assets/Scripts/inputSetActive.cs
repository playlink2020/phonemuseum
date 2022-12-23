using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inputSetActive : MonoBehaviour
{
    public InputField mInput;
    public float time;

    // Start is called before the first frame update
    void Start()
    {
        mInput.gameObject.SetActive(false);
        StartCoroutine(WaitForIt());
    }

    IEnumerator WaitForIt()
    {
        yield return new WaitForSeconds(time);
        mInput.gameObject.SetActive(true);
    }
}
