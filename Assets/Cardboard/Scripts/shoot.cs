using UnityEngine;
using System.Collections;


public class shoot : MonoBehaviour {


	public Rigidbody projectile;


	//public Transform explosionPrefab;
	private GameObject hit;
	public float speed = 1700;
	//public Transform Bullet;
	public Transform Spawn;

	public AudioClip clip;

	private Rigidbody instantiatedProjectile;
	// Use this for initialization
	void Start () {
		//hit = GameObject.FindWithTag("Enemy");

	}
	
	// Update is called once per frame
	void Update () {
	
		//if (Input.GetButtonDown("fire1") || Input.GetKeyDown (KeyCode.Z))
		if ( Input.GetKeyDown (KeyCode.Z) ||Input.GetButtonUp("Fire1"))
		{
			Shot(false);
		}
        if (Input.GetKeyDown(KeyCode.M) || Input.GetButtonUp("Fire2"))
        {
            Shot(true);
        }
		if ( Input.GetKeyDown (KeyCode.X))
		{
			
			hit = UnityEngine.GameObject.Find("Nave");
			destroyEnemy();
		}


	}


	void destroyEnemy()
	{
		instantiatedProjectile = Instantiate(projectile,hit.transform.position,transform.rotation) as Rigidbody;
	}
	void Shot(bool type)
	{

		AudioSource.PlayClipAtPoint(clip, transform.position,0.5f);

		instantiatedProjectile = Instantiate(projectile,transform.position,transform.rotation) as Rigidbody;
		//instantiatedProjectile = Instantiate(projectile,hit.transform.position,transform.rotation) as Rigidbody;
		//instantiatedProjectile = Instantiate(projectile, Spawn.position, Spawn.rotation) as Rigidbody;
		//instantiatedProjectile.velocity = transform.TransformDirection(new Vector3(0, 0,speed));

		instantiatedProjectile.GetComponent<Rigidbody>().AddForce(transform.forward * speed *1000);
        instantiatedProjectile.GetComponent<shootDetect>().type = type;



        //Debug.Log("disparo");
        //instantiatedProjectile.velocity = transform.TransformDirection(new Vector3(0, 0,speed));
    }


}
