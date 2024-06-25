using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassMover : MonoBehaviour
{
    
    public Rigidbody Glass;
    public GameObject Glasss;
    
    
    
    public Vector3 GlassStartPosition;
    
    
    
    // Start is called before the first frame update
    void Start()
    {

        GlassStartPosition = new Vector3 (0f, -1.72f, 8.16f);
        Glasss.transform.position = GlassStartPosition;

    }

    void FixedUpdate()
    {
        Glass.AddForce(Vector3.down * Time.deltaTime * 10);
    }
}
