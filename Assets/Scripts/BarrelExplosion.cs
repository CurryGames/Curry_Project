using UnityEngine;
using System.Collections;

public class BarrelExplosion : MonoBehaviour {

	public string button = "Fire1";
	public float radius = 5.0F;
	public float power = 10.0F;
	public float upwardModifier = 0.0f;
	public ForceMode forceMode;
	void Start() {
		}

	void Update(){
		if (Input.GetButtonDown(button)){
		foreach (Collider col in Physics.OverlapSphere( transform.position, radius))
		{
			if (col.rigidbody != null)
			{
				col.rigidbody.AddExplosionForce(power, transform.position, radius, upwardModifier,forceMode);
					Debug.Log("booooooooommmm");
			}

			}

		}

	}

	}





