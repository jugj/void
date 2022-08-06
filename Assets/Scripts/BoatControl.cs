using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatControl : MonoBehaviour {
	public float speed = 15; // ca. 30 kn
	public float turnSpeed = 90; // degree

	public float minDestDistance = 750;
	public float maxDestDistance = 1500;

	public int maxHits = 5;
	public float maxRockDistance = 75;
	public float boatRadius = 10f;
	public float rockHitTime = 1.5f;
	public int maxRockCount = 7; //30 sec
	public float maxThrowDistance = 30; //30 sec
	private float nextThrowTime = 30; //30 sec
	public List<Vector3> rocks; // x distance, y angle, z moment of impact
	public List<Vector2> leaks; // between (-4, -2.5) and (4, 2.5)
	
	private float _destAngle;
	private float _destDistance;

	public float direction = 0; // positive for forward, negative for backward, 0 for standing

	public float destAngle {
		get {
			return _destAngle;
		}
	}
	public float destDistance {
		get {
			return _destDistance;
		}
	}

	private void Start(){
		genNextDest();
		GameManagement.boat = this;

		rocks = new List<Vector3>();
		leaks = new List<Vector2>();

		genNextThrowTime();
	}

	private void Update(){
		if(direction != 0){
			float c = Mathf.Cos(_destAngle) * _destDistance;
			float s = Mathf.Sin(_destAngle) * _destDistance;
			c -= Mathf.Sign(direction) * speed*Time.deltaTime;

			_destDistance = Mathf.Sqrt(c*c + s*s);
			_destAngle = Mathf.Atan(s/c);

			if(c < 0) _destAngle += Mathf.PI;
			
			for(int i = 0; i < rocks.Count; i++){
				c = Mathf.Cos(rocks[i].y) * rocks[i].x;
				s = Mathf.Sin(rocks[i].y) * rocks[i].x;
				c -= Mathf.Sign(direction) * speed*Time.deltaTime;

				rocks[i] = new Vector3(Mathf.Sqrt(c*c + s*s), Mathf.Atan(s/c), rocks[i].z);

				if(c < 0){
					rocks[i] = new Vector3(rocks[i].x, rocks[i].y + Mathf.PI, rocks[i].z);
				}
			}
		}

		for(int i = 0; i < rocks.Count; i++){
			if(rocks[i].z <= Time.time){
				if(rocks[i].x <= boatRadius){
					Debug.Log("Hit");
					genLeaks();
				}
				
				rocks.RemoveAt(i);
				i--;
			}
		}

		if(Time.time >= nextThrowTime){
			throwRocks((int)(Random.value * maxRockCount));
		}

		if(maxHits <= leaks.Count){
			Debug.Log("YOU ARE DEAD!");
		}
	}

	public void turn(float direction){ // positive for right, negative for left
		float turn = Mathf.Sign(direction) * Mathf.Deg2Rad * turnSpeed * Time.deltaTime;
		_destAngle -= turn;

		for(int i = 0; i < rocks.Count; i++){
			rocks[i] = new Vector3(rocks[i].x, rocks[i].y - turn, rocks[i].z);
		}
	}

	public void genNextDest(){
		_destAngle = Random.value * 2 * Mathf.PI;
		_destDistance = Random.value * (maxDestDistance - minDestDistance) + minDestDistance;
	}

	public void throwRocks(int count){
		for(int i = 0; i < count; i++){
			rocks.Add(new Vector3(
				Random.value * maxRockDistance,
				Random.value * 2 * Mathf.PI,
				Time.time + rockHitTime
			));
		}
		genNextThrowTime();
	}

	void genLeaks(){
		leaks.Add(new Vector2(Random.value * 8 - 4, Random.value * 5 - 2.5f));
	}

	void genNextThrowTime(){
		nextThrowTime = Random.value * maxThrowDistance + Time.time;

		// Debug.Log(nextThrowTime);
	}
}