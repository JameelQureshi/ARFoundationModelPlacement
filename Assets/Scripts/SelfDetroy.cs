using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDetroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyMessage", 5);   
    }

    // Update is called once per frame
    void DestroyMessage()
    {
        Destroy(gameObject);   
    }

}
