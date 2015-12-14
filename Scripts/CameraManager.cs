using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour {

	public Transform player;

	private Vector3 offset;


	// Use this for initialization
	void Start () {
		offset = transform.position - player.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		transform.position = player.position + offset;
	}
}
