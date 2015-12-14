using UnityEngine;
using System.Collections;

public class DestroyBullet : MonoBehaviour {

	void OnTriggerExit(Collider other){
		if(other.CompareTag("Bullet"))
		   Destroy(other.gameObject);
	}
}
