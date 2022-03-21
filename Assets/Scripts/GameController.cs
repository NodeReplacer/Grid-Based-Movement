using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public List<Transform> turnQueue = new List<Transform>();
    public List<Transform> tiles = new List<Transform>();
    
    Ray TouchRay => Camera.main.ScreenPointToRay(Input.mousePosition);
    
    // Start is called before the first frame update
    void Start() {
        OnValidate();
    }
    
    void OnValidate() {
        
    }
    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            HandleClick();
        }
    }
    
    void HandleClick() {
        //Get the tile that was clicked on.
    }
}
