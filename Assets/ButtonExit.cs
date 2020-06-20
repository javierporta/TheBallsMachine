using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonExit : MonoBehaviour
{
    public void OnClickExitButton()
    {
        GameManager.Instance.Exit();
    }
}
