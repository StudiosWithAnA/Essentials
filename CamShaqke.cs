using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamShaqke : MonoBehaviour
{
    public Animator camAnim;
    private void Start()
    {

    }

    public void OnShoot()
    {
            camAnim.SetTrigger("Shake");
    }

    
}
