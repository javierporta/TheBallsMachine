using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VirutalControls : MonoBehaviour
{
    [SerializeField]
    private GameObject virtualControl;

    [SerializeField]
    private GameObject throwButton;

    public static VirutalControls Instance { get; private set; } = null;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ShowVirtualControl(bool hasToShowVirtualControl)
    {
        virtualControl.SetActive(hasToShowVirtualControl);
        throwButton.GetComponent<Image>().enabled = hasToShowVirtualControl;
    }
}
