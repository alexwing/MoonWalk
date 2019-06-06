using UnityEngine;
using System.Collections;

public class EnemysCreator : MonoBehaviour
{
	public GameObject enemy;
	public int enemyNumber = 5;
	public float posX = 0.0f;
	public float posZ = 500.0f;

	public float HorizontalDistance = 24.0f;
	public float VerticalDistance = 24.0f;
	// Use this for initialization
	private GameObject[,] values;
	private int routePosition =1;
	private int routeNodes =4;
    System.Array valuesCode = System.Enum.GetValues(typeof(KeyCode));

    void Start ()
	{

		routeNodes = GameObject.Find ("Recorrido").transform.childCount;
		routePosition=1;

		values = new GameObject[(int)(enemyNumber ), (int)(enemyNumber)];
		StartCoroutine(createEnemys());

	}

	IEnumerator  createEnemys(){

		//float center = posX + (enemyNumber * HorizontalDistance) / 2;
		for (int i = 0; i < enemyNumber; i++) {
			for (int j = 0; j < enemyNumber; j++) {
				values [i, j] = Instantiate (enemy);
				values [i, j].name = "Nave";
				//values [i, j].tag = "Nave"+i+"_"+j;
				//values [i, j].transform.position = new Vector3 (center - (i * HorizontalDistance), 50, posZ - (j * HorizontalDistance));
				//values [i, j].transform.position = GameObject.Find("Waypoint " + routePosition.ToString("D3")).transform.position;
				//Vector3  aux = GameObject.Find("Waypoint " + 1.ToString("D3")).transform.position;
				//aux.y = 260*(i+j);
				
				//values [i, j].transform.position = aux;
				if (routePosition<routeNodes){
					routePosition++;
				} else {
					routePosition=1;
				}
				yield return new WaitForSeconds(1.5f);
				

				//values[i].GetComponent<MeshRenderer>().enabled = false;
			}
		}
	}

	// Update is called once per frame
	void Update ()
	{
        /*for (int i = 0; i < enemyNumber; i++) {
			for (int j = 0; j < enemyNumber; j++) {
				if (values [i, j]) {
					//values [i, j].transform.Translate (Vector3.forward * Time.deltaTime * 15);
				}
			}
		}*/

        /*if (Input.GetKeyDown (KeyCode.X)) {

			destroyEnemys();
			Start ();
		}*/

        foreach (KeyCode code in valuesCode)
        {
            if (Input.GetKeyDown(code))
            {
                if (System.Enum.GetName(typeof(KeyCode), code) == "Left Bumper")
                {
                    destroyEnemys();
                    if (enemyNumber>1)
                    enemyNumber--;
                    Start();
                }
                if (System.Enum.GetName(typeof(KeyCode), code) == "Joystick1Button7")
                {
                    destroyEnemys();
                    enemyNumber++;
                    Start();
                }
            }
        }
        if (Input.GetKeyDown (KeyCode.KeypadMinus)||Input.GetKeyDown (KeyCode.C)) {
			destroyEnemys();
			enemyNumber--;
			Start ();
		}

		if (Input.GetKeyDown (KeyCode.KeypadPlus)||Input.GetKeyDown (KeyCode.V)) {
			destroyEnemys();
			enemyNumber++;
			Start ();
		}
	}

	void destroyEnemys(){
		for (int i = 0; i < enemyNumber; i++) {
			for (int j = 0; j < enemyNumber; j++) {
				if (values [i, j]) {
					Destroy (values [i, j]);
				}
			}
		}
	}
}
