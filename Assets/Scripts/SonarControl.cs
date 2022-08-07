using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SonarControl : MonoBehaviour{
    public GameObject head;
    public GameObject tail;
    public Image lamp;
    public float minNeededDepth = 95;
    public float maxDepth = 99;
    public float speed = 10;
    public AudioSource audioData;

    float direction = 1;
    void Start(){
        lamp.color = Color.red;
        audioData = GetComponent<AudioSource>();
    }

    void Update(){
        // audioData.Play();
        ((RectTransform)head.transform).anchoredPosition += Vector2.down * Time.deltaTime * speed * direction;

        Rect r = ((RectTransform)tail.transform).rect;
        ((RectTransform)tail.transform).sizeDelta = new Vector2(r.width, -((RectTransform)head.transform).anchoredPosition.y);

        if(((RectTransform)head.transform).anchoredPosition.y <= -maxDepth){
            direction = -1;
            lamp.color = Color.red;
        }

        if(direction == -1 && ((RectTransform)head.transform).anchoredPosition.y >= -10){
            direction = 1;
        }

        if(direction == 1 && ((RectTransform)head.transform).anchoredPosition.y <= -minNeededDepth){
            lamp.color = Color.green;
        }
    }

    public void stop(){
        if(direction == 1){
            if(((RectTransform)head.transform).anchoredPosition.y <= -minNeededDepth){
                Debug.Log("Done!");
                GameManagement.score++;
                GameManagement.boat.genNextDest();
                close();
            }
            else{
                direction = -1;
                lamp.color = Color.red;
            }
        }
    }

    public void close(){
        ((RectTransform)head.transform).anchoredPosition = Vector3.down * 10;
        Rect r = ((RectTransform)tail.transform).rect;
        ((RectTransform)tail.transform).sizeDelta = new Vector2(r.width, -((RectTransform)head.transform).anchoredPosition.y);

        gameObject.SetActive(false);
        GameManagement.player.activateMovement();
    }
}
