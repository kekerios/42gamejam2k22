using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
	private GameObject pausePanel;
	private GameObject deadPanel; 
	private bool isPaused;
	private bool isDead;

	// Start is called before the first frame update
    void Start()
    {
		pausePanel = GameObject.FindGameObjectWithTag("pausePanel");
		deadPanel = GameObject.FindGameObjectWithTag("DeadPanel");
		pausePanel.SetActive(false);
		deadPanel.SetActive(false);
		isPaused = false;
		isDead = false;
	}

    // Update is called once per frame
    void Update()
    {
			
	}

	public void ShowPauseMenu()
	{
		if (!isPaused && !isDead)
		{
			pausePanel.SetActive(true);
			isPaused = true;
		}
		else
		{
			pausePanel.SetActive(false);
			isPaused = false;
		}
	}
	public void LoadMainMenu()
	{
		SceneManager.LoadScene("mainMenu");
	}
	
	public void RestartGame()
	{
		SceneManager.LoadScene("SampleScene");
	}
	
	public void QuitGame()
	{
		Application.Quit();
	}
	public void Die()
    {
		deadPanel.SetActive(true);
		isDead = true;
    }
}
