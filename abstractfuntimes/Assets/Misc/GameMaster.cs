using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour {

	public GameObject fps;
	public GameObject thirdpcam;
	public GameObject bird;
	public GameObject fish;
	public GameObject skylight;
	public GameObject oceanlight;


	public bool birdyes;
	public bool skyyes;
	public bool orderyes;
	public bool flowyes;

	public GameObject skywater;
	public GameObject oceanwater;

	int combocount1 = 2;
	int combocount2 = 4;
	int combocount3 = 8;
	int combocount4 = 16; //2^4 = 16
	bool[] combos1, combos2, combos3, combos4;
	bool stage1, stage2, stage3, stage4;

	Camera cam;
	Camera charcam;
	bool zoomyes;
	//bool canclick;

	private Color32 color1 = new Color32(129,210,255,5);
	private Color32 color2 = new Color32(21,37,58,5);

	int zoom = 2;
	int normal = 50;


	public GameObject text;
	public Sprite[] linechanges;
	GameObject text2, text3, text4;
	SpriteRenderer line1,line2,line3,line4;

	FadeIn fade;

	void Start () {
		fade = GameObject.Find ("Transitions").GetComponent<FadeIn>();

		fps.SetActive (false);
		thirdpcam.SetActive (true);
		birdyes = true;
		skyyes = true;
		orderyes = true;
		flowyes = true;
		zoomyes = false;
	
		skywater.SetActive(false);
		oceanwater.SetActive(false);
		skylight.SetActive(true);
		oceanlight.SetActive(false);
		text.SetActive(true);

		cam = thirdpcam.GetComponent<Camera>();
		charcam = fps.transform.FindChild ("FirstPersonCharacter").gameObject.GetComponent<Camera>();

		combos1 = new bool[combocount1];
		combos2 = new bool[combocount2];
		combos3 = new bool[combocount3];
		combos4 = new bool[combocount4];

		for(int a = 0; a<combocount1; a++){
			combos1[a] = false;
		}
		for(int b = 0; b<combocount2; b++){
			combos2[b] = false;
		}
		for(int c = 0; c<combocount3; c++){
			combos3[c] = false;
		}
		for(int d = 0; d<combocount4; d++){
			combos4[d] = false;
		}
		Transform t1 = text.transform.FindChild("text1");
		Transform t2 = text.transform.FindChild("text2");
		Transform t3 = text.transform.FindChild("text3");
		Transform t4 = text.transform.FindChild("text4");

		//text1 = t1.gameObject;
		text2 = t2.gameObject;
		text3 = t3.gameObject;
		text4 = t4.gameObject;

		line1 = t1.FindChild("l1").gameObject.GetComponent<SpriteRenderer>();
		line2 = t2.FindChild("l2").gameObject.GetComponent<SpriteRenderer>();
		line3 = t3.FindChild("l3").gameObject.GetComponent<SpriteRenderer>();
		line4 = t4.FindChild("l4").gameObject.GetComponent<SpriteRenderer>();

		stage1 = true; stage2 = false; stage3 = false; stage4 = false;

		text2.transform.position -= new Vector3(100,0,0);
		text3.transform.position += new Vector3(100,0,0);
		text4.transform.position += new Vector3(100,0,0);

	}

	void Update (){

		if(stage1  && stage2){
			Invoke("stage1n2", 0.5f);
			stage1 = false;
		}
		else if(stage2  && stage3){
			Invoke("stage2n3", 0.5f);
			stage2 = false;
		}
		else if(stage3  && stage4){
			Invoke("stage3n4", 0.5f);
			stage3 = false;
		}

		if(stage1){
			checkCombos1();
			int count = 0;
			for(int i = 0; i<combocount1; i++){
				if(combos1[i]){
					count++;
				}
			}
			if(count==combocount1){
				stage2 = true;
				fade.BeginFade(1);
			}
		}
		else if(stage2){
			checkCombos2();
			int count = 0;
			for(int i = 0; i<combocount2; i++){
				if(combos2[i]){
					count++;
				}
			}
			if(count==combocount2){
				stage3 = true;
				fade.BeginFade(1);
			}
		}
		else if(stage3){
			checkCombos3();
			int count = 0;
			for(int i = 0; i<combocount3; i++){
				if(combos3[i]){
					count++;
				}
			}
			if(count==combocount3){
				stage4 = true;
				fade.BeginFade(1);
			}
		}
		else if(stage4){
			checkCombos4();
			//keep track of combos
			int count = 0;
			for(int i = 0; i < combocount4; i++){
				if(combos4[i]){
					count++;
				}
			}
			//Debug.Log(count);
			if(count == combocount4){
				fade.BeginFade(1);
				Invoke("loadfinal", 1.0f);
			}
		}


		//actual game
		if(zoomyes){
			if(cam.orthographicSize > zoom){
				cam.orthographicSize-=2;
			}
			else{
				enterfp();
			}
		}
		else if(!zoomyes){
			if(cam.orthographicSize < normal){
				cam.orthographicSize+=2;
			}
		}

		if(skyyes){
			cam.clearFlags = CameraClearFlags.SolidColor;
			charcam.clearFlags = CameraClearFlags.SolidColor;
			cam.backgroundColor = color1;
			charcam.backgroundColor = color1;

			RenderSettings.fogColor = color1;

			skylight.SetActive(true);
			oceanlight.SetActive(false);
		}
		else if(!skyyes){
			cam.clearFlags = CameraClearFlags.SolidColor;
			charcam.clearFlags = CameraClearFlags.SolidColor;
			cam.backgroundColor = color2;
			charcam.backgroundColor = color2;

			RenderSettings.fogColor = color2;

			skylight.SetActive(false);
			oceanlight.SetActive(true);
		}

		if(Input.GetMouseButtonDown (1)){
			zoomyes = true;
		}
		if(Input.GetMouseButtonDown (0)){
			zoomyes = false;
			thirdpcam.SetActive (true);
			fps.SetActive (false);
			text.SetActive (true);
			if(birdyes) bird.SetActive (true);
			else fish.SetActive (true);

			skywater.SetActive(false);
			oceanwater.SetActive(false);

		}
	}
	void enterfp(){
		if(skyyes){
			skywater.SetActive(true);
		}
		else{
			oceanwater.SetActive(true);
		}

		thirdpcam.SetActive (false);
		fps.SetActive (true);
		bird.SetActive (false);
		fish.SetActive (false);
		text.SetActive (false);

	}

	void loadfinal(){
		Application.LoadLevel ("Final");
	}

	void checkCombos1(){
		if(line1.sprite == linechanges[0]){
			combos1[0] = true;
		}
		else{
			combos1[1] = true;
		}
	}

	void checkCombos2(){
		if(line1.sprite == linechanges[0]){
			if(line2.sprite == linechanges[2]){
				combos2[0] = true;
			}
			else{
				combos2[1] = true;
			}
		}
		else{
			if(line2.sprite == linechanges[2]){
				combos2[2] = true;
			}
			else{
				combos2[3] = true;
			}
		}
	}

	void checkCombos3(){
		if(line1.sprite == linechanges[0]){
			if(line2.sprite == linechanges[2]){
				if(line3.sprite == linechanges[4]){
					combos3[0] = true;
				}
				else{
					combos3[1] = true;
				}
			}
			else{
				if(line3.sprite == linechanges[4]){
					combos3[2] = true;
				}
				else{
					combos3[3] = true;
				}
			}
		}
		else{
			if(line2.sprite == linechanges[2]){
				if(line3.sprite == linechanges[4]){
					combos3[4] = true;
				}
				else{
					combos3[5] = true;
				}
			}
			else{
				if(line3.sprite == linechanges[4]){
					combos3[6] = true;
				}
				else{
					combos3[7] = true;
				}
			}
		}
	}

	void checkCombos4(){
		
		if(line1.sprite == linechanges[0]){ //if equal to writer
			if(line2.sprite == linechanges[2]){ //if equal to spontaneous
				if(line3.sprite == linechanges[4]){ //if equal to order
					if(line4.sprite == linechanges[6]){ //if equal to flowing
						combos4[0] = true;
					}
					else{
						combos4[1] = true;
					}
				}
				else{
					if(line4.sprite == linechanges[6]){ //if equal to flowing
						combos4[2] = true;
					}
					else{
						combos4[3] = true;
					}
				}
			}
			else{
				if(line3.sprite == linechanges[4]){ //if equal to order
					if(line4.sprite == linechanges[6]){ //if equal to flowing
						combos4[4] = true;
					}
					else{
						combos4[5] = true;
					}
				}
				else{
					if(line4.sprite == linechanges[6]){ //if equal to flowing
						combos4[6] = true;
					}
					else{
						combos4[7] = true;
					}
				}
			}
		}
		else{
			if(line2.sprite == linechanges[2]){ //if equal to spontaneous
				if(line3.sprite == linechanges[4]){ //if equal to order
					if(line4.sprite == linechanges[6]){ //if equal to flowing
						combos4[8] = true;
					}
					else{
						combos4[9] = true;
					}
				}
				else{
					if(line4.sprite == linechanges[6]){ //if equal to flowing
						combos4[10] = true;
					}
					else{
						combos4[11] = true;
					}
				}
			}
			else{
				if(line3.sprite == linechanges[4]){ //if equal to order
					if(line4.sprite == linechanges[6]){ //if equal to flowing
						combos4[12] = true;
					}
					else{
						combos4[13] = true;
					}
				}
				else{
					if(line4.sprite == linechanges[6]){ //if equal to flowing
						combos4[14] = true;
					}
					else{
						combos4[15] = true;
					}
				}
			}
		}
	}

	void stage1n2(){
		fade.BeginFade(-1);
		text2.transform.position += new Vector3(100,0,0);
	}

	void stage2n3(){
		fade.BeginFade(-1);
		text3.transform.position -= new Vector3(100,0,0);
	}

	void stage3n4(){
		fade.BeginFade(-1);
		text4.transform.position -= new Vector3(100,0,0);
	}
}
