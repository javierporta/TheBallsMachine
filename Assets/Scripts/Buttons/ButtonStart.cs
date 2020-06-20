using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonStart : MonoBehaviour
{
 public void ClickOnStartButton()
    {
        GameManager.Instance.StartGame();
    }
}
