using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class echoLotCtrl : MonoBehaviour
{

    public GameObject gameObjectLotIndicator, gameUpBtn, gameDownBtn, gameStopBtn, gameStone, errorIndicator;

    private bool isUpPressed, isDownPressed;

    public float speed = 2f;

    private float goalDepth;

    public bool wasSuccessful, goingUp = false;

    public Sprite inidRed, indiGreen;

    // Start is called before the first frame update
    void Start()
    {
        isUpPressed = false;
        isDownPressed = false;
        goalDepth = 220;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isUpPressed)
        {
            gameObjectLotIndicator.transform.Translate(Vector2.up * Time.deltaTime * speed, Space.World);
        }
        else if (isDownPressed)
        {
            gameObjectLotIndicator.transform.Translate(Vector2.down * Time.deltaTime * speed, Space.World);
        }

        if (gameObjectLotIndicator.transform.position[1] >= 338)
        {
            ButtonStop();
            goingUp = false;
        }
        if (Mathf.Abs(gameObjectLotIndicator.transform.position[1] - goalDepth) < 20)
        {
            if (gameObjectLotIndicator.transform.position[1] > 238 && gameObjectLotIndicator.transform.position[1] < 248)
            {
                wasSuccessful = true;
            }
        }

        if (gameObjectLotIndicator.transform.position[1] < 225)
        {
            wasSuccessful = false;
            ButtonStop();
            goingUp = true;

        }
        if (goingUp)
        {
            gameObjectLotIndicator.transform.Translate(Vector2.up * Time.deltaTime * 40, Space.World);
            errorIndicator.GetComponent<Image>().sprite = inidRed;
        } else {
            errorIndicator.GetComponent<Image>().sprite = indiGreen;
        }
        Debug.Log(gameObjectLotIndicator.transform.position);
    }

    public void ButtonUpPressed()
    {
        isUpPressed = true;
        isDownPressed = false;
    }

    public void ButtonDownPressed()
    {
        isUpPressed = false;
        isDownPressed = true;
    }

    public void ButtonStop()
    {
        isDownPressed = false;
        isUpPressed = false;
    }
}
