using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HintPopupSetVisible : MonoBehaviour
{
    public GameObject hintPopup;

    public void btnSetVisible()
    {
        hintPopup.gameObject.SetActive(true);
    }

    public void btnSetInvisible()
    {
        hintPopup.gameObject.SetActive(false);
    }
}
