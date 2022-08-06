using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class textAnimator : MonoBehaviour
{
    // Start is called before the first frame update
    public Color newColor;
    public float fadeTime = 0.1f; //maybe rename this to fadeSpeed
    public GameObject text1, text2, text3, text4, text5;
    public float delay = 2;

    private float timey = 0f;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        text1.GetComponent<Text>().color = Color.Lerp(text1.GetComponent<Text>().color, newColor, fadeTime * Time.deltaTime);
        if (timey > delay)
        {
            text2.GetComponent<Text>().color = Color.Lerp(text2.GetComponent<Text>().color, newColor, fadeTime * Time.deltaTime);
        }
        if (timey > delay * 2)
        {
            text3.GetComponent<Text>().color = Color.Lerp(text3.GetComponent<Text>().color, newColor, fadeTime * Time.deltaTime);
        }

        if (timey > delay * 3)
        {
            text4.GetComponent<Text>().color = Color.Lerp(text4.GetComponent<Text>().color, newColor, fadeTime * Time.deltaTime);
        }

        if (timey > delay * 4)
        {
            text5.GetComponent<Text>().color = Color.Lerp(text5.GetComponent<Text>().color, newColor, fadeTime * Time.deltaTime);
        }

        if(timey > delay) {
            if(Input.GetKeyDown(KeyCode.Space)) {
                Debug.Log("Next scene");
                SceneManager.LoadScene("Scenes/Boat", LoadSceneMode.Single);
            }
        }
        timey += (float)Time.deltaTime;
    }

}
