using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DialGame_DialRotate : MonoBehaviour
{
    public SteeringWheel sw;
    public bool isDrag;
    public float targetAngle;

    public int targetNumber;

    public Text t;
    private AudioSource audioSource;
    public AudioClip sound;

    public void BeginDrag()
    {
        sw.maxAngle = targetAngle;
        isDrag = true;
    }

    public void EndDrag()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Stop();
        audioSource.clip = sound;
        audioSource.Play();

        sw.maxAngle = 0;
        isDrag = false;

        if (sw.transform.eulerAngles.z <= 360 - targetAngle + 1 && sw.transform.eulerAngles.z >= 360 - targetAngle - 1)
        {
            Debug.Log("LOCK");
            Debug.Log(targetNumber);
            t.text += targetNumber;
        }

    }

    private void Update()
    {

    }
}
