  

var smooth = 2.0;  
var rotate : boolean;
var ray:Ray  = Camera.main.ScreenPointToRay(Input.mousePosition);
var hit:RaycastHit;

function Start(){
	 rotate = true;
}

function FixedUpdate () { 
		if(rotate){
				transform.Rotate(new UnityEngine.Vector3(0,0,3));
				rotate = true;
			}
		
		else{
			transform.Rotate(new UnityEngine.Vector3(0,0,0));
			 
			}
			
			if(Input.GetKeyDown("enter")){
	  
				if(rotate) rotate = false;
				else rotate = true; 
				
				}
 
}


function OnTriggerEnter (other : Collider){ 
 
 
	if(Input.GetKeyDown("enter"))
	{ 
		if(rotate) rotate = false; else rotate = true;
	}

}
