using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	private PlayerStats playerStats;
	public float speed;            // The speed that the player will move at.
	float throwForce;
	private PlayerShooting playerShot;
    private LoadingScreen loadingScreen;
	Vector3 movement;                   // The vector to store the direction of the player's movement.
	//Animator anim;                      // Reference to the animator component.
    bool loadScreen = false;
	Rigidbody playerRigidbody;          // Reference to the player's rigidbody.
	int floorMask;                      // A layer mask so that a ray can be cast just at gameobjects on the floor layer.
	float camRayLength = 100f;          // The length of the ray from the camera into the scene.
	
	void Awake ()
	{
		throwForce = 15;
		// Create a layer mask for the floor layer.
		floorMask = LayerMask.GetMask ("Floor");		
		// Set up references.
		//anim = GetComponent <Animator> ();
		playerStats = GetComponent<PlayerStats> ();
		speed = playerStats.speed;
		playerRigidbody = GetComponent <Rigidbody> ();
        loadingScreen = GameObject.FindGameObjectWithTag("LoadingScreen").GetComponent<LoadingScreen>();
		playerShot = transform.GetComponent<PlayerShooting> ();
	}

	void Update()
	{
		speed = playerStats.speed;
        
        if (!playerStats.brutalMode)
        {
            //if (Input.GetKeyDown("escape")) Application.Quit ();
            //if (Input.GetKey ("1")) playerShot.weapon = PlayerShooting.Weapon.MELEE;
            if (Input.GetKey(KeyCode.F1) && !loadingScreen.loadCurrentScreen) loadingScreen.loadCurrentScreen = true;
            if (Input.GetKey("1")) playerShot.weapon = PlayerShooting.Weapon.GUN;
            if (Input.GetKey("2")) playerShot.weapon = PlayerShooting.Weapon.SHOTGUN;
            if (Input.GetKey("3")) playerShot.weapon = PlayerShooting.Weapon.RIFLE;
			if (Input.GetKey(KeyCode.Mouse1)) 
			{	
				throwForce += 0.18f;
				if (throwForce >= 30) throwForce = 30;
			}
			if (Input.GetKeyUp(KeyCode.Mouse1))
			{
				playerShot.ThrowGrenade(throwForce);
				throwForce = 15;
			}
        }
    }

	void FixedUpdate ()
	{
		// Store the input axes.
		float h = Input.GetAxisRaw ("Horizontal");
		float v = Input.GetAxisRaw ("Vertical");
		
		// Move the player around the scene.
		Move (h, v);
		
		// Turn the player to face the mouse cursor.
		Turning ();
		
		// Animate the player.
        if (h != 0 || v != 0)
        {
            playerStats.setRun();
        }
        else playerStats.setIddle();
		//Animating (h, v);
	}
	
	void Move (float h, float v)
	{
		// Set the movement vector based on the axis input.
		movement.Set (h, 0f, v);
		
		// Normalise the movement vector and make it proportional to the speed per second.
		movement = movement.normalized * speed * Time.deltaTime;
		
		// Move the player to it's current position plus the movement.
		playerRigidbody.MovePosition (transform.position + movement);
	}
	
	void Turning ()
	{
		// Create a ray from the mouse cursor on screen in the direction of the camera.
		Ray camRay = Camera.main.ScreenPointToRay (Input.mousePosition);
		
		// Create a RaycastHit variable to store information about what was hit by the ray.
		RaycastHit floorHit;
		
		// Perform the raycast and if it hits something on the floor layer...
		if(Physics.Raycast (camRay, out floorHit, camRayLength, floorMask))
		{
			// Create a vector from the player to the point on the floor the raycast from the mouse hit.
			Vector3 playerToMouse = floorHit.point - transform.position;
			
			// Ensure the vector is entirely along the floor plane.
			playerToMouse.y = 0f;
			
			// Create a quaternion (rotation) based on looking down the vector from the player to the mouse.
			Quaternion newRotation = Quaternion.LookRotation (playerToMouse);
			
			// Set the player's rotation to this new rotation.
			playerRigidbody.MoveRotation (newRotation);

		}
	}
	
	/*void Animating (float h, float v)
	{
		// Create a boolean that is true if either of the input axes is non-zero.
		bool walking = h != 0f || v != 0f;
		
		// Tell the animator whether or not the player is walking.
		anim.SetBool ("IsWalking", walking);
	}*/
}