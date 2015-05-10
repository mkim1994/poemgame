using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour {

	public GameObject fps;
	public GameObject thirdpcam;
	public GameObject bird;
	public GameObject fish;

	public GameObject text;

	public bool birdyes;
	public bool skyyes;
	public bool chaosyes;
	public bool fightyes;

	Camera cam;
	Camera charcam;

	private Color32 color1 = new Color32(129,210,255,5);
	private Color32 color2 = new Color32(21,37,58,5);

	void Start () {
		fps.SetActive (false);
		thirdpcam.SetActive (true);
		birdyes = true;
		skyyes = true;
		chaosyes = true;
		fightyes = true;


		cam = thirdpcam.GetComponent<Camera>();
		charcam = fps.transform.FindChild ("FirstPersonCharacter").gameObject.GetComponent<Camera>();
	}

	void Update () {
		if(skyyes){
			cam.clearFlags = CameraClearFlags.SolidColor;
			charcam.clearFlags = CameraClearFlags.SolidColor;
			cam.backgroundColor = color1;
			charcam.backgroundColor = color1;
		}
		else if(!skyyes){
			cam.clearFlags = CameraClearFlags.SolidColor;
			charcam.clearFlags = CameraClearFlags.SolidColor;
			cam.backgroundColor = color2;
			charcam.backgroundColor = color2;
		}

		if(Input.GetMouseButtonDown (1)){
			thirdpcam.SetActive (false);
			fps.SetActive (true);
			bird.SetActive (false);
			fish.SetActive (false);
			text.SetActive (false);

		}
		if(Input.GetMouseButtonDown (0)){
			thirdpcam.SetActive (true);
			fps.SetActive (false);
			text.SetActive (true);

			if(birdyes) bird.SetActive (true);
			else fish.SetActive (true);
		}
	}
}
