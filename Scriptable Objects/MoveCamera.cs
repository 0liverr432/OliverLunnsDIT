using UnityEngine;

public class MoveCamera : MonoBehaviour {

    public Transform player; //the variable for the player 

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; //locks cursor in place so that you cant click the x or something 
        Cursor.visible = false; //hides the cursor so we can use a crosshair instead
    }
     
    void Update()     //called every frame
    {
        transform.position = player.transform.position;    //sets the camera position to the player 
    }
}