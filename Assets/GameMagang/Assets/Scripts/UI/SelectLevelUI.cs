using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectLevelUI : MonoBehaviour {

	private int indexLevel=1;
	public GameObject stage;
	void Start () {
		indexLevel =1;
    
	}

	private void Update() {
		switch (indexLevel)
		{
			case 1:
				stage.transform.GetChild(1).gameObject.SetActive(true);
				stage.transform.GetChild(2).gameObject.SetActive(false);
				stage.transform.GetChild(3).gameObject.SetActive(false);
				stage.transform.GetChild(4).gameObject.SetActive(false);
				stage.transform.GetChild(5).gameObject.SetActive(false);
			break;
			case 2:
				stage.transform.GetChild(2).gameObject.SetActive(true);
				stage.transform.GetChild(1).gameObject.SetActive(false);
				stage.transform.GetChild(3).gameObject.SetActive(false);
				stage.transform.GetChild(4).gameObject.SetActive(false);
				stage.transform.GetChild(5).gameObject.SetActive(false);
			break;
			case 3:
				stage.transform.GetChild(3).gameObject.SetActive(true);
				stage.transform.GetChild(2).gameObject.SetActive(false);
				stage.transform.GetChild(1).gameObject.SetActive(false);
				stage.transform.GetChild(4).gameObject.SetActive(false);
				stage.transform.GetChild(5).gameObject.SetActive(false);
			break;
			case 4:
				stage.transform.GetChild(4).gameObject.SetActive(true);
				stage.transform.GetChild(2).gameObject.SetActive(false);
				stage.transform.GetChild(3).gameObject.SetActive(false);
				stage.transform.GetChild(1).gameObject.SetActive(false);
				stage.transform.GetChild(5).gameObject.SetActive(false);
			break;
			case 5:
				stage.transform.GetChild(5).gameObject.SetActive(true);
				stage.transform.GetChild(2).gameObject.SetActive(false);
				stage.transform.GetChild(3).gameObject.SetActive(false);
				stage.transform.GetChild(4).gameObject.SetActive(false);
				stage.transform.GetChild(1).gameObject.SetActive(false);
			break;
		}
	}
	
	public void NextLevel()
	{
		indexLevel++;
		//stage.transform.GetChild(indexLevel).gameObject.SetActive(true);
	}
	public void PreviousLevel()
	{
		indexLevel--;
		//stage.transform.GetChild(indexLevel).gameObject.SetActive(true);
	}


	public void Back(string scenename){
		SceneManager.LoadScene(scenename);
	}

	
	
}
