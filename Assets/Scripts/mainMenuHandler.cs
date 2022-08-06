using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenuHandler : MonoBehaviour
{
    public string sceneToLoad = "Scenes/Credits";
    // Start is called before the first frame update
    void Start()
    {
        
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
