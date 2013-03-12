#pragma strict


 

function FixedUpdate () {
 
var target1 = Quaternion.Euler (5, 0,0);
 //transform.localRotation = Quaternion.Slerp( transform.localRotation,target1,Time.deltaTime * smooth);
transform.Rotate(new UnityEngine.Vector3(0,0,3));
}