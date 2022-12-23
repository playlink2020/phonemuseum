using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class btnCheckAnswerM4 : MonoBehaviour
{
    public InputField mInput;
    public string[] rightAnswer;
    public AudioSource fail;
    public AudioSource success;
    public Image panel;
    float fades = 0f;
    float time = 0;
    public string strNextScene;
    bool mFlag = false;

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    public void btnCheckRight()
    {
        string mAnswer = mInput.text;
        mAnswer = mAnswer.Replace(" ", "").ToLower();

        switch (mAnswer)
        {
            case "iloveu":
                mFlag = true;
                break;
            case "iloveyou":
                mFlag = true;
                break;

        }

        //for (int i = 0; i < rightAnswer.Length; i++)
        //{
       
            if (mFlag == true)
            {
                // 맞췄다는 사운드
                success.Play();
                // 화면 전환
                StartCoroutine(WaitForIt());
                return;
            }
            else
            {
                // 틀렸다는 사운드
                fail.Play();
            }
            
        //}
        /*
        if (mAnswer == rightAnswer)
        {
            // 맞췄다는 사운드
            success.Play();
            // 화면 전환
            StartCoroutine(WaitForIt());

        }
        else
        {
            // 틀렸다는 사운드
            fail.Play();
        }
        */
    }

    IEnumerator WaitForIt()
    {
        yield return new WaitForSeconds(0.05f);
        if ((fades < 1.0f) && (time <= 2.0f))
        {
            fades += 0.05f;
            time += 0.05f;
            panel.color = new Color(0, 0, 0, fades);
            StartCoroutine(WaitForIt());
        }
        else
        {
            SceneManager.LoadScene(strNextScene);
        }

    }
}
