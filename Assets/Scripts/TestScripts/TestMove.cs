using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMove : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-2 * Time.deltaTime, 0, 0);
            EventCenter<TestEvent>.Broadcast(TestEvent.TestMove_left);
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(2 * Time.deltaTime, 0, 0);
            EventCenter<TestEvent>.Broadcast(TestEvent.TestMove_right);
        }
        else if (Input.GetKeyDown(KeyCode.W) || Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0, 2 * Time.deltaTime, 0);
            EventCenter<TestEvent>.Broadcast(TestEvent.TestMove_up);
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKey(KeyCode.S))
        {
            transform.position += new Vector3(0, -2 * Time.deltaTime, 0);
            EventCenter<TestEvent>.Broadcast(TestEvent.TestMove_down);
        }
    }
}
