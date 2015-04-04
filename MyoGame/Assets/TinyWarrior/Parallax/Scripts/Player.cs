using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    public float pos = 0f;
	Animator animator;
	float speed = 0f;
	BoxCollider hitbox;
	void Start () {
        pos = 0f;
		speed = 0f;
        animator = GetComponent<Animator>();
        hitbox = GetComponent<BoxCollider> ();
	}

    void SetSpeed(float spd) {
		speed = spd;
        animator.SetFloat("Speed", speed);
    }

    void OnAttack() {
        animator.SetTrigger("Attack");
    }

    void OnJump() {
		animator.SetTrigger("Jump");
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
    	hitbox.center = new Vector3(animator.bodyPosition.x+0.07f, animator.bodyPosition.y+2.4f, animator.bodyPosition.z+2f);
        pos += speed * Time.deltaTime;
    }

	void Update () {
        UpdateMovement();
	}
}
