using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CircleDragScript : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{

    public static Vector2 defaultposition;
    Vector2 currentPos;
    public Vector2 drop1Pos;
    public Vector2 drop2Pos;
    public Vector2 drop3Pos;
    public Vector2 drop4Pos;
    public Vector2 dropPos;
    public string curDropName;
    RightAnswer asdf;
    public Button btnNextMission;
    public Button btnTryAgain;
    public AudioSource fail;
    public AudioSource success;
    public GameObject effect;

    // Start is called before the first frame update
    void Start()
    {
        drop1Pos.x = 197;
        drop1Pos.y = 735;

        drop2Pos.x = 553;
        drop2Pos.y = 735;

        drop3Pos.x = 204;
        drop3Pos.y = 405;

        drop4Pos.x = 543;
        drop4Pos.y = 405;

        asdf = GameObject.Find("@Manager").GetComponent<RightAnswer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("currentPos XY : " + currentPos.x + "  " + currentPos.y);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // start drag
        defaultposition = this.transform.position;
        dropPos = defaultposition;
    }

    public void OnDrag(PointerEventData eventData)
    {
        // doing drag
        currentPos = Input.mousePosition;
        this.transform.position = currentPos;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // finish drag
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        this.transform.position = dropPos;

        switch(curDropName)
        {
            case "Drop1":
                asdf.drop1 = asdf.curDrag;
                break;
            case "Drop2":
                asdf.drop2 = asdf.curDrag;
                break;
            case "Drop3":
                asdf.drop3 = asdf.curDrag;
                break;
            case "Drop4":
                asdf.drop4 = asdf.curDrag;
                break;

        }

        if ((asdf.drop1 == "0") || (asdf.drop2 == "0") || (asdf.drop3 == "0") || (asdf.drop4 == "0"))
        {
            // not finish
        } else
        {
            // finish and time to check right answer
            if ((asdf.drop1 == "Drag3") && (asdf.drop2 == "Drag1") && (asdf.drop3 == "Drag4") && (asdf.drop4 == "Drag2") )
            {
                // right answer
                // sound
                // effect
                // button set active
                success.Play();
                //effect.gameObject.SetActive(true);
                btnNextMission.gameObject.SetActive(true);
            } else
            {
                // wrong answer
                // try again button
                fail.Play();
                btnTryAgain.gameObject.SetActive(true);
            }
        }

        Debug.Log("****" + asdf.drop1 + " " + asdf.drop2 + " " + asdf.drop3 +  " " + asdf.drop4);

        //this.transform.position = defaultposition;
    }


    private void OnTriggerEnter(Collider other)
    {
        string mTag = gameObject.tag;

        if (other.tag == "Drop1")
        {
            //Debug.Log("Drop1 OnTriggerEnter");
            dropPos = drop1Pos;
            curDropName = "Drop1";
            asdf.curDrag = mTag;
        }
        else if (other.tag == "Drop2")
        {
            //Debug.Log("Drop2 OnTriggerEnter");
            dropPos = drop2Pos;
            curDropName = "Drop2";
            asdf.curDrag = mTag;
        }
        else if (other.tag == "Drop3")
        {
            //Debug.Log("Drop3 OnTriggerEnter");
            dropPos = drop3Pos;
            curDropName = "Drop3";
            asdf.curDrag = mTag;
        }
        else if (other.tag == "Drop4")
        {
            //Debug.Log("Drop4 OnTriggerEnter");
            dropPos = drop4Pos;
            curDropName = "Drop4";
            asdf.curDrag = mTag;
        }
    }

}
