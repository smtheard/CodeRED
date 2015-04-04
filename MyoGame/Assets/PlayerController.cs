using UnityEngine;
using System.Collections;

using LockingPolicy = Thalmic.Myo.LockingPolicy;
using Pose = Thalmic.Myo.Pose;
using UnlockType = Thalmic.Myo.UnlockType;
using VibrationType = Thalmic.Myo.VibrationType;

public class PlayerController : MonoBehaviour
{
	public GameObject target;
	public GameObject myo = null;
	public GameObject myoLeft = null;

	private float _lastPos = 0f;
	private float _leftLastPos = 0f;

	private int countR = 0;
	private int countL = 0;

	private float speed = 0f;
	private float speedR = 0f;
	private float speedL = 0f;

	/*private Pose _lastPoseRight = Pose.Unknown;
	private Pose _lastPoseLeft = Pose.Unknown;

	private bool leftJump = false;
	private bool rightJump = false;

	private bool leftOnRight = false;
	private bool rightOnRight = false;*/
	
	void Update ()
	{
		ThalmicMyo thalmicMyo = myo.GetComponent<ThalmicMyo> ();
		ThalmicMyo thalmicMyoLeft = myoLeft.GetComponent<ThalmicMyo> (); 

		if (countR == 0) {
				_lastPos = 1f;
				speedR = 0.25f;
				countR++;
			} else if (((thalmicMyo.transform.rotation.x) > 0.0 && _lastPos < 0) || 
				((thalmicMyo.transform.rotation.x) < 0.0 && _lastPos > 0)) {
				_lastPos = thalmicMyo.transform.rotation.x;
				if (countR < 35) {
					speedR = 1.5f;
				} else if (countR < 65) {
					speedR = 0.75f;
				} else {
					speedR = 0.25f;
				}
				countR = 1;
			} else if (countR > 65) {
				speedR = 0.25f;
				countR++;
			} else if (countR > 35) {
				speedR = 0.75f;
				countR++;
			} else {
				countR++;
			}

			if (countL == 0) {
				_leftLastPos = -1f;
				speedL = 0.25f;
				countL++;
			} else if ((thalmicMyoLeft.transform.rotation.z > 0.0 && _leftLastPos < 0.0) || 
				(thalmicMyoLeft.transform.rotation.z < 0.0 && _leftLastPos > 0.0)) {
				_leftLastPos = (thalmicMyoLeft.transform.rotation.z);
				if (countL < 35) { 
					speedL = 1.5f;
				} else if (countL < 65) { 
					speedL = 0.75f;
				} else {
					speedL = 0.25f;
				}
				countL = 1;
			} else if (countL > 65) {
				speedL = 0.25f;
				countL++;
			} else if (countL > 35) {
				speedL = 0.75f;
				countL++;
			} else {
				countL++;
			}  

			speed = speedR + speedL;
			target.SendMessage ("SetSpeed", speed, SendMessageOptions.DontRequireReceiver);

		/*if (thalmicMyo.transform.rotation.x > 0.0 && thalmicMyoLeft.transform.rotation.z > 0.0) {
			target.SendMessage ("OnJump", SendMessageOptions.DontRequireReceiver);

			if (_lastPoseRight != thalmicMyo.pose ) {
			_lastPoseRight = thalmicMyo.pose;
			if (thalmicMyo.pose == Pose.FingersSpread) {
				rightJump = true;
			} else if (thalmicMyo.pose == Pose.WaveOut) {
				rightOnRight = true;
			} else {
				rightJump = false; rightOnRight = false;
			}
		} else if (_lastPoseLeft != thalmicMyoLeft.pose) {
			_lastPoseLeft = thalmicMyoLeft.pose;
			if (thalmicMyoLeft.pose == Pose.FingersSpread) {
				leftJump = true;
			} else if (thalmicMyoLeft.pose == Pose.WaveIn) {
				leftOnRight = true;
			} else {
				leftJump = true; leftOnRight = false;
			}
		}

		if (leftJump && rightJump) {
			target.SendMessage ("OnJump", SendMessageOptions.DontRequireReceiver);
			leftJump = false;
			rightJump = false;
		} else if (rightOnRight && leftOnRight) {
			target.SendMessage ("S", SendMessageOptions.DontRequireReceiver);
			rightOnRight = false;
			leftOnRight = false;
		}
		}*/
	}
}
