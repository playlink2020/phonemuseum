using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasyDragAndDrop.Core;

public class DropSlotMove : MonoBehaviour
{
    public Transform target;
    public Camera cam;
    public DragObj2D targetObj;
    public bool isEnd;

    void Update()
    {
        Vector2 screenPos = cam.WorldToScreenPoint(target.position);
        gameObject.transform.position = screenPos;
        if (target.gameObject.activeSelf)
        {
            gameObject.transform.localScale = Vector3.one;
        }
        else
        {
            gameObject.transform.localScale = Vector3.zero;
        }

        if(transform.GetChild(0).name == targetObj.name && !isEnd)
        {
            isEnd = true;
        }
    }
}
