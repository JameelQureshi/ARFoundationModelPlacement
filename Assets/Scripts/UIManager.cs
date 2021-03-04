using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    
    public void OnButtonClick()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<ModelSwitch>().Switch();
    }
    
}
