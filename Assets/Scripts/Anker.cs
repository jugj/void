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
        
        totalAngle += angle;
        Debug.Log(totalAngle);
        if(totalAngle > 2 * turnsRequired * Mathf.PI) {
            Debug.Log("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
        }
        lastAngle = angle;
        
    }
}
