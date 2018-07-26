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

        if (indexLevel < 1) indexLevel = 1;
        if (indexLevel > 10) indexLevel = 10;
        for (int i =1; i<11; i++)
        {
            if(indexLevel == i)
            {
                stage.transform.GetChild(i).gameObject.SetActive(true);
            }
            else
            {
                stage.transform.GetChild(i).gameObject.SetActive(false);
            }

        }
		
	}
	
	public void NextLevel()
	{
		indexLevel++;
	}
	public void PreviousLevel()
	{
		indexLevel--;
    }


	public void Back(string scenename){
		SceneManager.LoadScene(scenename);
	}

	
	
}
