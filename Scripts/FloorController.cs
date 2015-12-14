using UnityEngine;
using System.Collections;

public class FloorController : MonoBehaviour {

	void OnTriggerEnter(Collider other){
		if (other.CompareTag ("Bullet")) {
			Destroy (other.gameObject);
		}
	}
}
