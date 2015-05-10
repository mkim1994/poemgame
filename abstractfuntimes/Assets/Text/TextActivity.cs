using UnityEngine;
using System.Collections;

public class TextActivity : MonoBehaviour {

	public Sprite one;
	public Sprite two;
	public GameObject A;
	public GameObject B;
	public int line;
	Animator birdanim;
	Animator fishanim;
	Animator skyanim;
	Animator oceananim;
	BoxCollider box1;
	CapsuleCollider box2;
	GameMaster gm;

	private SpriteRenderer spriteRenderer;

	void Start(){
		gm = GameObject.Find("GM").GetComponent<GameMaster>();
		box1 = GetComponent<BoxCollider>();
		box2 = GetComponent<CapsuleCollider>();
		spriteRenderer = GetComponent<SpriteRenderer>();

		if(line==3){
			skyanim = A.transform.FindChild ("sky model").gameObject.GetComponent<Animator>();
			oceananim = B.transform.FindChild ("ocean model").gameObject.GetComponent<Animator>();

			skyanim.SetBool ("IsChaos",true);
			skyanim.SetBool ("IsOrder",false);
			oceananim.SetBool ("IsChaos",true);
			oceananim.SetBool ("IsOrder",false);
		}
		if(line==4){
			birdanim = A.transform.FindChild ("Bird Model").gameObject.GetComponent<Animator>();
			fishanim = B.transform.FindChild ("Fish Model").gameObject.GetComponent<Animator>();
		}

		B.SetActive (false);
	}

	void OnMouseOver()
	{
		if(Input.GetMouseButtonDown (0)){

			if(spriteRenderer.sprite == one){
				spriteRenderer.sprite = two;
				box1.enabled = false;
				box2.enabled = true;

				if(line == 1){
					A.SetActive (false);
					B.SetActive (true);
					gm.birdyes = false;
				}
				else if(line == 2){
					gm.skyyes = false;
					A.SetActive (false);
					B.SetActive (true);
				}
				else if(line == 3){
					gm.chaosyes = false;
				}
				else if(line == 4){
					gm.fightyes = false;
				}
			}
			else if(spriteRenderer.sprite == two){
				spriteRenderer.sprite = one;
				box1.enabled = true;
				box2.enabled = false;

				if(line == 1){
					gm.birdyes = true;
					B.SetActive (false);
					A.SetActive (true);
				}
				else if(line == 2){
					gm.skyyes = true;
					B.SetActive (false);
					A.SetActive (true);
				}
				else if(line == 3){
					gm.chaosyes = true;
				}
				else if(line == 4){
					gm.fightyes = true;
				}
			}
		}
	}

	void Update(){
		if(line==3){
			if(gm.skyyes && !gm.chaosyes){
				skyanim.SetBool ("IsChaos",false);
				skyanim.SetBool ("IsOrder",true);
			}
			else if(!gm.skyyes && !gm.chaosyes){
				oceananim.SetBool ("IsChaos",false);
				oceananim.SetBool ("IsOrder",true);
			}
			else if(gm.skyyes && gm.chaosyes){
				skyanim.SetBool ("IsChaos",true);
				skyanim.SetBool ("IsOrder",false);
			}
			else if(!gm.skyyes && gm.chaosyes){
				oceananim.SetBool ("IsChaos",true);
				oceananim.SetBool ("IsOrder",false);
			}
		}
		else if(line==4){
			if(gm.birdyes && !gm.fightyes){
				birdanim.SetBool ("IsFighting",false);
				birdanim.SetBool ("IsFlowing",true);
			}
			else if(!gm.birdyes && !gm.fightyes){
				fishanim.SetBool ("IsFighting",false);
				fishanim.SetBool ("IsFlowing",true);
			}
			else if(gm.birdyes && gm.fightyes){
				birdanim.SetBool ("IsFighting",true);
				birdanim.SetBool ("IsFlowing",false);
			}
			else if(!gm.birdyes && gm.fightyes){
				fishanim.SetBool ("IsFighting",true);
				fishanim.SetBool ("IsFlowing",false);
			}
		}
	}
}
