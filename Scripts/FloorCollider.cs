using UnityEngine;
using System.Collections;

public class FloorCollider : MonoBehaviour {



	void OnTriggerEnter(){
		transform.parent.gameObject.GetComponent<PlayerController> ().AllowJump ();
	}
}
