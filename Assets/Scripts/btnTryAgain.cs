using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class btnTryAgain : MonoBehaviour
{
    public string strCurScene;
    public void btnClickedTryAgain()
    {
        SceneManager.LoadScene(strCurScene);
    }
}
