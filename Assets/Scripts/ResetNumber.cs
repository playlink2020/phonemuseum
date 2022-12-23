using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResetNumber : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip[] sound;
    public Text t;
    public string strNextScene;

    public Image panel;
    float fades = 0f;
    float time = 0;

    // Start is called before the first frame update
    void Start()
    {
    }

    public void btnResetBtn()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Stop();

        if (t.text == "01189600900")
        {
            audioSource.clip = sound[0];
            audioSource.loop = true;
            StartCoroutine(WaitForIt());
        }
        else
        {
            audioSource.clip = sound[1];
            t.text = "";
        }
        audioSource.Play();
    }


    IEnumerator WaitForIt()
    {
        yield return new WaitForSeconds(6f);
        audioSource.Stop();
        panel.gameObject.SetActive(true);
        StartCoroutine(WaitForEnd());
    }

    IEnumerator WaitForEnd()
    {
        yield return new WaitForSeconds(0.05f);
        if ((fades < 1.0f) && (time <= 2.0f))
        {
            fades += 0.05f;
            time += 0.05f;
            panel.color = new Color(0, 0, 0, fades);
            StartCoroutine(WaitForEnd());
        }
        else
        {
            SceneManager.LoadScene(strNextScene);
        }

    }


}
