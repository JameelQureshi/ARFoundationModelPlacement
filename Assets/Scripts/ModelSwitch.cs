using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelSwitch : MonoBehaviour
{
    public GameObject[] models;
    int index;
    public void Switch()
    {
        models[index].SetActive(false);
        index++;
        if (index==models.Length)
        {
            index = 0;
        }
        models[index].SetActive(true);
    }
}
