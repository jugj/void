using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Radar : MonoBehaviour{
    public float radarRadius = 100;
    public GameObject destPoint;
    public TMP_Text destPointText;

    void Update(){
        float angle = GameManagement.boat.destAngle;
        float distance = GameManagement.boat.destDistance;

        destPointText.text = ((int)distance).ToString();

        if(distance > radarRadius) distance = radarRadius;
        distance *= 110 / radarRadius;

        destPoint.transform.localPosition = new Vector3(Mathf.Sin(angle) * distance, Mathf.Cos(angle) * distance, 0);
    }
}
