using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Respawning : MonoBehaviour
{
    public void Respawn()
    {
        SceneManager.LoadScene(1);    //loads the original scene from the death menu or the play menu
    }

}
