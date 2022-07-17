using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTile : MonoBehaviour
{
    [SerializeField]
    string tileType = default; //Should probably make a list in a library somewhere else.
    [SerializeField]
    float probeDistance = 4f; //Remember that each tile up is 0.25 so 1 y vector has 4 tiles up.
    public Transform northTile = null, southTile = null, eastTile = null, westTile = null;
    public float tileHeight = default;
    public List<Transform> neighbours = new List<Transform>();
    public bool moveAvailable;
    public int distance; //The distance from wherever our origin tile is. 
    //This will get overwriten a lot, despite being public.
    
    public Transform root = null; //This holds another tile. The one we got from GenerateAvailableMovements.
    //It's significance is that we'll use these roots to pathfind from place to place.
    //We won't freestyle the motion of this.
    
    // Start is called before the first frame update
    void Awake() {
        //Tiles move, but we STILL don't need to send raycasts out every update frame.
        tileHeight = transform.position.y *4;
        moveAvailable = false;
        distance = 0;
        GetNeighbours();
        UpdateIndicator();
    }
    
    //
    
    // Update is called once per frame
    void Update() {
        
    }
    //Called every physics step frame.
    void FixedUpdate() {
        
    }
    
    //This may not be the best tile work, it may be that the player character will also need
    //to get its last occupied tile to handle particularly long falls.
    void GetNeighbours(){
        Transform currentChild;
        for (int i=0;i<this.gameObject.transform.childCount;++i) {
            currentChild = this.gameObject.transform.GetChild(i);
            if (currentChild.name != "ActualTile") {
                /*
                if (Physics.Raycast(currentChild.position,Vector3.up, out RaycastHit hit, probeDistance)) {
                    
                }
                */
                
                //We might need the direction in case we allow "pushing" attacks.
                if (currentChild.name == "North") {
                    if (Physics.Raycast(currentChild.position,Vector3.up, out RaycastHit hit, probeDistance)) {
                        northTile = hit.transform.parent;
                        neighbours.Add(hit.transform.parent);
                    }
                }
                else if (currentChild.name == "South") {
                    if (Physics.Raycast(currentChild.position,Vector3.up, out RaycastHit hit, probeDistance)) {
                        southTile = hit.transform.parent;
                        neighbours.Add(hit.transform.parent);
                    }
                }
                else if (currentChild.name == "East") {
                    if (Physics.Raycast(currentChild.position,Vector3.up, out RaycastHit hit, probeDistance)) {
                        eastTile = hit.transform.parent;
                        neighbours.Add(hit.transform.parent);
                    }
                }
                else if (currentChild.name == "West") {
                    if (Physics.Raycast(currentChild.position,Vector3.up, out RaycastHit hit, probeDistance)) {
                        westTile = hit.transform.parent;
                        neighbours.Add(hit.transform.parent);
                    }
                }
                
            }
        }
    }
    void UpdateIndicator() {
        for (int i=0;i<this.gameObject.transform.childCount;++i) {
            GameObject currentChild = this.gameObject.transform.GetChild(i).gameObject;
            if (currentChild.name == "mvIndicator") {
                //We have received mvIndicator and now need to hide it.
                
                
                //currentChild.GetComponent<Renderer>().enabled = moveAvailable;
                currentChild.SetActive(moveAvailable);
            }
        }
    }
}
