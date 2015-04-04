using UnityEngine;
using System.Collections;

public class BGScroller : MonoBehaviour {
	public float scrollSpeed;
	public float tileSizeY;
	private Player player;

	private Vector3 startPosition;

	void Start () {
		startPosition = transform.position;
		player = GameObject.Find("Player").GetComponent<Player>();
	}

	void Update () {
		float newPos = Mathf.Repeat (player.pos * scrollSpeed, tileSizeY);
		transform.position = startPosition + Vector3.left *  newPos;
	}
}
