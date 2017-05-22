using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;


//Spawn prefabs

public class GroundManager : MonoBehaviour {





	public GameObject[] prefabs;
	// Use this for initialization

	private Transform playerTransform;
	private float spanZ = -5.0f;
	private float tileLength = 10.0f;
    private float safeZone = 15.0f;
	private int tilesOnScreen = 7;
    private int lastPrefab = 0;

    private List<GameObject> activeTiles;    


	void Start () {
		playerTransform = GameObject.FindGameObjectWithTag ("Player").transform;
        activeTiles = new List<GameObject>();


		//Spawn Empty tiles if at the beginning
        for (int i = 0; i < tilesOnScreen; i++) {
            if (i < 4)
            {
                SpawnTile(0);
            }
            else {
                SpawnTile ();
            }
			
          
		}
		
	}
	
	// Update is called once per frame


	//If player is infront spawn tiles
	void Update () {
		if (playerTransform.position.z - safeZone> (spanZ - tilesOnScreen * tileLength)) {
		
			SpawnTile ();
            DeleteTile();
		}
	}
		
	private void SpawnTile(int prefabIndex = -1){

		GameObject go;
        if (prefabIndex == -1)
        {
            go = Instantiate(prefabs[RandomPrefabIndex()]) as GameObject;
        }

        else {
            go = Instantiate(prefabs[prefabIndex]) as GameObject;
        }
		go.transform.SetParent (transform);
		go.transform.position = Vector3.forward * spanZ;
		spanZ += tileLength;
        activeTiles.Add(go);
		
	}


	//DeleteLastTile

    private void DeleteTile() {

        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }

    private int RandomPrefabIndex() {
        if (prefabs.Length <= 1) {
            return 0;
        }

        int randomIndex = lastPrefab;
        while (randomIndex == lastPrefab) {
            randomIndex = Random.Range(0, prefabs.Length);
        }

        lastPrefab = randomIndex;
        return randomIndex;
    }
}
