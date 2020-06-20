using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButonNextLevel : MonoBehaviour
{
    public void ClickNextLevel()
    {
        GameManager.Instance.NextLevel();
    }
}
