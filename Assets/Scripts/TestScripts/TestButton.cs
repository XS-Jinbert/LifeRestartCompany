using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestButton : MonoBehaviour
{
    public void Left()
    {
        EventCenter<TestEvent>.Broadcast(TestEvent.TestMove_left, "Button1");
    }

    public void Right()
    {
        EventCenter<TestEvent>.Broadcast(TestEvent.TestMove_right, "Button2");
    }

    public void Up()
    {
        EventCenter<TestEvent>.Broadcast(TestEvent.TestMove_up, "Button3");
    }

    public void Down()
    {
        EventCenter<TestEvent>.Broadcast(TestEvent.TestMove_down, "Button4");
    }
}
