using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public Transform playerPos;

    public bool RIPPlayer;

    public int speed;

    Vector3 Target;
    void Start()
    {
        
    }

    
    void Update()
    {

        if (playerPos == null)
            return;
        if (playerPos != null && Target != null)
        {
            Target = new Vector3(playerPos.position.x, playerPos.position.y, transform.position.z);

            Vector3 camMoveDir = (Target - transform.position).normalized;
            float distance = Vector3.Distance(Target, transform.position);
            float camMoveSpeed = 3f;

            transform.position = transform.position + camMoveDir * distance * camMoveSpeed * Time.deltaTime;
        }
    }
}
