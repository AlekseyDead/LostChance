using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyingOfPoints : MonoBehaviour {
	private float lifetime = 1.0f;

	public GameObject[] FRIS = new GameObject[10];
	public GameObject[] FRIS2 = new GameObject[10];





	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void DIEDIEDIE()
	{




		Destroy (FRIS[0], lifetime);
		Destroy (FRIS[1], lifetime);
		Destroy (FRIS[2], lifetime);
		Destroy (FRIS[3], lifetime);
		Destroy (FRIS[4], lifetime);

		Destroy (FRIS2[0], lifetime);
		Destroy (FRIS2[1], lifetime);
		Destroy (FRIS2[2], lifetime);
		Destroy (FRIS2[3], lifetime);
		Destroy (FRIS2[4], lifetime);

		Destroy (gameObject, lifetime);












	}
}
