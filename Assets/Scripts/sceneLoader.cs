using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneLoader : MonoBehaviour
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

    void loadCredits() {
        SceneManager.LoadScene(sceneToLoad, LoadSceneMode.Single);
    }
}
