using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using EasyDragAndDrop.Core;
using Fungus;

public class ARoomGameManager : MonoBehaviour
{
    public DragObj2D[] do2;
    public bool[] isDrop;

    public DropSlotMove[] dsm;

    public Flowchart fc;

    private void Update()
    {
        for(int i = 0; i < do2.Length; i++)
        {
            if (!do2[i].isReturnPosition && !isDrop[i])
            {
                isDrop[i] = true;

                do2[i].transform.DOScale(0, 1f);
            }
        }

        if (isDrop[0] && isDrop[1])
        {
            if (dsm[0].isEnd && dsm[1].isEnd)
            {
                fc.ExecuteBlock("End");
            }
            else
            {
                fc.ExecuteBlock("Fail");
            }
        }

    }
}
