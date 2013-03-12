using UnityEngine;
using System.Collections;

public enum MovementMode
{
	Human,
	Zombie
}

[AddComponentMenu("Mixamo/Demo/Root Motion Character")]
public class RootMotionCharacter : MonoBehaviour
{
	public float turningSpeed = 90f;
	public RootMotionComputer computer;
	public CharacterController character;
	public MovementMode mode = MovementMode.Human;
	public float xSpawnChar;
	public float ySpawnChar;
	public float zSpawnChar;
	
	
	void Start()
	{
		//GameObject hahmo = GameObject.Find("asterix");
		//GameObject GC = GameObject.Find("GameController");
		//GameControllerSpawn GCS =  GC.GetComponent<GameControllerSpawn>();
		//transform.position = new Vector3(GCS.xSpawn, GCS.ySpawn, GCS.zSpawn);
		/*
			GameObject GC = GameObject.Find("GameController");
			GameControllerSpawn GCS = GC.GetComponent<GameControllerSpawn>();
			xSpawnChar = GCS.xSpawn; 
			ySpawnChar = GCS.ySpawn;
			zSpawnChar = GCS.zSpawn;
		*/
			//Debug.Log("KATO MYÖS TÄMÄ: "+GCS.xSpawn+", "+GCS.ySpawn+", "+GCS.zSpawn);
		
		//transform.position = new Vector3(xSpawnChar, ySpawnChar, zSpawnChar);
		//Debug.Log("Xx:"+GCS.xSpawn+" Yy:"+GCS.ySpawn+" Zz:"+GCS.zSpawn);

		//transform.position = new Vector3(0,0,0);
		
		
		// validate component references
		if (computer == null) computer = GetComponent(typeof(RootMotionComputer)) as RootMotionComputer;
		if (character == null) character = GetComponent(typeof(CharacterController)) as CharacterController;
		
		// tell the computer to just output values but not apply motion
		computer.applyMotion = true;
		// tell the computer that this script will manage its execution
		computer.isManagedExternally = true;
		// since we are using a character controller, we only want the z translation output
		computer.computationMode = RootMotionComputationMode.ZTranslation;
		// initialize the computer
		computer.Initialize();
		
		// set up properties for the animations
		animation["idle"].layer = 0; animation["idle"].wrapMode = WrapMode.Loop;
		animation["walk"].layer = 1; animation["walk"].wrapMode = WrapMode.Loop;
		//animation["run"].layer = 1; animation["run"].wrapMode = WrapMode.Loop;
		animation["jump"].layer = 4; animation["jump"].wrapMode = WrapMode.Once;
		animation["back_flip_to_uppercut"].layer = 2; animation["back_flip_to_uppercut"].wrapMode = WrapMode.Once;
		animation["running_jump"].layer = 3; animation["running_jump"].wrapMode = WrapMode.Once;
		//animation["zombiewalk"].layer = 2; animation["zombiewalk"].wrapMode = WrapMode.Loop;
		
		animation.Play("idle");
	}
	
	void Update()
	{
		
		float targetMovementWeight = 0f;
		float throttle = 0f;
		
		// turning keys
		if (Input.GetKey(KeyCode.A)) transform.Rotate(Vector3.down, turningSpeed*Time.deltaTime);
		if (Input.GetKey(KeyCode.D)) transform.Rotate(Vector3.up, turningSpeed*Time.deltaTime);
		
		// forward movement keys
		// ensure that the locomotion animations always blend from idle to moving at the beginning of their cycles
		if (Input.GetKeyDown(KeyCode.W) && 
			(animation["walk"].weight == 0f || animation["run"].weight == 0f))
		{
			animation["walk"].normalizedTime = 0f;
		//	animation["run"].normalizedTime = 0f;
		}
		if (Input.GetKey(KeyCode.W))
		{
			targetMovementWeight = 1f;
		}
		if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.Space) )
		{
			Debug.Log ("Space painettu");
			targetMovementWeight = 3f;
			animation.Blend("running_jump", targetMovementWeight, 0.5f);
			targetMovementWeight = 1f;
			animation.Blend("idle", targetMovementWeight, 0.5f);
			
				//	animation.Blend["back_flip_to_uppercut"].normalizedTime = 0f;
		}
		
		if (Input.GetKey(KeyCode.Space) )
		{
			Debug.Log ("Hyppy painettu");
			targetMovementWeight = 3f;
			animation.Blend("jump", targetMovementWeight, 3f);
			
			//targetMovementWeight = 1f;
			//animation.Blend("idle", targetMovementWeight, 0.5f);
			
				//	animation.Blend["back_flip_to_uppercut"].normalizedTime = 0f;
		}
		
		if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) throttle = 1f;
				
		// blend in the movement
		if (mode == MovementMode.Human)
		{
		//	animation.Blend("run", targetMovementWeight*throttle, 0.5f);
			animation.Blend("walk", targetMovementWeight*(1f-throttle), 0.5f);
			// synchronize timing of the footsteps
			animation.SyncLayer(1);
			
		}
		/*
		else
		{    
			// ensure that the locomotion animations always blend from idle to moving at the beginning of their cycles
			if (Input.GetKeyDown(KeyCode.W) && 
			(animation["zombiewalk"].weight == 0f))
		{
			animation["zombiewalk"].normalizedTime = 0f;
		}

			animation.Blend("zombiewalk", targetMovementWeight, 0.5f);
		}
		*/
		
		//Jump testing
		/*
			if (Input.GetKeyDown(KeyCode.Space)){
				Debug.Log ("Space painettu");
				targetMovementWeight = 2f;
				animation.Blend("back_flip_to_uppercut", targetMovementWeight, 0.5f);
				targetMovementWeight = 1f;
				animation.Blend("idle", targetMovementWeight, 0.5f);
			
				//	animation.Blend["back_flip_to_uppercut"].normalizedTime = 0f;
			
			}
			*/
		
		if (Input.GetKeyDown(KeyCode.C) && 
			(animation["back_flip_to_uppercut"].weight == 0f))
		{
			animation["back_flip_to_uppercut"].normalizedTime = 0f;
			
		}
		/*
		if (Input.GetKeyDown(KeyCode.Space)){
			Debug.Log ("Space painettu");
			targetMovementWeight = 2f;
			animation.Blend("back_flip_to_uppercut", targetMovementWeight, 0.5f);
			targetMovementWeight = 1f;
			animation.Blend("idle", targetMovementWeight, 0.5f);
			
		//	animation.Blend["back_flip_to_uppercut"].normalizedTime = 0f;
			
		}
		*/
		
	}
	
	void LateUpdate()
	{
		computer.ComputeRootMotion();
		
		// move the character using the computer's output
		character.SimpleMove(transform.TransformDirection(computer.deltaPosition)/Time.deltaTime);
	}
}