using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


namespace Complete
{
    public class GameManager : MonoBehaviour
    {
        public int m_NumRoundsToWin = 5;     
        public float m_StartDelay = 3f;      
        public float m_EndDelay = 3f;        
        public CameraControl m_CameraControl; 
        //public Text m_MessageText;
        //public Text mPoint;
        private int point;
        private int life ;
        public Text m_Life;                  
		public GameObject[] m_TankPrefabs;
        public TankManager[] m_Tanks;              
		public List<Transform> wayPointsForAI;
        
        private WaitForSeconds m_StartWait;         
        private WaitForSeconds m_EndWait;           
        private bool dead =false;
        public GameObject m_GameOverPanel;
        public GameObject m_WinGamePanel;
	    public void PlayAgainGameOver(string scenename)
        {
        ResetPlay();
		SceneManager.LoadScene(scenename);
		m_GameOverPanel.SetActive(false);
		Time.timeScale =1f;
	    }
        public void PlayAgainWinGame(string scenename){
        ResetPlay();
		SceneManager.LoadScene(scenename);
		m_WinGamePanel.SetActive(false);
		Time.timeScale =1f;
	    }
//
        // public int Point
        // {
        //     get{
        //         return this.point;
        //     }
        //     set{
        //          this.point = value;
        //     }
        // }
        //  public  int Life
        // {
        //     get{
        //         return this.life;
        //     }
        //     set{
        //          this.life = value;
        //     }
        // }
//
        private void Start()
        {
            m_GameOverPanel.SetActive(false);
            m_WinGamePanel.SetActive(false);
            life = TankHealth.lifeTank;
            m_StartWait = new WaitForSeconds (m_StartDelay);
            m_EndWait = new WaitForSeconds (m_EndDelay);
            
            SpawnAllTanks();
            SetCameraTargets();
        }

        void Update()
        {
            life = TankHealth.lifeTank;
            point = TankHealth.poin;
            if(IsPlayerDeath()){
                //ebug.Log("Your Life Decrease bye one and remain "+life);
                if(life>=0)
                {
                    Respawn();
                }else if(life<=0)
                {
                    life =0;
                  //Debug.Log("Game Over :"+life);
                    m_GameOverPanel.SetActive(true);
                    Time.timeScale =0f;
                }
            }
           //ebug.Log("Cek Player: "+ IsPlayerDeath());
            if(IsEnemyExist()){
             // Debug.Log("MAti Kabeh");
                Time.timeScale =0f;
                m_WinGamePanel.SetActive(true);
            }
            //mPoint.text = point+" ";
            m_Life.text = life+"";
        }


        private void SpawnAllTanks()
        {
			m_Tanks[0].m_Instance =
				Instantiate(m_TankPrefabs[0], m_Tanks[0].m_SpawnPoint.position, m_Tanks[0].m_SpawnPoint.rotation) as GameObject;
			m_Tanks[0].m_PlayerNumber = 1;
			m_Tanks[0].SetupPlayerTank();

            for (int i = 1; i < m_Tanks.Length; i++)
            {
                m_Tanks[i].m_Instance =
					Instantiate(m_TankPrefabs[i], m_Tanks[i].m_SpawnPoint.position, m_Tanks[i].m_SpawnPoint.rotation) as GameObject;
                m_Tanks[i].m_PlayerNumber = i + 1;
				m_Tanks[i].SetupAI(wayPointsForAI);
            }
        }

        private void SetCameraTargets()
        {
            Transform[] targets = new Transform[m_Tanks.Length];
            for (int i = 0; i < targets.Length; i++)
            {
                targets[i] = m_Tanks[i].m_Instance.transform;
            }
            m_CameraControl.m_Targets = targets;
        }

        private bool IsEnemyExist(){
        int numTanksLeft = 0;

        for (int i = 1; i < m_Tanks.Length; i++)
        {
            if (m_Tanks[i].m_Instance.activeSelf && m_Tanks[i].m_Instance.transform.CompareTag("Enemy")){
                //bug.Log("Test");
                 numTanksLeft++;
            }
               
        }
        return numTanksLeft <= 0;
        }
        public bool IsPlayerDeath(){
             dead =TankHealth.isPlayerDead;
             return dead;
        }

        private void Respawn(){
            m_Tanks[0].m_Instance.SetActive(true);
             m_Tanks[0].EnableControl();
        }

        private void Death(){
            Debug.Log("You Death");
            Application.LoadLevel("Prortoype");
        }


        private void ResetAllTanks()
        {
            for (int i = 0; i < m_Tanks.Length; i++)
            {
                m_Tanks[i].Reset();
            }
        }

        private void ResetPlay()
        {
            Time.timeScale =1f;
            ResetAllTanks ();
            EnableTankControl();
             m_CameraControl.SetStartPositionAndSize ();
        }
        private void EnableTankControl()
        {
            for (int i = 0; i < m_Tanks.Length; i++)
            {
                m_Tanks[i].EnableControl();
            }
        }


        private void DisableTankControl()
        {
            for (int i = 0; i < m_Tanks.Length; i++)
            {
                m_Tanks[i].DisableControl();
            }
        }
    }
}