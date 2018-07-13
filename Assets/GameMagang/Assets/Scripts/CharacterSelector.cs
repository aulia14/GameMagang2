using UnityEngine;
using UnityEngine.SceneManagement;
public class CharacterSelector : MonoBehaviour {

	private GameObject[] characterList;
	private int index;
	private int characterIndex=0;
	private void Start() {

		PlayerPrefs.GetInt("CharacterSelected");
		characterList = new GameObject[transform.childCount];
		for(int i=0;i<transform.childCount;i++)
			characterList[i] = transform.GetChild(i).gameObject;
		foreach (GameObject t in characterList) t.SetActive(false);
		if(characterIndex==0) characterList[0].SetActive(true);
		if(index.Equals( characterList[0])){
			characterIndex=0;
			characterList[0].SetActive(true);
			characterList[1].SetActive(false);
		} 
		else if(index.Equals( characterList[1]) )
		{
			characterList[0].SetActive(false);
			characterList[1].SetActive(true);
		}
	}
	private void Update() {

	}
	public void ToggleLeft()
	{
		characterList[index].SetActive(false);
		index--;
		if(index<0) index = characterList.Length-1;
		characterList[index].SetActive(true);
	}
	public void ToggleRight()
	{
		characterList[index].SetActive(false);
		index++;
		if(index==characterList.Length) index = 0;
		characterList[index].SetActive(true);
	}
	public void Pilih()
	{
		PlayerPrefs.SetInt("CharacterSelected",index);
		Debug.Log("Character Selected"+index);
		SceneManager.LoadScene("Single_Player");
	}
	
}
