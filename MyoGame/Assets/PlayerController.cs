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
    private Pose _lastPose = Pose.Unknown;

    void Update ()
    {
        ThalmicMyo thalmicMyo = myo.GetComponent<ThalmicMyo> ();

		if (thalmicMyo.pose != _lastPose) {
			_lastPose = thalmicMyo.pose;

			if (thalmicMyo.pose == Pose.FingersSpread) {
				target.SendMessage("OnJump", SendMessageOptions.DontRequireReceiver);
			} else if (thalmicMyo.pose == Pose.WaveOut || Input.GetKeyDown(KeyCode.D)) {
				target.SendMessage("OnRight", SendMessageOptions.DontRequireReceiver);
			} else if (thalmicMyo.pose == Pose.WaveIn || Input.GetKeyDown(KeyCode.A)) {
				target.SendMessage("OnLeft", SendMessageOptions.DontRequireReceiver);
			}
		} else {
			 /*else if (thalmicMyo.pose == Pose.DoubleTap || Input.GetKeyDown(KeyCode.S)) {
				target.SendMessage("OnStop", SendMessageOptions.DontRequireReceiver);
			}*/  if (Input.GetKeyDown(KeyCode.Space)) {
				target.SendMessage("OnJump", SendMessageOptions.DontRequireReceiver);
			} 
		}
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
