using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiContoller : MonoBehaviour
{
    public GameObject alertPanel;
    private RectTransform alertPanelRect;
    // Start is called before the first frame update
    void Start()
    {
        alertPanel.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if(alertPanel.activeSelf)
        {

        }    
    }
}
