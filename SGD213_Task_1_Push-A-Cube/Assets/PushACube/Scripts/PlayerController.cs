using UnityEngine;

// Include the namespace required to use Unity UI
using UnityEngine.UI;

using System.Collections;

public class PlayerController : MonoBehaviour {

    // Create public variables for player speed - allows for easier game tuning
    public float playerSpeed;
	public Text scoreTotal;
	public Text winText;
	// Create private references to the rigidbody component on the player, and the count of pick up objects picked up so far
	private Rigidbody rb;
	private float intTotalCount;


	// At the start of the game..
	void Start (){
		rb = GetComponent<Rigidbody>();
		intTotalCount = 0;
		SetCountText ();
		winText.text = "";
	}

	void FixedUpdate (){
		// Set some local float variables equal to the value of our Horizontal and Vertical Inputs
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		// Create a Vector3 variable, and assign X and Z to feature our horizontal and vertical float variables above
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rb.AddForce (movement * playerSpeed);
	}
	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("Pick Up")){
			other.gameObject.SetActive (false);
			intTotalCount = intTotalCount + 1;
			SetCountText ();
		}
	}

    void SetCountText(){
		scoreTotal.text = "Count: " + intTotalCount.ToString ();
		if (intTotalCount >= 12){
			// Set the text value of our 'winText'
			winText.text = "You Win!";
		}
	}
}