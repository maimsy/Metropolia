#pragma strict

var rotate:boolean;


enum State{ fast,slow,stop}
var state:State; 
var RotatingFan: rotatingfan = GetComponent(rotatingfan);


function Start () {

	state = State.fast;

}

function Update () {

if(state == State.fast){
RotatingFan.transform.Rotate(new UnityEngine.Vector3(0,0,10));
transform.Rotate(new UnityEngine.Vector3(3,0,0));}

/*	 
switch(state)
{
		case State.fast:
					RotatingFan.transform.Rotate(new UnityEngine.Vector3(0,0,10));
					transform.Rotate(new UnityEngine.Vector3(10,0,0));
					break;
		

		case State.stop:
					RotatingFan.transform.Rotate(new UnityEngine.Vector3(0,0,0));
					transform.Rotate(new UnityEngine.Vector3(0,0,0));
					break;

		case State.slow:
					RotatingFan.transform.Rotate(new UnityEngine.Vector3(0,0,3));

					transform.Rotate(new UnityEngine.Vector3(3,0,0));
					break;

		default:
				RotatingFan.transform.Rotate(new UnityEngine.Vector3(0,0,0));
				transform.Rotate(new UnityEngine.Vector3(0,0,0));
				break;


} 

*/


if(state == State.fast){ 
					RotatingFan.transform.Rotate(new UnityEngine.Vector3(0,0,10));
					transform.Rotate(new UnityEngine.Vector3(10,0,0));
					 }
		
if(state == State.slow){
		 
					RotatingFan.transform.Rotate(new UnityEngine.Vector3(0,0,0));
					transform.Rotate(new UnityEngine.Vector3(0,0,0));
					}

		if(state == State.stop){
					RotatingFan.transform.Rotate(new UnityEngine.Vector3(0,0,3));

					transform.Rotate(new UnityEngine.Vector3(3,0,0));
					}

		  

		if(Input.GetKeyDown("enter"))
	{ 
	
		 if(state == State.fast)
		 {
		 state = State.stop;
		 }
		 else if(state == State.stop)
		 {
		 state = State.slow;
		 }
		 else
		 {
		 state = State.fast;
		 }
		 
		 
		 
	}
		
//var rotatingFan: rotatingfan = GetComponent(rotatingfan);
 

}

 
