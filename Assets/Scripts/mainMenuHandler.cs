using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenuHandler : MonoBehaviour
{
    public string sceneToLoad = "Scenes/Credits";

    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
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

}
