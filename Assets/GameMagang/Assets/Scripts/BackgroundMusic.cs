using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour {

	public AudioSource myAudioSource;

	public static GameObject bgmObject;

	void Awake()
	{
		if (bgmObject) 
		{
			Destroy (gameObject);
			return;
		}

		myAudioSource.Play ();
		bgmObject = gameObject;
	}
}
