using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameController : MonoBehaviour {
	static public List<GameObject> myList = new List<GameObject>();
	public GameObject player1, player2;
	public Animator player1Anim, player2Anim;

	
	// Update is called once per frame
	void Update () {
		RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.forward);

		if (hit.collider == player1.GetComponent<Collider2D>()){
			if (Input.GetMouseButton(2)){
				if (!myList.Contains(player1))
					myList.Add(player1);
			}

			if (Input.GetButtonDown("Fire1")){
				myList.Clear();
				myList.Add(player1);
				player1Anim.SetBool("inMotion", false);
			}
		}

		if (hit.collider == player2.GetComponent<Collider2D>()){
			if (Input.GetMouseButton(2)){
				if (!myList.Contains(player2))
					myList.Add(player2);
			}

			if (Input.GetButtonDown("Fire1")){
				myList.Clear();
				myList.Add(player2);
				player2Anim.SetBool("inMotion", false);
			}
		}
	}
}
