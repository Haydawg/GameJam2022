using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlidingUi : MonoBehaviour
{

    public Image topBar;
    public Image bottomBar;
    private RectTransform  rectTransform;
    private int slideSpeed = 350;
   
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        rectTransform = GetComponent<RectTransform>();
        topBar.fillAmount = 0;
        bottomBar.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
       if(gameObject.activeSelf)
        {
            MoveRect();
        }
    }
    
    void MoveRect()
    {
        Vector2 position = rectTransform.anchoredPosition;
        float fillTotal = 0.5f;
        if(bottomBar.fillAmount < fillTotal)
        {
            bottomBar.fillAmount += (1 * Time.deltaTime);
            topBar.fillAmount += (1 * Time.deltaTime);
        }
        
        if (position.x > -100 & position.x < 100)
        {
            slideSpeed = 100;
        }
        else
        {
            slideSpeed = 2500;
        }
        if (position.x > 300)
        {
            if (bottomBar.fillAmount > 0)
            {
                bottomBar.fillAmount -= (2 * Time.deltaTime);
                topBar.fillAmount -= (2 * Time.deltaTime);
            }
        }
        position.x += slideSpeed * Time.deltaTime;
        if (position.x > 600)
            position.x = -600;

        rectTransform.anchoredPosition = position;
        if(position.x == -600)
        {

            gameObject.SetActive(false);
        }

    }
}
