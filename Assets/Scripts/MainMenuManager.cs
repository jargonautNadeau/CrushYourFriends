using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
	public void QuitApplication() {
		Application.Quit ();
	}
	public void BackToMainMenu() {
		SceneManager.LoadScene ("Title");
	}
	public void PlayGame(){
		SceneManager.LoadScene ("GameScene");
	}
	public void RestartGame() {
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}
}
