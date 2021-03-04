using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMovment : MonoBehaviour
{
    public Animator animator;
    public float  z=0.001f;
    // Start is called before the first frame update
    void Start()
    {
        GoUp();
    }
    private void Update()
    {
        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z+z);
    }


    void GoUp()
    {
        animator.SetTrigger("Up");
        z = 0.0001f;
        Invoke("GoDown",3);
    }
    void GoDown()
    {
        animator.SetTrigger("Down");
        z = -0.0001f;
        Invoke("GoUp", 3);
    }
}
