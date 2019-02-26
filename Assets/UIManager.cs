using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
