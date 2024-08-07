using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class OptionsMenu : MonoBehaviour
{
    public Button optionsButton; // Reference to options button
    public Vector3 position;
    public Camera MainCamera;
    private bool isMoving = false;
    public float movementSpeed = 10f;
    public Vector3 endPosition;
    Vector3 currentVelocity;
    public float smoothTime = 0.5f;
    public GameObject Title;
    public GameObject optionsMenu;

    void Start()
    {
        
        endPosition = new Vector3(2.32f, 4f, 35.2f);
        optionsMenu.SetActive(false);
        
        // Store the initial position of the MainCamera
        position = new Vector3(2.32f, 4f, 0.73f);
        MainCamera.transform.position = position;
        // Add listener to the options button
        if (optionsButton != null)
        {
            optionsButton.onClick.AddListener(MoveCameraSideways);
        }
    }

    
    void FixedUpdate()
    {
        if (MainCamera.transform.position == endPosition && position == endPosition)
        {
            isMoving = false;
        }

    }
    
    void Update()
    {
        //check if the camera is moving and the og position is equal to the end position.
        if (isMoving = true && position != endPosition)
        {
            while (isMoving == true)
            {
            // Move the camera gradually
            MainCamera.transform.position = Vector3.SmoothDamp(transform.position, endPosition, ref currentVelocity, smoothTime);
            position = endPosition;
            
            
            if (MainCamera.transform.position == endPosition && position == endPosition)
            {
            isMoving = false;
            }
            }
        }  
    }

    public void MoveCameraSideways()
    {   // Check if its being clicked
        Debug.Log("OptionsClicked");
        position = new Vector3(2.32f, 4f, 0.73f);
        // Start moving the camera sideways
        isMoving = true;
        Title.SetActive(false);
        OptionsMenuActive();
    }

    private void OnTriggerEnter(Collider other)
    {
        position = endPosition;
        MainCamera.transform.position = new Vector3(2.32f, 4f, 0.73f);
    }

    public void OptionsMenuActive()
    {
        optionsMenu.SetActive(true);
    }
}
