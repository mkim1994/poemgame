using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour {

	public GameObject fps;
	public GameObject maincam;
	public GameObject bird;
	public GameObject fish;

	public GameObject text;

	public bool birdyes;
	public bool skyyes;



	// Use this for initialization
	void Start () {
		fps.SetActive (false);
		maincam.SetActive (true);

	}
	
	// Update is called once per frame
	void Update () {


		if(Input.GetMouseButtonDown (1)){
			maincam.SetActive (false);
			fps.SetActive (true);
			bird.SetActive (false);
			fish.SetActive (false);
			text.SetActive (false);


		}
		if(Input.GetMouseButtonDown (0)){
			maincam.SetActive (true);
			fps.SetActive (false);
			text.SetActive (true);

			if(birdyes) bird.SetActive (true);
			else fish.SetActive (true);
		}
	}
}
