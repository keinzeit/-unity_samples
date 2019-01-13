using UnityEngine;
using System.Collections.Generic;
using Vuforia;

public class DontDestroy : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
