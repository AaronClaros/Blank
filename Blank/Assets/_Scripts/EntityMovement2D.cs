using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityMovement2D : MonoBehaviour {
	Vector2 vector_move;
	Rigidbody2D rb;
	public float move_speed = 10;
	public float max_speed = 10;
	public string axis_x_name = "Horizontal";
	public string axis_y_name = "Vertical";
	public bool fl_move_allowed = true;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		if (!rb)
			Debug.LogWarning (rb);
	}
	
	// Update is called once per frame
	void Update () { 
		
	}

	void FixedUpdate(){ 
		vector_move = new Vector3 (Input.GetAxis(axis_x_name) ,Input.GetAxis(axis_y_name));
		if (vector_move.x !=0){
			MoveAxisX();
		}

	}

	void MoveAxisX(){
		if (!rb)
			return;
		if (!fl_move_allowed)
			return;
		if (Mathf.Abs (rb.velocity.x) >= max_speed) {
			return;
		}
		print ("moving");
		rb.AddForce(((Vector2.right * vector_move.x)* move_speed) * Time.fixedDeltaTime, ForceMode2D.Impulse); 
	}
}
