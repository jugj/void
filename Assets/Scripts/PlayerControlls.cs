using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlls : MonoBehaviour{
    public float speed = 4;
    public SpriteRenderer spriteRenderer;
    void Start(){
        GameManagement.player = this;
    }

    void Update(){
        Vector3 movement = Vector3.zero;
        if(Input.GetKey("w")){
            movement.y = 1;
        }
        else if(Input.GetKey("s")){
            movement.y = -1;
        }

        if(Input.GetKey("a")){
            movement.x = -1;
            spriteRenderer.flipX = true;

        }
        else if(Input.GetKey("d")){
            movement.x = 1;
            spriteRenderer.flipX = false;
        }

        movement.Normalize();
        transform.localPosition += movement * speed * Time.deltaTime;
    }
}
