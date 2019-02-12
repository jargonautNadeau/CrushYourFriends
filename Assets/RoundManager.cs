using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    public GameObject gridBlockParent;
    public int numTargetBlocks = 5;
    // Start is called before the first frame update
    void Start()
    {
        List<GameObject> targets = SelectTargetBlocks(numTargetBlocks);
        foreach(GameObject gobj in targets){
            gobj.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private List<GameObject> SelectTargetBlocks(int numTargets){
        List<GameObject> targetArray = new List<GameObject>();
        List<int> alreadySelected = new List<int>();
        for (int i=0; i<numTargets; i++) {
            int selectedTargetIndex = Random.Range (0, GetTotalBlocks());
            //While selectedTargetID has already been selected
            while(alreadySelected.Contains(selectedTargetIndex)){
                selectedTargetIndex = Random.Range (0, GetTotalBlocks());
                alreadySelected.Add(selectedTargetIndex);
            }
            Debug.Log("selectedTargetIndex: "+selectedTargetIndex);
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
}
