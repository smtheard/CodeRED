using UnityEngine;
using System.Collections;

using LockingPolicy = Thalmic.Myo.LockingPolicy;
using Pose = Thalmic.Myo.Pose;
using UnlockType = Thalmic.Myo.UnlockType;
using VibrationType = Thalmic.Myo.VibrationType;

public class PlayerController2 : MonoBehaviour
{
	public GameObject target;
	public GameObject myo = null;
	public GameObject myoLeft = null;

	private Pose _lastPoseRight = Pose.Unknown;
	private Pose _lastPoseLeft = Pose.Unknown;

	private bool leftJump = false;
	private bool rightJump = false;

	private bool leftOnRight = false;
	private bool rightOnRight = false;

	private bool leftOnLeft = false;
	private bool rightOnLeft = false;

	void Update ()
	{
		ThalmicMyo thalmicMyo = myo.GetComponent<ThalmicMyo> ();
		ThalmicMyo thalmicMyoLeft = myoLeft.GetComponent<ThalmicMyo> (); 

		if (_lastPoseRight != thalmicMyo.pose ) {
			_lastPoseRight = thalmicMyo.pose;
			if (thalmicMyo.pose == Pose.FingersSpread) {
				rightJump = true;
			} else if (thalmicMyo.pose == Pose.WaveOut) {
				rightOnRight = true;
			} else if (thalmicMyo.pose == Pose.WaveIn) {
				rightOnLeft = true;
			} else {
				rightJump = false; rightOnRight = false;
			}
		} else if (_lastPoseLeft != thalmicMyoLeft.pose) {
			_lastPoseLeft = thalmicMyoLeft.pose;
			if (thalmicMyoLeft.pose == Pose.FingersSpread) {
				leftJump = true;
			} else if (thalmicMyoLeft.pose == Pose.WaveIn) {
				leftOnRight = true;
			} else if (thalmicMyoLeft.pose == Pose.WaveIn) {
				leftOnLeft = true;
			} else {
				leftJump = true; leftOnRight = false;
			}
		}

		if (leftJump && rightJump) {
			target.SendMessage ("OnJump", SendMessageOptions.DontRequireReceiver);
			leftJump = false;
			rightJump = false;
		} else if (rightOnRight && leftOnRight) {
			target.SendMessage ("SetSpeed", 2f, SendMessageOptions.DontRequireReceiver);
			rightOnRight = false;
			leftOnRight = false;
		} else if (rightOnLeft && leftOnLeft) {
			target.SendMessage ("SetSpeed", -2f, SendMessageOptions.DontRequireReceiver);
			rightOnLeft = false;
			leftOnLeft = false;
		} else if ((rightOnLeft && leftOnRight) || (rightOnRight && leftOnLeft)) {
			target.SendMessage ("SetSpeed", 0f, SendMessageOptions.DontRequireReceiver);
			rightOnRight = false;
			leftOnRight = false;
			rightOnLeft = false;
			leftOnLeft = false;
		}
	}
}
