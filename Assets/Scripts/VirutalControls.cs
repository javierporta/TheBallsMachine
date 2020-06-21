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

    private Image throwButtonImage;

    public static VirutalControls Instance { get; private set; } = null;

    private void Awake()
    {
        throwButtonImage = throwButton.GetComponent<Image>();
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
        throwButtonImage.enabled = hasToShowVirtualControl;
    }
}
