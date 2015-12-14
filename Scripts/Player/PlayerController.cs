using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed = 5f;
	public GameObject bullet;
	public float shootTime = 1f;
	public Transform rightBulletSpawnPoint;
	public Transform leftBulletSpawnPoint;
	public float range = 100f;
	public float jumpRate = 200f;
	public bool jumpAvailable = true;

	private Rigidbody body;
	private float lastShot;
//	private bool jumpAvailable = true;
	private Animator anim;
	private bool startedAnimation;
	

	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody> ();
		anim = GetComponent<Animator> ();
		
	}
	
	void FixedUpdate(){
		float h = Input.GetAxis ("Horizontal");
		Move (h);
		Animating (h);

		if (Input.GetButton ("Fire1") && Time.time >= lastShot + shootTime)
			Shoot ();


		if ((Input.GetKeyDown ("space") || Input.GetKeyDown(KeyCode.W)) && jumpAvailable)
			Jump ();

		Turn ();

	}


	void Shoot(){
		lastShot = Time.time;
		Instantiate (bullet, rightBulletSpawnPoint.position, rightBulletSpawnPoint.rotation);
		Instantiate (bullet, leftBulletSpawnPoint.position, leftBulletSpawnPoint.rotation);
	}

	void Move(float h){
		Vector3 movement = transform.forward * speed * h * Time.deltaTime;
		Transform legs = body.transform.Find ("Body").Find ("Lower").transform;

		body.MovePosition (body.position + movement);

		if(movement.z > 0)
			legs.localScale = new Vector3 (1f, 1f, 1f);
		if (movement.z < 0)
			legs.localScale = new Vector3 (1f, 1f, -1f);

	}
	void Turn(){
		Vector3 difference = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		Transform upperBody = body.transform.Find ("Body").Find ("Upper");

		if (difference.z - transform.position.z < 0f) 
			upperBody.rotation = Quaternion.Euler (0f, 180f, 0f);
		else
			upperBody.rotation = Quaternion.Euler (0f, 0f, 0f);
	}
	void Animating (float h){
		bool walking = h != 0f;

		if (walking && !startedAnimation) {
			print ("play");
			anim.Play("WalkForward");
			startedAnimation = true;
		} else if(!walking && startedAnimation){
			anim.Play ("Idle");
			startedAnimation = false;
		}
	}

	void Jump(){
		body.AddForce (new Vector3 (0f, jumpRate, 0f));
		jumpAvailable = false;
	}

	public void AllowJump(){
		jumpAvailable = true;
	}
}
