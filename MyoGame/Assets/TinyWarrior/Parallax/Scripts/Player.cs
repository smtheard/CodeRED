using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Diagnostics;

public class Player : MonoBehaviour {
    public float pos = 0f;
	public bool isJumping = false;
	Animator animator;
	float speed = 0f;
	BoxCollider hitbox;
	float startingX = 0.07f;
	Text text;
	Stopwatch stopwatch;

	void Start () {
        pos = 0f;
		speed = 0f;
        animator = GetComponent<Animator>();
        hitbox = GetComponent<BoxCollider> ();
		//stopwatch = new Stopwatch ();
		//stopwatch.Start ();
		//text = GameObject.Find ("Text").GetComponent<Text> ();
		//text.text = "";
	}

    void SetSpeed(float spd) {
		speed = spd;
        animator.SetFloat("Speed", speed);
    }

    void OnAttack() {
        animator.SetTrigger("Attack");
    }

    void OnJump() {
		/*if (!isJumping)*/ animator.SetTrigger("Jump");
	}

	void OnRight() {
		SetSpeed (1f);
	}

	void OnLeft() {
		if (speed == -1f)
			SetSpeed (-1f);
		else
			SetSpeed(speed - 1f);
	}

	void OnStop() {
        SetSpeed(0f);
    }

    void UpdateMovement() {
    	hitbox.center = new Vector3(animator.bodyPosition.x+5.68f, animator.bodyPosition.y+2.6f, animator.bodyPosition.z+2f);
        pos += speed * Time.deltaTime;
    }

	void Update () {
        UpdateMovement();

		//if (pos >= 50) {
		//	stopwatch.Stop ();
		//	text.text = stopwatch.Elapsed.ToString();
		//}

		if (animator.bodyPosition.x != startingX) {
			isJumping = true;
		} else {
			isJumping = false;
		}
	}
}
