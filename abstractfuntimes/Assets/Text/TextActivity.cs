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
	Animator bubbleanim1;
	Animator bubbleanim2;

	Animator cloudanim1;
	Animator cloudanim1a;
	Animator cloudanim1b;
	Animator cloudanim2;
	Animator cloudanim2a;
	Animator cloudanim2b;

	BoxCollider box1;
	CapsuleCollider box2;
	GameMaster gm;

	private SpriteRenderer spriteRenderer;

	public Sprite[] linechanges;

	void Start(){
		gm = GameObject.Find("GM").GetComponent<GameMaster>();
		box1 = GetComponent<BoxCollider>();
		box2 = GetComponent<CapsuleCollider>();
		spriteRenderer = GetComponent<SpriteRenderer>();

		if(line==3){
			skyanim = A.transform.FindChild ("sky model").gameObject.GetComponent<Animator>();
			oceananim = B.transform.FindChild ("ocean model").gameObject.GetComponent<Animator>();
			cloudanim1 = A.transform.FindChild("clouds1").gameObject.GetComponent<Animator>();
			cloudanim1a = A.transform.FindChild("clouds1a").gameObject.GetComponent<Animator>();
			cloudanim1b = A.transform.FindChild("clouds1b").gameObject.GetComponent<Animator>();

			cloudanim2 = A.transform.FindChild("clouds2").gameObject.GetComponent<Animator>();
			cloudanim2a = A.transform.FindChild("clouds2a").gameObject.GetComponent<Animator>();
			cloudanim2b = A.transform.FindChild("clouds2b").gameObject.GetComponent<Animator>();

			bubbleanim1 = B.transform.FindChild("bubble1").gameObject.GetComponent<Animator>();
			bubbleanim2 = B.transform.FindChild("bubble2").gameObject.GetComponent<Animator>();


			skyanim.SetBool ("IsChaos",false);
			skyanim.SetBool ("IsOrder",true);
			cloudanim1.SetBool("IsChaos",false);
			cloudanim1.SetBool("IsOrder",true);
			cloudanim1a.SetBool("IsChaos",false);
			cloudanim1a.SetBool("IsOrder",true);
			cloudanim1b.SetBool("IsChaos",false);
			cloudanim1b.SetBool("IsOrder",true);

			cloudanim2.SetBool("IsChaos",false);
			cloudanim2.SetBool("IsOrder",true);
			cloudanim2a.SetBool("IsChaos",false);
			cloudanim2a.SetBool("IsOrder",true);
			cloudanim2b.SetBool("IsChaos",false);
			cloudanim2b.SetBool("IsOrder",true);

			oceananim.SetBool ("IsChaos",false);
			oceananim.SetBool ("IsOrder",true);
			bubbleanim1.SetBool("IsChaos",false);
			bubbleanim1.SetBool("IsOrder",true);
			bubbleanim2.SetBool("IsChaos",false);
			bubbleanim2.SetBool("IsOrder",true);
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
					gm.orderyes = false;
				}
				else if(line == 4){
					gm.flowyes = false;
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
					gm.orderyes = true;
				}
				else if(line == 4){
					gm.flowyes = true;
				}
			}
		}
	}

	void Update(){
		if(line==3){
			if(gm.skyyes && !gm.orderyes){
				skyanim.SetBool ("IsChaos",true);
				skyanim.SetBool ("IsOrder",false);
				cloudanim1.SetBool("IsChaos",true);
				cloudanim1.SetBool("IsOrder",false);
				cloudanim2.SetBool("IsChaos",true);
				cloudanim2.SetBool("IsOrder",false);
				cloudanim1a.SetBool("IsChaos",true);
				cloudanim1a.SetBool("IsOrder",false);
				cloudanim2a.SetBool("IsChaos",true);
				cloudanim2a.SetBool("IsOrder",false);
				cloudanim1b.SetBool("IsChaos",true);
				cloudanim1b.SetBool("IsOrder",false);
				cloudanim2b.SetBool("IsChaos",true);
				cloudanim2b.SetBool("IsOrder",false);
			}
			else if(!gm.skyyes && !gm.orderyes){
				oceananim.SetBool ("IsChaos",true);
				oceananim.SetBool ("IsOrder",false);
				bubbleanim1.SetBool("IsChaos",true);
				bubbleanim1.SetBool("IsOrder",false);
				bubbleanim2.SetBool("IsChaos",true);
				bubbleanim2.SetBool("IsOrder",false);
			}
			else if(gm.skyyes && gm.orderyes){
				skyanim.SetBool ("IsChaos",false);
				skyanim.SetBool ("IsOrder",true);
				cloudanim1.SetBool("IsChaos",false);
				cloudanim1.SetBool("IsOrder",true);
				cloudanim2.SetBool("IsChaos",false);
				cloudanim2.SetBool("IsOrder",true);
				cloudanim1a.SetBool("IsChaos",false);
				cloudanim1a.SetBool("IsOrder",true);
				cloudanim2a.SetBool("IsChaos",false);
				cloudanim2a.SetBool("IsOrder",true);
				cloudanim1b.SetBool("IsChaos",false);
				cloudanim1b.SetBool("IsOrder",true);
				cloudanim2b.SetBool("IsChaos",false);
				cloudanim2b.SetBool("IsOrder",true);
			}
			else if(!gm.skyyes && gm.orderyes){
				oceananim.SetBool ("IsChaos",false);
				oceananim.SetBool ("IsOrder",true);
				bubbleanim1.SetBool("IsChaos",false);
				bubbleanim1.SetBool("IsOrder",true);
				bubbleanim2.SetBool("IsChaos",false);
				bubbleanim2.SetBool("IsOrder",true);
			}
		}
		else if(line==4){
			if(gm.birdyes && !gm.flowyes){
				birdanim.SetBool ("IsFighting",true);
				birdanim.SetBool ("IsFlowing",false);
			}
			else if(!gm.birdyes && !gm.flowyes){
				fishanim.SetBool ("IsFighting",true);
				fishanim.SetBool ("IsFlowing",false);
			}
			else if(gm.birdyes && gm.flowyes){
				birdanim.SetBool ("IsFighting",false);
				birdanim.SetBool ("IsFlowing",true);
			}
			else if(!gm.birdyes && gm.flowyes){
				fishanim.SetBool ("IsFighting",false);
				fishanim.SetBool ("IsFlowing",true);
			}
		}
	}
}
