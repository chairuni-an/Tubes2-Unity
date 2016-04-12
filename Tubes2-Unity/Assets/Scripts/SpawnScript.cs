using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour {
	public GameObject obstacleMengulang;
	public GameObject powerupIP;
	public GameObject obstaclePelanggaran1;
	public GameObject obstaclePelanggaran2;
	public GameObject powerupPrestasi;
	
	float timeElapsed = 0;
	float spawnCycle = 0.8f;
	int rand;
	//bool spawnPowerup = true;
	
	void Update () {
		rand = Random.Range(1,5);
		//rand = 3;
		timeElapsed += Time.deltaTime;
		if(timeElapsed > spawnCycle)
		{
			GameObject temp;
			Vector3 pos;
			switch (rand) {
			case 1: 
				temp = (GameObject)Instantiate(obstacleMengulang);
				pos = temp.transform.position;
				temp.transform.position = new Vector3(0, pos.y, pos.z);
				break;
			case 2:
				temp = (GameObject)Instantiate(powerupIP);
				pos = temp.transform.position;
				temp.transform.position = new Vector3(Random.Range(-3, 4), pos.y, pos.z);
				break;
			case 3:
				float rand2 = Random.Range(-10.5f, -2.0f);
				temp = (GameObject)Instantiate(obstaclePelanggaran1);
				pos = temp.transform.position;
				temp.transform.position = new Vector3(rand2, pos.y, pos.z);

				temp = (GameObject)Instantiate(obstaclePelanggaran2);
				pos = temp.transform.position;
				temp.transform.position = new Vector3(rand2 + 12.5f, pos.y, pos.z);
				break;
			case 4:
				temp = (GameObject)Instantiate(powerupIP);
				pos = temp.transform.position;
				temp.transform.position = new Vector3(Random.Range(-3, 4), pos.y, pos.z);
				temp = (GameObject)Instantiate(powerupPrestasi);
				pos = temp.transform.position;
				temp.transform.position = new Vector3(Random.Range(-3, 4), pos.y, pos.z);
				break;
			default:
				break;
			}
			
			timeElapsed -= spawnCycle;
		}
	}
}
