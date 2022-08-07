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

    public SpriteRenderer curtain;

    public Color newColor;
    private bool joinDone = false;
    public float fadeSpeed = 0.2f;
    public float transStay = 2;

    private bool trans = false;
    private int rounds = 0;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
        audioData = GetComponent<AudioSource>();
        volSlider.value = GameManagement.globalMusicVolume;
    }

    // Update is called once per frame
    void Update()
    {
        if(trans) {
            curtain.color = Color.Lerp(curtain.color, newColor, fadeSpeed * Time.deltaTime);
        }
    }

    public void doExitGame()
    {
        Application.Quit();
    }

    public void resetGameData()
    {
        GameManagement.score = 0;
        GameManagement.wholeHoleCount = 0;
        GameManagement.isAnkerDown = false;

    }

    public void loadSceneWithFixedDelay(string sceneToLoad) {
        loadScene(sceneToLoad, transStay);
    }
    public void loadScene(string sceneToLoad, float delay)
    {
        Debug.Log("Loading scene after delay"); 
        StartCoroutine(loadSceneAfterWait(sceneToLoad, delay));
    }

    IEnumerator loadSceneAfterWait(string sceneToLoad, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneToLoad, LoadSceneMode.Single);
    }

    public void transitionOut()
    {
        Debug.Log("TRANSITION");
        curtain.color = Color.Lerp(curtain.color, newColor, fadeSpeed * Time.deltaTime);
        trans = true;
    }

    public void SubmitSliderSetting()
    {
        //Displays the value of the slider in the console.
        audioData.volume = volSlider.value;
        GameManagement.globalMusicVolume = volSlider.value;
        //Debug.Log(volSlider.value);
    }

}
