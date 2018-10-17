using System.Collections.Generic;
using UnityEngine;

public class input2 : MonoBehaviour {
	public Animator playerAnimator;
	public GameObject player;
	public AudioSource ack;
	public Vector3 playerPos, clickPos;

	// Use this for initialization
	void Start(){
		clickPos = new Vector3(0f,0f,0f);
		playerPos = player.transform.position;
	}

	// Update is called once per frame
	void Update(){
		if (Input.GetButtonDown("Fire2"))
			gameController.myList.Clear();

		playerPos = player.transform.position;
		if (Input.GetButtonDown("Fire1")){
			if (gameController.myList.Contains(player)){
				if (!playerAnimator.GetBool("inMotion"))
					ack.Play();
			}
			clickPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		}
	}

	void FixedUpdate(){
		if ((Mathf.RoundToInt(playerPos.x) != Mathf.RoundToInt(clickPos.x)
		|| Mathf.RoundToInt(playerPos.y) != Mathf.RoundToInt(clickPos.y)) && gameController.myList.Contains(player)){
			//in motion
			playerAnimator.SetBool("inMotion", true);

			//left right
			if (Mathf.RoundToInt(playerPos.x) < Mathf.RoundToInt(clickPos.x)){
				transform.Translate((Vector3.right * 5) * Time.deltaTime);
				playerAnimator.SetBool("isRight", true);
				playerAnimator.SetBool("isLeft", false);
			}else if (Mathf.RoundToInt(playerPos.x) > Mathf.RoundToInt(clickPos.x)){
				transform.Translate((Vector3.right * 5) * -Time.deltaTime);
				playerAnimator.SetBool("isRight", false);
				playerAnimator.SetBool("isLeft", true);
			}else if (Mathf.RoundToInt(playerPos.x) == Mathf.RoundToInt(clickPos.x)){
				playerAnimator.SetBool("isRight", false);
				playerAnimator.SetBool("isLeft", false);
			}

			//up down
			if (Mathf.RoundToInt(playerPos.y) < Mathf.RoundToInt(clickPos.y)){
				transform.Translate((Vector3.up * 5) * Time.deltaTime);
				playerAnimator.SetBool("isUp", true);
				playerAnimator.SetBool("isDown", false);
			}else if (Mathf.RoundToInt(playerPos.y) > Mathf.RoundToInt(clickPos.y)){
				transform.Translate((Vector3.up * 5) * -Time.deltaTime);
				playerAnimator.SetBool("isDown", true);
				playerAnimator.SetBool("isUp", false);
			}else if (Mathf.RoundToInt(playerPos.y) == Mathf.RoundToInt(clickPos.y)){
				playerAnimator.SetBool("isUp", false);
				playerAnimator.SetBool("isDown", false);
			}
		}else{
			playerAnimator.SetBool("inMotion", false);
		}
	}
}
