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
    public Color newColor;
    public float fadeSpeed = 0.2f;
    public GameObject curtain;
    void Start()
    {
        
        points1.GetComponent<TextMeshProUGUI>().text = GameManagement.score.ToString();
        holes.GetComponent<TextMeshProUGUI>().text = GameManagement.wholeHoleCount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        curtain.GetComponent<Image>().color = Color.Lerp(curtain.GetComponent<Image>().color, newColor, fadeSpeed * Time.deltaTime);
        points1.GetComponent<TextMeshProUGUI>().text = GameManagement.score.ToString();
        holes.GetComponent<TextMeshProUGUI>().text = GameManagement.wholeHoleCount.ToString();
    }

    public void handleBackButton() {
        SceneManager.LoadScene("Scenes/MainMenu", LoadSceneMode.Single);
    }
}
