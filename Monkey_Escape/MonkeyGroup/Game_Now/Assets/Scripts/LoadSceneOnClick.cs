using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class LoadSceneOnClick : MonoBehaviour {

	public void loadByIndex(int sceneIndex){

		SceneManager.LoadScene (sceneIndex);
	}
}
