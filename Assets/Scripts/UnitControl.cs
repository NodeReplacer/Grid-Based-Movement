using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitControl : MonoBehaviour
{
    [SerializeField, Range(0f, 100f)]
	float maxMoveSpeed = 10f;
    [SerializeField, Range(0f,100f)]
    float maxAcceleration = 10f;
    [SerializeField, Range(0f,90f)]
    float maxGroundAngle = 25f;
    [SerializeField, Range(0f,99f)]
    public int moveRange = 4;
    public float jumpHeight = 3;
    
    bool isFalling = false; 
    bool isJumping = false;
    Rigidbody body;
    Vector3 playerInput;
    Transform previousTile, currentTile, destinationTile, originTile;
    float minGroundDotProduct;
    public List<Transform> availableMovements = new List<Transform>();
    
    void Awake() {
        body = GetComponent<Rigidbody>();
        body.useGravity = false;
        
        //For now, we will make the pawn immediately display its possible movement range.
        
        OnValidate();
    }
    void OnValidate() {
        minGroundDotProduct = Mathf.Cos(maxGroundAngle * Mathf.Deg2Rad);
    }
    
    void OnCollisionEnter (Collision collision) {
        Debug.Log("New Collision");
        EvaluateCollision(collision);
    }
    void OnCollisionStay (Collision collision) {
        //EvaluateCollision(collision);
    }
    void OnCollisionExit (Collision collision) {
        
    }
    void EvaluateCollision(Collision collision) {
        //Right now we are just searching for the ground.
        for (int i=0;i<collision.contactCount;++i) {
            Vector3 normal = collision.GetContact(i).normal;
            if (normal.y >= minGroundDotProduct) {
                //Debug.Log("Received Normal Vector "+ normal+" from "+collision.);
                currentTile = collision.transform.parent;
                Debug.Log("BALL'S CURRENT TILE = " + currentTile);
                isFalling = false;
            }
            else {
                Debug.Log("We touched: "+collision.transform.parent);
                Debug.Log("Not Facing Up Normal = " + normal);
            }
        }
        isFalling = true;
    }
    
    // Update is called once per frame
    void Update() {
        
    }
    
    void FixedUpdate() {
        UnitMovement();
    }
    
    void GoToTile(Transform currentTile, Transform destinationTile) {
        //I suppose we need four objects then.
        //Our destination tile, our originTile, our currentTile, and our previousTile.
        //Maybe a list of Tiles that this thing will operate over would be better.
        
    }
    
    void UnitMovement() {
        //Now we'll try to move while respecting the grid.
        //Physics.Raycast(body.position,-Vector3.up, out RaycastHit hit, probeDistance);
        
        //Get current tile
        //we now have a list of tiles connected to our current tile.
        //after that we can just get the position of a specified tile and move towards that position + 0.5 
        //to the y vector. Movetowards can work.
        
        //Fixing the error may not be necessary because we don't control like that. It might be better
        //to do the "show possible movement positions" idea then pathfind towards the appropriate location
        //instead of prototyping movement with the key because a keypress happens like a hundred times for
        //each single time I think I'm pressing it.
        
        //UnitMovement(currentTile, destinationTile)
        //and work on that sort of pathfinding algo instead.
        
        //Figure out how to highlight our available tiles.
        
        playerInput.x = Input.GetAxis("Horizontal");
        playerInput.z = Input.GetAxis("Vertical");
        
        //With the removal of TileLogic.eastTile using the below code is dangerous.
        //We'll need to rely on mouse clicking on available movements to move now.
        
        /*
        float maxSpeedChange = maxAcceleration * Time.deltaTime;
        Transform nextTile;
        if (playerInput.x > 0) {
            //Debug.Log("Right pressed");
            //Debug.Log("currentTile = "+currentTile);
            //There must be
            nextTile = currentTile.gameObject.GetComponent<TileLogic>().eastTile;
            if (nextTile == null) {
                //Nothing's there.
                Debug.Log("INVALID MOVE");
                
                transform.localPosition = Vector3.MoveTowards(transform.localPosition,
                currentTile.position + new Vector3(0,0.5f,0),
                maxSpeedChange);
                
                return;
            }
            transform.localPosition = Vector3.MoveTowards(transform.localPosition,
            nextTile.position + new Vector3(0,0.5f,0),
            maxSpeedChange);
            
            previousTile = currentTile;
        }
        if (playerInput.x < 0) {
            Debug.Log("Left pressed");
        }
        if (playerInput.z > 0) {
            Debug.Log("Forward Pressed");
        }
        if (playerInput.z < 0) {
            Debug.Log("Back Pressed");
        }
        */
        
        /*
        Vector3 velocity = new Vector3(playerInput.x, 0f, playerInput.z) * maxMoveSpeed;
        Vector3 displacement = velocity * Time.deltaTime;
        transform.localPosition += displacement;
        */
    }
    
    void GenerateAvailableMovements () {
        if (this.availableMovements.Count == 0) {
            if (currentTile != null) {
                //We have a currentTile (origin Tile actually.)
                Transform currentTileTemp = currentTile; //We work with the temp from now on.
                currentTileTemp.gameObject.GetComponent<TileLogic>().moveAvailable = true; //Maybe we shouldn't let it highlight itself, but I need to see it work.
                
                //Load it into the availablemovements list.
                List<Transform> avMovementTemp = new List<Transform>();
                avMovementTemp.Add(currentTileTemp);
                
                //What we want is almost recursive. For every tile we compare our 
                //totalMoveRange with the tile's distance. We get our tile's distance naively. We add
                //1 every time we get the neighbours of a tile.
                //IF THAT TILE DOESN'T ALREADY HAVE A DISTANCE FILLED IN.
                //This changes things permanently (because they are public variables)
                //so if we use a tile again in a separate move that distance will get thrust into a movement
                //that it wasn't associated with.
                
                //SUMMARY: REMEMBER TO TAKE THE LIST OF AVAILABLEMOVEMENTS AND FLIP THEIR DISTANCES BACK TO 
                //WHATEVER THE "NOT SET" VALUE IS (distance = -1 in that case).
                
                
                
                //
                //while we still have something in our process queue.
                //make our currentTile
                //Then for each neighbour to current tile
                
                //currentTile.GameObject.
            }
        }
    }
}
