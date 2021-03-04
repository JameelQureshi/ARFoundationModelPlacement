using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabEater : MonoBehaviour
{
    public GameObject message;
    // Start is called before the first frame update
    void Start()
    {
        //message = GameObject.FindGameObjectWithTag("message");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider target)
    {
        if (target.gameObject.tag=="ball")
        {
            Destroy(target.transform.parent.gameObject);
            Instantiate(message,target.transform.position, new Quaternion(0,0,0,0));
            transform.parent.GetComponent<Animator>().SetTrigger("Fed");
        }
    }

    void TurnOffMessage()
    {
        message.transform.GetChild(1).gameObject.SetActive(false);
    }
}
