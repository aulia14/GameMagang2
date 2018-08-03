using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SceneTute
{
	public class GameScene : MonoBehaviour {

		public LoadSceneMode loadMode = LoadSceneMode.Single;

		public void LoadScene (string sceneName)
		{
			SceneManager.LoadScene (sceneName, loadMode);
		}

		public void LoadScene (int sceneIndex)
		{
			SceneManager.LoadScene (sceneIndex, loadMode);
		}
	}

}
