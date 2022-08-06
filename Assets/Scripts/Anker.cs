using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Anker : MonoBehaviour{
    public GameObject steeringWheel, amountIndicator;
    public Text amountIndiText;
    private float startAngle = 0;
    private float lastAngle = 0;
    private float totalAngle = 0;
    public int turnsRequired = 10;
    private int turnsDone = 0;

    public void Start() {
        amountIndicator.GetComponent<TextMeshProUGUI>().text = turnsRequired.ToString();
    }
    
    public void onSteeringDown(){
        Vector2 dir = Input.mousePosition - steeringWheel.transform.position;
        startAngle = -Mathf.Sign(dir.x) * Vector2.Angle(Vector2.up, dir) - startAngle;
    }

    public void onSteeringTurn(){
        Vector2 dir = Input.mousePosition - steeringWheel.transform.position;

        float angle = -Mathf.Sign(dir.x) * Vector2.Angle(Vector2.up, dir) - startAngle;
        steeringWheel.transform.eulerAngles = new Vector3(0, 0, angle);
        
        totalAngle += Mathf.Abs(angle - lastAngle);
        turnsDone = (int) Mathf.Round((totalAngle / (2 * Mathf.PI))/ 114);

        lastAngle = angle;
       
        if(turnsDone >= turnsRequired){
            GameManagement.isAnkerDown = !GameManagement.isAnkerDown;
            totalAngle = 0;
            turnsDone = 0;
            amountIndicator.GetComponent<TextMeshProUGUI>().text = turnsRequired.ToString();
            close();
        } else {
            amountIndicator.GetComponent<TextMeshProUGUI>().text = (turnsRequired - turnsDone).ToString();
        }
    }

    public void close(){
        gameObject.SetActive(false);
        GameManagement.player.activateMovement();
    }
}
