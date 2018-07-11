using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MoveSceneTank : MonoBehaviour {

	public string namaScene;

	public void MovetoScene(){

		Scene sceneIni = SceneManager.GetActiveScene();

		if(sceneIni.name != namaScene){
			SceneManager.LoadScene (namaScene);
		}
	}

	public void Quit()
	{
		Application.Quit ();
	}
}