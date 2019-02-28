using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CompanySceneManager : MonoBehaviour {

 	public Image fadeScreenIMG;
	public float fadeDuration = 2.0f;
	public float showLogoDuration = 2.0f;
	public string nextSceneName = "Title";

	void Start() {
		StartCoroutine ("ShowLogoAndGotoScene");
	}
	IEnumerator ShowLogoAndGotoScene() {
		StartCoroutine (FadeImage (true));
		yield return new WaitForSeconds (showLogoDuration + fadeDuration);
		StartCoroutine (FadeImage (false));
		yield return new WaitForSeconds (fadeDuration);
		SceneManager.LoadScene (nextSceneName);
	}

	IEnumerator FadeImage(bool fadeAway){
		if (fadeAway) {
			//Image Disappears 
			for (float i = fadeDuration; i>=0; i-= Time.deltaTime){
				fadeScreenIMG.color = new Color (0, 0, 0, i);
				yield return null;
			}
		} else {
			//Image Appears 
			for (float i = 0; i<=fadeDuration; i+= Time.deltaTime){
				fadeScreenIMG.color = new Color (0, 0, 0, i);
				yield return null;
			}
		}
	}
}
