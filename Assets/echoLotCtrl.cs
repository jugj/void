using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class echoLotCtrl : MonoBehaviour
{

    public GameObject gameObjectBtnUp;
    public GameObject gameObjectBtnDown;
    public GameObject gameObjectLotIndicator;

    private bool isUpPressed;

    // Start is called before the first frame update
    void Start()
    {
        isUpPressed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isUpPressed) {
            gameObjectLotIndicator.transform.Translate(Vector2.up * Time.deltaTime, Space.World);
        
        }
    }

    public void ButtonUpPressed() {
        isUpPressed = true;
    }

    public void ButtonUpUnPressed() {
        isUpPressed = false;
    }
}
