using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class randomBlink : MonoBehaviour
{
    public Sprite inidRed, indiGreen;
    public GameObject indicator;
    int loop = 0;
    public int speed = 20;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public bool passFail(float fChanceOfSuccess) {
 
    float fRand = Random.Range(0.0f,1.0f);
    if (fRand <= fChanceOfSuccess) 
      return true; 
    return false;
 }


    // Update is called once per frame
    void Update()
    {
        if(loop >= speed) {
            loop = 0;
            bool action = passFail(0.5f);
            if(action) {
                indicator.GetComponent<Image>().sprite = indiGreen;
            } else {
                 indicator.GetComponent<Image>().sprite = inidRed;
            }
        }
        loop++;
    }
}
