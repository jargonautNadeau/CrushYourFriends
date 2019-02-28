using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    public GameObject gridBlockParent;
    public int numTargetBlocks = 5;
    public float blockFadeSpeed = 4.0f;
    public float blockHiddenTime = 6.0f;
    public float extraTimePerRound = 1.5f;
    public Color startColor = Color.white;
    public Color fadeColor = Color.black;

    public GameObject playerPrefab;
    public GameObject cameraPrefab;
    void Start()
    {
        LevelManager levelMan = gameObject.GetComponent<LevelManager>();
        levelMan.Build3DGrid();
        StartCoroutine(StartRounds());
    }

    // Update is called once per frame
    IEnumerator StartRounds(){
        while(GetNumPlayersAlive() > 0){
            List<GameObject> targets = SelectTargetBlocks(numTargetBlocks);
            StartCoroutine(FadeBlock(targets));
            yield return new WaitForSeconds((blockFadeSpeed*2)+blockHiddenTime+extraTimePerRound);
            numTargetBlocks = Mathf.Clamp(numTargetBlocks + 5, 0, GetTotalBlocks());
        }
    }
    IEnumerator FadeBlock(List<GameObject> targetList) {
        for (float f = blockFadeSpeed; f >= 0; f -= 0.1f) 
        {
            foreach(GameObject gobj in targetList) {
                Color newColor = Color.Lerp(fadeColor,startColor,f/blockFadeSpeed);
                gobj.GetComponent<Renderer>().material.color = newColor;
            }
            yield return new WaitForSeconds(.1f);
        }
        foreach(GameObject gobj in targetList) {
            gobj.GetComponent<BoxCollider>().enabled = false;
        }
        yield return new WaitForSeconds(blockHiddenTime);
        for (float f = 0; f <= blockFadeSpeed; f += 0.1f) 
        {
            foreach(GameObject gobj in targetList) {
                Color newColor = Color.Lerp(fadeColor,startColor,f/blockFadeSpeed);
                gobj.GetComponent<Renderer>().material.color = newColor;
            }
            yield return new WaitForSeconds(.1f);
        }
        foreach(GameObject gobj in targetList) {
            gobj.GetComponent<BoxCollider>().enabled = true;
        }
    }
    private List<GameObject> SelectTargetBlocks(int numTargets){
        List<GameObject> targetArray = new List<GameObject>();
        List<int> alreadySelected = new List<int>();
        for (int i=0; i<numTargets; i++) {
            int selectedTargetIndex = Random.Range (0, GetTotalBlocks());
            //While selectedTargetID has already been selected
            while(alreadySelected.Contains(selectedTargetIndex)){
                selectedTargetIndex = Random.Range (0, GetTotalBlocks());
            }
            alreadySelected.Add(selectedTargetIndex);
            targetArray.Add(gridBlockParent.transform.GetChild(selectedTargetIndex).gameObject);
        }
        return targetArray;
    }
    private void increaseTargetBlock(int addingValue){
        this.numTargetBlocks += addingValue;
        Mathf.Clamp(numTargetBlocks,0,GetTotalBlocks());
    }
    private int GetTotalBlocks(){
        return gridBlockParent.transform.childCount;
    }
    private int GetNumPlayersAlive() {
        GameObject[] playerList = GameObject.FindGameObjectsWithTag("Player");
        return playerList.Length;
    }
}
