using UnityEngine;
using System.Collections;

public class TriggerScript : MonoBehaviour {

	// Use this for initialization
	public bool trigger;
	
	void Start () {
		
	
	}
	
	void OnCollisionEnter(Collision collision) {
        foreach (ContactPoint contact in collision.contacts) {
            Debug.DrawRay(contact.point, contact.normal, Color.white);
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
