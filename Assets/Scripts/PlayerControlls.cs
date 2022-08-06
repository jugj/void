using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlls : MonoBehaviour{
    public float speed = 4;
    public SpriteRenderer spriteRenderer;
    public AudioSource audioData;
    public AudioClip laufenS;
    public AudioClip dieS;
    public AudioClip hitS;

    private bool gotTape = false; 

    void Start()
    {
        GameManagement.player = this;
        audioData = GetComponent<AudioSource>();
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
        if(Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d")){
            if(!audioData.isPlaying)
                audioData.Play();
        }
        else if(Input.GetKeyUp("w") || Input.GetKeyUp("a") || Input.GetKeyUp("s") || Input.GetKeyUp("d")){
            audioData.Stop();
        }

        if(Input.GetKeyDown("space")){
            if(gotTape){
                
            }
            else{

            }
        }
        
        movement.Normalize();
        
        transform.localPosition += movement * speed * Time.deltaTime;
        
    }

    void disableMovement(){
        
    }
}
