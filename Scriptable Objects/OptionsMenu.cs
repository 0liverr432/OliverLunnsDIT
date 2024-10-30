using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{

    public Camera mainCamera;               //These are my start variables that are refrences to in game objects   
    public Button optionsButton;              
    // this indentation and the ones below are used so that while coding I can see and anyone else can see for different types 
    // of variables such as object references above and Vector3 positions below. This is camel casing which is a part of unity programming conventions
    // Camel casing also includes extended, descriptave names for variables which you can see |
    public Vector3 startPosition;    //                                                       |
    public Vector3 endPosition;      //                                                       |   
    public Vector3 cameraPosition;   //                                                       |        
    Vector3 currentVelocity;         //                                                       |             
                                     //                                                       |
    public float moveSpeed = 10f;    // <------------------------------------------------------ here instead of using ms for     
    public float smoothTime = 0.5f;  // move speed i have enlongated the variable name to moveSpeed to describe it better.        
    
    public GameObject Title;                  
    public GameObject optionMenu;             
    public GameObject MainMenu;              
   
    public int iterationCount = 75;

    private bool isMoving;       

    void Start()                              // Another convention of unitys programing is methods which run code when the 
    {                                         // this paticular function runs when the play button is first pressed then never again.
        startPosition = new Vector3(2.45f, 1.39f, -8.7f);    
        endPosition = new Vector3(52.35f, 1.39f, -8.7f);
        cameraPosition = mainCamera.transform.position;

        MainMenu.SetActive(true);
        optionMenu.SetActive(false);

        isMoving = false;

        mainCamera.transform.position = startPosition;

        if (optionsButton != null)    // In the code this is a major decision finding whether or not the options button is active 
        {                             // which then adds a function to run whenever the button is clicked by the mouse |
            optionsButton.onClick.AddListener(OptionMenu);//here <-----------------------------------------------------|
        }
    }
    void OptionMenu()
    {
        MainMenu.SetActive(false);        //the start varaibles above are then refrenced here in the function called when the 
        optionMenu.SetActive(true);       // options button is pressed. 
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
