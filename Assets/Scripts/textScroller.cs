using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class textScroller : MonoBehaviour
{
    public float speed = 1.2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * Time.deltaTime * speed, Space.World);
        if(Input.anyKey) {
            SceneManager.LoadScene("Scenes/MainMenu", LoadSceneMode.Single);
        }
    }
}
