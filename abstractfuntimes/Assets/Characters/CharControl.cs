using UnityEngine;
using System.Collections;

public class CharControl : MonoBehaviour {

	public GameObject FPSController;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = FPSController.transform.position;
		transform.rotation = FPSController.transform.rotation;
	}
}
