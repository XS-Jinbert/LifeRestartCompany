using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestTextShow : MonoBehaviour
{
    Text show;

    private void Awake()
    {
        show = GetComponent<Text>();
        //EventCenter<TestEvent>.AddListener(TestEvent.TestMove_up, SetUpText);
        //EventCenter<TestEvent>.AddListener(TestEvent.TestMove_down, SetDownText);
        //EventCenter<TestEvent>.AddListener(TestEvent.TestMove_left, SetLeftText);
        //EventCenter<TestEvent>.AddListener(TestEvent.TestMove_right, SetRightText);
        EventCenter<TestEvent>.AddListener<string>(TestEvent.TestMove_up, SetText);
        EventCenter<TestEvent>.AddListener<string>(TestEvent.TestMove_down, SetText);
        EventCenter<TestEvent>.AddListener<string>(TestEvent.TestMove_left, SetText);
        EventCenter<TestEvent>.AddListener<string>(TestEvent.TestMove_right, SetText);
    }

    void Start()
    {
        show.text = "";
    }

    private void OnDestroy()
    {
        //EventCenter<TestEvent>.RemoveListener(TestEvent.TestMove_up, SetUpText);
        //EventCenter<TestEvent>.RemoveListener(TestEvent.TestMove_down, SetDownText);
        //EventCenter<TestEvent>.RemoveListener(TestEvent.TestMove_left, SetLeftText);
        //EventCenter<TestEvent>.RemoveListener(TestEvent.TestMove_right, SetRightText);
        EventCenter<TestEvent>.RemoveListener<string>(TestEvent.TestMove_up, SetText);
        EventCenter<TestEvent>.RemoveListener<string>(TestEvent.TestMove_down, SetText);
        EventCenter<TestEvent>.RemoveListener<string>(TestEvent.TestMove_left, SetText);
        EventCenter<TestEvent>.RemoveListener<string>(TestEvent.TestMove_right, SetText);
    }

    void SetUpText() { show.text = "正在向上移动"; }

    void SetDownText() { show.text = "正在向下移动"; }

    void SetLeftText() { show.text = "正在向左移动"; }

    void SetRightText() { show.text = "正在向右移动"; }

    void SetText(string a) { show.text = a; }
}
