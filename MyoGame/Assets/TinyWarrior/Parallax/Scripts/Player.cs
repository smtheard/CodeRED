using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    public float pos = 0f;
	Animator animator;
	float speed = 0f;

	void Start () {
        pos = 0f;
		speed = 0f;
        animator = GetComponent<Animator>();
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
		if (speed == 1f)
			SetSpeed (1f);
		else
			SetSpeed(speed + 1f);
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
        pos += speed * Time.deltaTime;
    }

	void Update () {
        UpdateMovement();
	}
}
