using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class uiController : MonoBehaviour {

    [SerializeField]
    Image sourceImage;

    [SerializeField]
    Sprite[] arrayOfuiElements;

    int activeSprite;
	
	// Update is called once per frame
	void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftBracket))
        {
            activeSprite--;
            UpdateUI();
        }


        if (Input.GetKeyDown(KeyCode.RightBracket))
        {
            activeSprite++;
            UpdateUI();
        }
	}

    void UpdateUI()
    {
        activeSprite = Mathf.Clamp(activeSprite, 0, arrayOfuiElements.Length - 1);

        // array of sprites is geordend op nummer (handmatig) 
        sourceImage.sprite = arrayOfuiElements[activeSprite];
    }
}
