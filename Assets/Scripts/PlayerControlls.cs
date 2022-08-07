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

    public float stationDistance = 0.5f;

	public GameObject steeringStation;
	public GameObject sonarStation;
	public GameObject anchorStation;
	public GameObject tapeStation;
    
	public GameObject steeringMenu;
	public GameObject sonarMenu;
	public GameObject anchorMenu;

    private Animator animator;
    private bool gotTape = false; 
    private bool canMove = true;

    float fixingDoneTime = -1;
    public float fixTime = 2;
    public float slowfixTime = 4; 

    void Start()
    {
        GameManagement.player = this;
        audioData = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    void Update(){
        if(canMove){
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
                
                if(gotTape)
                    animator.SetInteger("anim", 3);
                else
                    animator.SetInteger("anim", 1);
            }
            else if(Input.GetKeyUp("w") || Input.GetKeyUp("a") || Input.GetKeyUp("s") || Input.GetKeyUp("d")){
                audioData.Stop();

                if(gotTape)
                    animator.SetInteger("anim", 2);
                else
                    animator.SetInteger("anim", 0);
            }
            
            movement.Normalize();
            transform.localPosition += movement * speed * Time.deltaTime;

            if(Input.GetKeyDown("space")){
                if(gotTape){
                    for(int i = 0; i < GameManagement.boat.leaks.Count; i++){
                        if(Vector3.Distance(transform.position, GameManagement.boat.leaks[i]) < stationDistance){
                            Debug.Log("Fix");
                            fixingDoneTime = Time.time;
                            if(GameManagement.boat.direction == 0)
                                fixingDoneTime += fixTime;
                            else
                                fixingDoneTime += slowfixTime;

                            GameManagement.boat.leaks.RemoveAt(i);
                            canMove = false;
                            animator.SetInteger("anim", 4);
                            break;
                        }
                    }
                    Info.showInfo("Here is no leak to fix");
                }
                else{
                    if(Vector3.Distance(transform.position, steeringStation.transform.position) < stationDistance){
                        if(!GameManagement.isAnkerDown){
                            steeringMenu.SetActive(true);
                            canMove = false;
                        }
                        else{
                            Info.showInfo("Steering\nI need to crank the Anchor up");
                        }
                    }
                    else if(Vector3.Distance(transform.position, sonarStation.transform.position) < stationDistance){
                        if(GameManagement.isAnkerDown && GameManagement.boat.destDistance <= GameManagement.boat.boatRadius){
                            sonarMenu.SetActive(true);
                            canMove = false;
                        }
                        else{
                            if(GameManagement.isAnkerDown){
                                Info.showInfo("Sonar\nI am currently not at the destination");
                            }
                            else{
                                Info.showInfo("Sonar\nI need to let the Anchor down");
                            }
                        }
                    }
                    else if(Vector3.Distance(transform.position, anchorStation.transform.position) < stationDistance){
                        if(GameManagement.boat.direction == 0){
                            anchorMenu.SetActive(true);
                            canMove = false;
                        }
                        else{
                            Info.showInfo("Anchor\nI need to stop the boat");
                        }
                    }
                }
            }
        }
        else{
            if(fixingDoneTime > 0 && Time.time >= fixingDoneTime){
                fixingDoneTime = -1;
                canMove = true;

                animator.SetInteger("anim", 2);
            }
        }

        if(Vector3.Distance(transform.position, tapeStation.transform.position) < stationDistance){
            gotTape = !gotTape;
        }
    }

    public void activateMovement(){
        canMove = true;
    }
}
