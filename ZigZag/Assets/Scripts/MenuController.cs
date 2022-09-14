using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{ 
     
    public void OpenPolicy(string url)
    {
        Application.OpenURL(url);
    }
}
