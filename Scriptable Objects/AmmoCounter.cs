using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class AmmoCounter : MonoBehaviour
{
    [SerializeField]
    public TMP_Text _ammoText;

    void Update()
    {
        UpdateAmmo();
    }
   
    public void UpdateAmmo()
    {

    }


}