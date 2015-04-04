using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    public float pos = 0f;
    Animator animator;
    float speed = 0f;
    int direction = 0;

	void Start () {
        pos = 0f;
        speed = 0f;
        animator = GetComponent<Animator>();
	}

    void SetSpeed(float spd)
    {
        speed = spd;
        animator.SetFloat("Speed", speed);
    }
    void OnAttack()
    {
        animator.SetTrigger("Attack");
    }
    void OnJump()
	{
		animator.SetTrigger("Jump");
	}
	void OnRight()
    {
        direction = 1;
    }
    void OnLeft()
    {
        direction = -1;
    }
    void OnStop()
    {
        direction = 0;
        SetSpeed(0f);
    }

    void UpdateMovement()
    {
        if (direction == 1)
			SetSpeed (direction * 1.5f);
		else
			SetSpeed(direction);

        pos += speed * Time.deltaTime;
    }

	void Update () {
        UpdateMovement();
	}
}
