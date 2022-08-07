using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class DeathScreenHandler : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject points1, holes, backHome;
    void Start()
    {
        
        points1.GetComponent<TextMeshProUGUI>().text = GameManagement.score.ToString();
        // holes.GetComponent<TextMeshProUGUI>().text = GameManagement;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void handleBackButton() {
        SceneManager.LoadScene("Scenes/MainMenu", LoadSceneMode.Single);
    }
}
