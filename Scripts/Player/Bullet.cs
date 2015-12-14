using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public float speed = 5f;

	private Rigidbody body;


	void Start () {
		body = GetComponent<Rigidbody> ();
		body.velocity = transform.forward * speed;
	}
	
}
