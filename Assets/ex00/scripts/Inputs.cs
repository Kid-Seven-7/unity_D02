using UnityEngine;

public class Inputs : MonoBehaviour {

	public Animator playerAnimator;

	public GameObject player;

	public AudioSource ack;

	public bool clicked;
	public Vector3 playerPos;

	public Vector3 clickPos;

	// Use this for initialization
	void Start () {
		clickPos = playerPos = player.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		playerPos = player.transform.position;
		if (Input.GetMouseButtonDown(0)){
			if (!playerAnimator.GetBool("inMotion"))
				ack.Play();
			clickPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		}
	}

	void FixedUpdate() {
		if (Mathf.RoundToInt(playerPos.x) != Mathf.RoundToInt(clickPos.x) 
		|| Mathf.RoundToInt(playerPos.y) != Mathf.RoundToInt(clickPos.y)){
			//in motion
			playerAnimator.SetBool("inMotion", true);
			
			//Move right
			if (Mathf.RoundToInt(playerPos.x) < Mathf.RoundToInt(clickPos.x)){
				transform.Translate((Vector3.right * 5) * Time.deltaTime);
				playerAnimator.SetBool("isRight", true);
				playerAnimator.SetBool("isLeft", false);
			}
			//move left
			if (Mathf.RoundToInt(playerPos.x) > Mathf.RoundToInt(clickPos.x)){
				transform.Translate((Vector3.right * 5) * -Time.deltaTime);
				playerAnimator.SetBool("isRight", false);
				playerAnimator.SetBool("isLeft", true);
			}
			//no x change
			if (Mathf.RoundToInt(playerPos.x) == Mathf.RoundToInt(clickPos.x)){
				playerAnimator.SetBool("isRight", false);
				playerAnimator.SetBool("isLeft", false);
			}

			//move up
			if (Mathf.RoundToInt(playerPos.y) < Mathf.RoundToInt(clickPos.y)){
				transform.Translate((Vector3.up * 5) * Time.deltaTime);
				playerAnimator.SetBool("isUp", true);
				playerAnimator.SetBool("isDown", false);
			}
			//move down
			if (Mathf.RoundToInt(playerPos.y) > Mathf.RoundToInt(clickPos.y)){
				transform.Translate((Vector3.up * 5) * -Time.deltaTime);
				playerAnimator.SetBool("isDown", true);
				playerAnimator.SetBool("isUp", false);
			}
			//no y change
			if (Mathf.RoundToInt(playerPos.y) == Mathf.RoundToInt(clickPos.y)){
				playerAnimator.SetBool("isUp", false);
				playerAnimator.SetBool("isDown", false);
			}
		}
		else{
			playerAnimator.SetBool("inMotion", false);
		}
	}
}
