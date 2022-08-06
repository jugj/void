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

    float direction = 1;
    void Start(){
        lamp.color = Color.red;
    }

    void Update(){
        head.transform.localPosition += Vector3.down * Time.deltaTime * speed * direction;

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
        gameObject.SetActive(false);
    }
}
