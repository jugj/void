using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Steering : MonoBehaviour{
    public GameObject steeringWheel;
    public Slider speedSlider;
    private float startAngle = 0;
    private float lastAngle = 0;

    public void onSpeedChange(){
        speedSlider.value = Mathf.Round(speedSlider.value);
        GameManagement.boat.direction = speedSlider.value;
    }
    
    public void onSteeringDown(){
        Vector2 dir = Input.mousePosition - steeringWheel.transform.position;
        startAngle = -Mathf.Sign(dir.x) * Vector2.Angle(Vector2.up, dir) - startAngle;
    }

    public void onSteeringTurn(){
        Vector2 dir = Input.mousePosition - steeringWheel.transform.position;

        float angle = -Mathf.Sign(dir.x) * Vector2.Angle(Vector2.up, dir) - startAngle;
        steeringWheel.transform.eulerAngles = new Vector3(0, 0, angle);

        GameManagement.boat.turn(lastAngle - angle);
        lastAngle = angle;
    }

    public void close(){
        gameObject.SetActive(false);
        GameManagement.player.activateMovement();
    }
}
