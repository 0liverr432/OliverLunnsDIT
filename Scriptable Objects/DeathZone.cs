using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DeathZone : MonoBehaviour
{
    
    public Vector3 ZonePosition;
    public GameObject DeathZoneCube;
    
    // Start is called before the first frame update
    void Start()
    {
        ZonePosition = new Vector3(-1.9f, -42.86f, -35.43f);
    }

    void OnTriggerEnter()
    {
        Cursor.lockState = CursorLockMode.None; //locks cursor in place so that you cant click the x or something 
        Cursor.visible = true; //hides the cursor so we can use a crosshair instead

        SceneManager.LoadScene(2);
    }
}
