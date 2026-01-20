using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class ObjectInfoController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private TextMeshProUGUI descriptionText;

    [SerializeField] private GameObject panel;
    [SerializeField] private Image image;

    public void SetVisible(bool isVisible = true)
    {
        panel.SetActive(isVisible);
    }

    public void SetObjectInfo(SOObjectInfo info)
    {
        titleText.text = info.objectName;
        descriptionText.text = info.description;
        image.sprite = info.icon;
    }
}
