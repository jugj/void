using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steering : MonoBehaviour{
    public void onValueChange(float value){
        GameManagement.boat.direction = value;
    }
}
