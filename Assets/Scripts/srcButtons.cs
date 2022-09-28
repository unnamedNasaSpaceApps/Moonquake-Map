using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class srcButtons : MonoBehaviour
{
    public Animation temblor;

    public void OnButtonTerremotoPress(){
        temblor = this.gameObject.GetComponent<Animation>();
        temblor.Play("CamaraTiembla");        
    }
}
