using UnityEngine;
using System.Collections;

public class EnemyFly : MonoBehaviour {

	public float speed;
	public float rotateDamp;
	public float acceleration = 20.0F;
	public float minimumSpeed = 30.0F;
	public float maximumSpeed = 100.0F;
	public float bufferRange = 25.0F;
	
	private bool slowDown;
	private bool keepSpeed;
	private bool speedUp;
	
	public string enemy;
	public string route;
	private int routeNodes =4;
	
	public float sightRange = 150.0F;
	public float attackRange = 75.0F;
	public GameObject bullet;
	public float fireRate = 0.09F;
	public int rounds = 10000;
	//private AudioSource shotSoundSource;
	//public AudioClip shotSound;
	private float nextFire = 0.0F;
	private bool canFire;
	private bool hasTarget = false;
	private Transform SP1;
	private Transform SP2;
	private Transform target;
	private RaycastHit hit;
	private float distance;
	private int routePosition = 1;
	
	//private Transform centerOfMap;
	
	private Transform plane;
	
	void Awake () {
		
		plane = transform;
		SP1 = plane.Find("Nave");
		SP2 = plane.Find(enemy);
		//
		FindTarget();

		//centerOfMap = GameObject.Find("Enemy").transform;
	}


	
	void Start () {
		
		//target = GameObject.FindWithTag("cabeza").transform;
		hasTarget = true;

		routeNodes = GameObject.Find ("Recorrido").transform.childCount;
		//if(!centerOfMap){
		//	centerOfMap = RespawnInfo.centerOfMapD;
		//}
		//shotSoundSource = GetComponent<AudioSource>();

	}
	
	void Update () {


		Physics.Raycast(plane.position, Vector3.forward, out hit, sightRange);
		Physics.Raycast(plane.position, Vector3.forward, out hit, attackRange);
		plane.Translate(Vector3.forward * speed * Time.deltaTime);
		distance = Vector3.Distance(target.transform.position, plane.position);
		
		if(!hasTarget){
			FindTarget();
		}
		else if(hasTarget){
			var rotate = Quaternion.LookRotation(target.position - plane.position);
			plane.rotation = Quaternion.Slerp(plane.rotation, rotate, Time.deltaTime * rotateDamp);
			//Shoot();
		
		}
		
		/*if(hit.collider.CompareTag(enemy)){
			Shoot();
		}*/
		
		if(distance <= sightRange && distance > attackRange){
			speed += acceleration;
			speed = Mathf.Clamp(speed, minimumSpeed, maximumSpeed);
		}
		else if(distance <= bufferRange){
		//	PaperPlaneAI other = target.GetComponent<PaperPlaneAI>();
		//	float targetSpeed = other.speed;
			float targetSpeed = 0;
			if(targetSpeed < speed){
				speed -= acceleration;
				speed = Mathf.Clamp(speed, targetSpeed, maximumSpeed);
			}
			else if(targetSpeed > speed){
				speed += acceleration;
				speed = Mathf.Clamp(speed, minimumSpeed, targetSpeed);
			}
			if (routePosition<routeNodes){
			    routePosition++;
			} else {
				routePosition=1;
			}
			FindTarget();
		}
		
		/*float previousX = 0;
		float previousZ = 0;
		//if (plane.position.z == 0)
		previousX = plane.position.x;
		previousZ = plane.position.z;
		Vector3 newPosition = plane.position;
		if (plane.position.y < 60){
			
			newPosition.x = previousX;
			newPosition.z = previousZ;
			newPosition.y = plane.position.z+1;
			plane.position = newPosition;
		} else if (plane.position.y >90)
		{

			newPosition.x = previousX;
			newPosition.z = previousZ;
			newPosition.y = plane.position.z-1;
			plane.position = newPosition;
		}*/

	}
	
	void Shoot () {
		
		canFire = rounds > 0;
		
		if(Time.time > nextFire && canFire){
			nextFire = Time.time + fireRate;
			//Instantiate(bullet, SP1.position, SP1.rotation);
			//Instantiate(bullet, SP2.position, SP2.rotation);
			rounds--;
			//shotSoundSource.PlayOneShot(shotSound,1);
			Debug.Log("Shooting");
		}
	}
	
	void FindTarget () {
		
		//target = GameObject.FindWithTag(enemy).transform;
		Debug.Log("Shooting"+route + routePosition.ToString("D3"));
		target = GameObject.Find(route + routePosition.ToString("D3")).transform;
		hasTarget = distance <= sightRange;
		
		//if(!centerOfMap){
			//centerOfMap = RespawnInfo.centerOfMapD;
		//}
		

	}
}
