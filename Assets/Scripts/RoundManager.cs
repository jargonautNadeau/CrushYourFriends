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
    public float dropdistance = 10.0f;
    public GameObject crushingBrick;
    public GameObject playerPrefab;
    public GameObject cameraPrefab;
    public GameObject gridParent;
    public Vector3 respawnLoc = new Vector3(3,1,10);
    private GameObject[] playerss;
    void Start()
    {
        playerss = GameObject.FindGameObjectsWithTag("Player");
        LevelManager levelMan = gameObject.GetComponent<LevelManager>();
        levelMan.Build3DGrid();
        StartCoroutine(StartRounds());
    }

    // Update is called once per frame
    IEnumerator StartRounds(){
        while(GetPlayersAlive().Count > 0){
            List<GameObject> targets = SelectTargetBlocks(numTargetBlocks);
            //StartCoroutine(FadeBlock(targets));
            StartCoroutine(DropBlock(targets));
            yield return new WaitForSeconds((blockFadeSpeed*2)+blockHiddenTime+extraTimePerRound);
            ClearCrushingBlocks();
            RespawnPlayers();
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
        yield return new WaitForSeconds(blockHiddenTime);
        for (float f = 0; f <= blockFadeSpeed; f += 0.1f) 
        {
            foreach(GameObject gobj in targetList) {
                Color newColor = Color.Lerp(fadeColor,startColor,f/blockFadeSpeed);
                gobj.GetComponent<Renderer>().material.color = newColor;
            }
            yield return new WaitForSeconds(.1f);
        }
    }
    IEnumerator DropBlock(List<GameObject> targetList){
        foreach(GameObject gobj in targetList) {
            GameObject brickToDrop = Instantiate(crushingBrick,gobj.transform.position + (Vector3.up *dropdistance),Quaternion.identity);
            brickToDrop.transform.parent = gridParent.transform;
            brickToDrop.name = "Crushing_"+gobj.name;
        }
        yield return null;
    }
    private void ClearCrushingBlocks(){
        foreach(GameObject obstacle in GameObject.FindGameObjectsWithTag("Obstacles")) {
            Destroy(obstacle);
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
    private List<GameObject> GetPlayersAlive() {
        List<GameObject> playerList = new List<GameObject>();
        foreach(GameObject player in playerss){
            if(player.GetComponent<CanDie>().numLives > 0) {
                playerList.Add(player);
            }
        }
        return playerList;
    }
    private void RespawnPlayers(){
        
        foreach(GameObject player in GetPlayersAlive()){
            if(!player.activeSelf){
                Debug.Log("RespawnLocation: "+respawnLoc);
                player.GetComponent<CanDie>().RespawnPlayer(respawnLoc);
            }
        }
            
    }

}
