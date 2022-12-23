using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rotationRate : MonoBehaviour
{
    // Start is called before the first frame update
    public Image imgI;
    public Image imgLove;
    public Image imgU;
    public AudioSource success;
    Vector2 startI = new Vector2(468, 756);
    Vector2 startU = new Vector2(151, 116);
    Vector2 destinationI = new Vector2(508, 756);
    Vector2 destinationU = new Vector2(181, 756);
    bool mFlag = true;
    public float speed = 0.1f;
    float fades = 0.0f;
    float time = 0;
    Color color;

    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        float y = Input.acceleration.y;
        //if (mFlag == true)
        if ( (y > 0.8) && (mFlag == true))
        {
            // success
            mFlag = false;
            imgI.transform.position =
            Vector2.MoveTowards(destinationI, startI, speed * Time.deltaTime);
            imgU.transform.position =
            Vector2.MoveTowards(destinationU, startU, speed * Time.deltaTime);
            success.Play();
            color = imgI.color;
            color.a = 0.0f;
            imgI.color = color;
            color = imgU.color;
            color.a = 0.0f;
            imgU.color = color;
            color = imgLove.color;
            color.a = 0.0f;
            imgLove.color = color;
            StartCoroutine(WaitForIt());
        }
        
        /*
        if (mFlag == true)
        {
            // success
            
            //Debug.Log("****Z1 : " + imgU.transform.position.z);
            mFlag = false;
            //imgU.transform.Translate(Vector3.right * Time.deltaTime);
            imgI.transform.position =
            Vector2.MoveTowards(destinationI, startI, 1);
            imgU.transform.position =
            Vector2.MoveTowards(destinationU, startU, 1);
            Debug.Log("****X1 : " + imgU.transform.position.x);
            Debug.Log("****Y1 : " + imgU.transform.position.y);
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
            color = imgI.color;
            color.a = fades;
            imgI.color = color;
            color = imgU.color;
            color.a = fades;
            imgU.color = color;
            color = imgLove.color;
            color.a = fades;
            imgLove.color = color;
            StartCoroutine(WaitForIt());
        }

    }
}
