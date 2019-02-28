using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject loseScreen;
	public CanDie player;

    void Start(){
        
		player.isDead += PlayerDied;
    }
    
    void PlayerDied() {
        ShowLoseScreen();
	}

    void ShowLoseScreen() {
        loseScreen.SetActive(true);
    }
    public void RestartActiveScene(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
