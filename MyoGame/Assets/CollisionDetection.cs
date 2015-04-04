using UnityEngine;
using System.Collections;

public class CollisionDetection : MonoBehaviour {
	private Player player;

	void Start () {
		player = GameObject.Find("Player").GetComponent<Player>();
		
	}

	void Update(){

	}

	void OnTriggerEnter(Collider col){
		print ("YOU LOSE!");
		player.pos = 0;
	}

}
