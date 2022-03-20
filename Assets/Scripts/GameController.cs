using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public List<Transform> turnQueue = new List<Transform>();
    public List<Transform> tiles = new List<Transform>();
    
    
    // Start is called before the first frame update
    void Start() {
        OnValidate();
    }
    
    void OnValidate() {
        
    }
    // Update is called once per frame
    void Update() {
        
    }
}
