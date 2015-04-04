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
	
	void Update ()
    {
		ThalmicMyo thalmicMyo = myo.GetComponent<ThalmicMyo>();
		ThalmicMyo thalmicMyoLeft = myoLeft.GetComponent<ThalmicMyo>();

		if (countR == 0) {
			_lastPos = thalmicMyo.transform.rotation.x - 0.25f;
			speedR = 0.25f;
			countR++;
		} else if (((thalmicMyo.transform.rotation.x - 0.25) > 0.0 && _lastPos < 0) || 
				   ((thalmicMyo.transform.rotation.x - 0.25) < 0.0 && _lastPos > 0)) {
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
			_leftLastPos = (thalmicMyoLeft.transform.up.y);
			speedL = 0.25f;
			countL++;
		} else if ((thalmicMyoLeft.transform.up.y > 0.35 && _leftLastPos < 0.35) || 
		           (thalmicMyoLeft.transform.up.y < 0.35 && _leftLastPos > 0.35)) {
			_leftLastPos = (thalmicMyoLeft.transform.up.y);
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
		Debug.Log(speed);

		/*
		if (thalmicMyo.pose != _lastPose) {
			_lastPose = thalmicMyo.pose;

			if (thalmicMyo.pose == Pose.FingersSpread) {
				target.SendMessage("OnJump", SendMessageOptions.DontRequireReceiver);
			} else if (thalmicMyo.pose == Pose.WaveOut) {
				target.SendMessage("OnRight", SendMessageOptions.DontRequireReceiver);
			} else if (thalmicMyo.pose == Pose.WaveIn) {
				target.SendMessage("OnLeft", SendMessageOptions.DontRequireReceiver);
			}
		} else {
			if (Input.GetKeyDown(KeyCode.Space)) {
				target.SendMessage("OnJump", SendMessageOptions.DontRequireReceiver);
			} else if (Input.GetKeyDown(KeyCode.D)) {
				target.SendMessage("OnRight", SendMessageOptions.DontRequireReceiver);
			} else if (Input.GetKeyDown(KeyCode.A)) {
				target.SendMessage("OnLeft", SendMessageOptions.DontRequireReceiver);
			}
		}*/
    }
	
	void ExtendUnlockAndNotifyUserAction (ThalmicMyo myo)
	{
		ThalmicHub hub = ThalmicHub.instance;
		
		if (hub.lockingPolicy == LockingPolicy.Standard) {
			myo.Unlock (UnlockType.Timed);
        }

        myo.NotifyUserAction ();
    }
}
