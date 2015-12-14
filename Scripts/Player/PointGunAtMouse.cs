using UnityEngine;
using System.Collections;

public class PointGunAtMouse : MonoBehaviour {

	
	private Vector3 mousePos;
	private Vector3 screenPos;
	

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		float parentRotation = transform.parent.transform.rotation.eulerAngles.y;
		bool turned = parentRotation > 50? true : false;

		Transform gunPoint = transform.Find ("Hand").transform.Find ("Gun").transform.Find ("BulletSpawnPoint");

		mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		Vector3 difference = new Vector3 (0f, (transform.position.y + 1.2f) - mousePos.y, transform.position.z - mousePos.z);
		float rotation = - (Mathf.Atan2 (difference.y, difference.z) * Mathf.Rad2Deg - 180);
		transform.rotation = Quaternion.Euler (rotation, 0f, 0f);

		if (turned)
			transform.localScale = new Vector3 (1, -1, 1);
		else
			transform.localScale = new Vector3 (1, 1, 1);

	
	}
}
