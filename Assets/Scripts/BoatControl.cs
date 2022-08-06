using UnityEngine;

public class BoatControl : MonoBehaviour {
	public float speed = 15; // ca. 30 kn
	public float turnSpeed = 90; // degree

	public float minDestDistance = 750;
	public float maxDestDistance = 1500;
	
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
			return _destAngle;
		}
	}

	private void Start(){
		genNextDest();
		GameManagement.boat = this;
	}

	private void Update(){
		if(direction != 0){
			float c = Mathf.Cos(_destAngle) * _destDistance;
			float s = Mathf.Sin(_destAngle) * _destDistance;
			c -= Mathf.Sign(direction) * speed*Time.deltaTime;

			_destDistance = Mathf.Sqrt(c*c + s*s);
			_destAngle = Mathf.Atan(s/c);
		}
	}

	public void turn(float direction){ // positive for right, negative for left
		_destAngle -= Mathf.Sign(direction) * Mathf.Deg2Rad * turnSpeed;
	}

	public void genNextDest(){
		_destAngle = Random.value * 2 * Mathf.PI;
		_destDistance = Random.value * (maxDestDistance - minDestDistance) + minDestDistance;
	}
}