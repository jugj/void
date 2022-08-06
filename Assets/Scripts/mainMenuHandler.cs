using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class mainMenuHandler : MonoBehaviour
{
    public string sceneToLoad = "Scenes/Credits";

    public Slider volSlider;

    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;
    public AudioSource audioData;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
        audioData = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void doExitGame() {
        Application.Quit();
    }

    public void loadScene(string sceneToLoad) {
        SceneManager.LoadScene(sceneToLoad, LoadSceneMode.Single);
    }

    public void SubmitSliderSetting()
    {
        //Displays the value of the slider in the console.
        audioData.volume = volSlider.value;
        //Debug.Log(volSlider.value);
    }

}
