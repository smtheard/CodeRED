using UnityEngine;
using System.Collections;

using LockingPolicy = Thalmic.Myo.LockingPolicy;
using Pose = Thalmic.Myo.Pose;
using UnlockType = Thalmic.Myo.UnlockType;
using VibrationType = Thalmic.Myo.VibrationType;

public class Button : MonoBehaviour
{
	public GameObject myo = null;
	
	void Update ()
	{
		ThalmicMyo thalmicMyo = myo.GetComponent<ThalmicMyo> ();

		if (thalmicMyo.pose == Pose.FingersSpread) {
			Application.LoadLevel(1);
		} else if (thalmicMyo.pose == Pose.WaveOut) {
			Application.LoadLevel(2);
		} 	 
	}
}
