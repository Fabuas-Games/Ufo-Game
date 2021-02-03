 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class speedo : MonoBehaviour {


	public Rigidbody objectToMeasure;
	public float minVelocity = 0.115f;
	public float maxVelocity = 0.9f;

	private Image image;
	

	// Use this for initialization
	void Start () {
		image = GetComponent<Image> ();
	}
	
	void Update (){
		{
			image.fillAmount = objectToMeasure.velocity.magnitude / maxVelocity / minVelocity;
		}

		{
			//speed exceded 20
			if (image.fillAmount >= 0.240f)
				Debug.Log ("Speed:20");
		}
	}


}
