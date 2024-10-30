using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{

    public Camera mainCamera;                 //refrences the camera
    
    public Button optionsButton;              //refrences the options button that player presses
    
    public Vector3 startPosition;             //Position that camera starts at
    public Vector3 endPosition;               //Position that camera will end at
    public Vector3 cameraPosition;            //Current position that camera is at
    Vector3 currentVelocity;                  //Current velocity of the camera
    
    public float moveSpeed = 10f;             //Move Speed of the camera
    public float smoothTime = 0.5f;           //how long it takes for the camera to slow down to stop
    
    public GameObject Title;                  //The title of the game on fron screen
    public GameObject optionMenu;             //The options menu to be set active or not
    public GameObject MainMenu;               //MainMenu to be set active or not
   
    public int iterationCount = 75;

    private bool isMoving;                    //Can be set active to show whether camera is moving or not

    void Start()                              // Function that runs when game starts
    {
        startPosition = new Vector3(2.45f, 1.39f, -8.7f);
        endPosition = new Vector3(52.35f, 1.39f, -8.7f);
        cameraPosition = mainCamera.transform.position;

        MainMenu.SetActive(true);
        optionMenu.SetActive(false);

        isMoving = false;

        mainCamera.transform.position = startPosition;

        if (optionsButton != null)
        {
            optionsButton.onClick.AddListener(OptionMenu);
        }
    }
    void OptionMenu()
    {
        MainMenu.SetActive(false);
        optionMenu.SetActive(true);
        isMoving = true;

    }

    void FixedUpdate()
    {
        
        if (isMoving = true && cameraPosition != endPosition )
        {
            mainCamera.transform.position = Vector3.SmoothDamp(mainCamera.transform.position, endPosition, ref currentVelocity, smoothTime);
        }
    }

}