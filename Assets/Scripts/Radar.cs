using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Radar : MonoBehaviour{
    public float radarRadius = 100;
    public GameObject destPoint;
    public List<GameObject> rockPoints;
    public TMP_Text destPointText;
    public GameObject rockPointPrefab;
    public GameObject circle;
    public AudioSource audioData;

    void Start(){
        rockPoints = new List<GameObject>();
        audioData = GetComponent<AudioSource>();
    }

    void Update(){
        // audioData.Play();
        circle.transform.localScale = new Vector3(1, 1, 0) * GameManagement.boat.boatRadius / 110 * radarRadius * 2;
        float angle = GameManagement.boat.destAngle;
        float distance = GameManagement.boat.destDistance;

        destPointText.text = ((int)distance).ToString();

        if(distance > radarRadius) distance = radarRadius;
        distance *= 110 / radarRadius;

        destPoint.transform.localPosition = new Vector3(Mathf.Sin(angle), Mathf.Cos(angle), 0) * distance;

        int i;
        for(i = 0; i < GameManagement.boat.rocks.Count; i++){
            GameObject rp;
            Vector3 rock = GameManagement.boat.rocks[i];
            angle = rock.y;

            distance = rock.x;
            if(distance > radarRadius) distance = radarRadius;
            distance *= 110 / radarRadius;

            if(i >= rockPoints.Count){
                rockPoints.Add(Instantiate(rockPointPrefab, transform));
            }
            rp = rockPoints[i];
            rp.transform.localPosition = new Vector3(Mathf.Sin(angle), Mathf.Cos(angle), 0) * distance;
        }
        
        for(; i < rockPoints.Count; i++){
            if(rockPoints[i] != null)
                Destroy(rockPoints[i]);
            rockPoints.RemoveAt(i);
        }
    }
}
