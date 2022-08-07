using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Info : MonoBehaviour{
    private static Info info;
    private static float stopDisplayTime = 0;
    void Start(){
        Info.info = this;
        gameObject.SetActive(false);
    }

    void Update(){
        if(Time.time >= stopDisplayTime){
            info.gameObject.SetActive(false);
        }
    }

    public static void showInfo(string text, float time = 2){
        info.gameObject.SetActive(true);
        info.GetComponent<TMP_Text>().text = text;
        stopDisplayTime = Time.time + time;
    }
}
