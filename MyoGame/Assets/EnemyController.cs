using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	private Player target;
	private Animator animator;
	private bool playerInRange;
	private float dist; 
	private float bufferDist; 
	private float range;
	private float speed;
	private Vector3 destination;
	private bool isWandering;

	// Use this for initialization
	void Start ()
	{
		target = GameObject.Find("Player").GetComponent<Player>();
		animator = GetComponent<Animator>();
		animator.SetFloat("Speed",0);
		playerInRange = false;
		dist = Vector3.Distance(target.transform.position, transform.position);
		bufferDist = 0f;
		range = 1f;
		speed = 3f;
		destination = new Vector3(Random.Range (-6,6),0,0);
		isWandering = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		//recalculate distance to player
		GetDistance ();

		if(playerInRange)
		{
			//Attack();
			animator.SetFloat("Speed",0f);
		}
		else{
			if(isWandering == false)
			{
				Wander();
			}
			else
			{
				Move();
			}
		}
	}

	//Patrol, enemy searching for player
	void Wander()
	{
		//get new destination at random, if distnace between enemy and destination is larger than range move towards destination 
		isWandering = true;
		destination = new Vector3(Random.Range (-6,6),0,0);
		if(Vector3.Distance(destination,transform.position)>range)
		{
			Move();
		}
		else
		{
			isWandering = false;
		}
	}

	void Attack()
	{
		//Debug.Log(Attacking Player);
	}

	void GetDistance()
	{
		//recalculate distance from enemy to player
		dist = Vector3.Distance(target.transform.position, transform.position);
		if(dist-bufferDist <= range)
		{
			playerInRange = true;
		}
		else
		{
			playerInRange = false;
		}
	}

	void Move()
	{
		//Face destination, Change animation to start walking based on direction of destination, move towards destination
		Vector3 delta = destination - transform.position;
		delta.Normalize();
		float movespeed = speed * Time.deltaTime;
		transform.LookAt(target.transform);
		Vector3 adjusted = new Vector3(transform.position.x+(delta.x * movespeed),-2.6f,-2f);
		animator.SetFloat("Speed",2f);
		transform.position =adjusted;
	}
}
