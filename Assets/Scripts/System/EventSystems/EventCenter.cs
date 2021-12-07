using System;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 事件中心泛型
/// </summary>
/// <typeparam name="EventCode">事件类型码</typeparam>
public static class EventCenter<EventCode>
{
    /// <summary>
    /// 事件中心管理响应字典，一个事件码只能有一个返回类型的委托
    /// </summary>
    static Dictionary<EventCode, Delegate> eventTable = new Dictionary<EventCode, Delegate>();



    /// <summary>
    /// 无参回调委托
    /// </summary>
    public delegate void CallBack();
    /// <summary>
    /// 带1参回调委托
    /// </summary>
    /// <typeparam name="T">类型模板</typeparam>
    /// <param name="arg">参数</param>
    public delegate void CallBack<T>(T arg);



    /// <summary>
    /// 添加订阅监听前的前置判断
    /// </summary>
    /// <param name="eventcode">事件码</param>
    /// <param name="callback">注册的委托函数</param>
    static void OnListenerAdding(EventCode eventcode, Delegate callback)
    {
        if (!eventTable.ContainsKey(eventcode))
        {
            eventTable.Add(eventcode, null);
        }
        Delegate d = eventTable[eventcode];
        if (d != null && d.GetType() != callback.GetType())
        {
            throw new Exception(string.Format("尝试为事件{0}添加不同类型的委托，当前事件对应的的委托是{1}，要添加的委托类型是{2}", 
                eventcode, d.GetType(), callback));
        }
    }

    /// <summary>
    /// 添加无参的订阅监听
    /// </summary>
    /// <param name="eventCode">事件码</param>
    /// <param name="callback">注册的委托函数</param>
    public static void AddListener(EventCode eventCode, CallBack callback)
    {
        OnListenerAdding(eventCode, callback);
        // 多播委托
        // 强转类型保证同类型的委托合并多播
        eventTable[eventCode] = (CallBack)eventTable[eventCode] + callback;
    }

    /// <summary>
    /// 添加带1参的订阅监听
    /// </summary>
    /// <typeparam name="T">类型模板</typeparam>
    /// <param name="eventCode">事件码</param>
    /// <param name="callback">注册的委托函数</param>
    public static void AddListener<T>(EventCode eventCode, CallBack<T> callback)
    {
        OnListenerAdding(eventCode, callback);
        eventTable[eventCode] = (CallBack<T>)eventTable[eventCode] + callback;
    }



    /// <summary>
    /// 监听的订阅移除前置判断
    /// </summary>
    /// <param name="eventCode">事件码</param>
    /// <param name="callback">注册的委托函数</param>
    static void OnListenerRemoving(EventCode eventCode, Delegate callback)
    {
        Delegate d;
        // 先判key
        if (eventTable.TryGetValue(eventCode, out d))
        {
            // 再判value
            if (d == null)
            {
                throw new Exception(string.Format("移除监听错误:事件{0}没有对应的委托", eventCode));
            }
            else if (d.GetType() != callback.GetType())
            {
                throw new Exception(string.Format("移除监听错误:尝试为事件{0}移除不同类型的委托，当前委托类型为{1}" +
                    ",要移除的委托的类型为{2}", eventCode, d.GetType(), callback.GetType()));
            }
        }
        else
        {
            throw new Exception(string.Format("移除监听错误:没有事件码{0}", eventCode));
        }
    }

    /// <summary>
    /// 无参监听订阅的移除
    /// </summary>
    /// <param name="eventCode">事件码</param>
    /// <param name="callback">注册的委托函数</param>
    public static void RemoveListener(EventCode eventCode, CallBack callback)
    {
        OnListenerRemoving(eventCode, callback);
        // 多播委托的移除
        eventTable[eventCode] = (CallBack)eventTable[eventCode] - callback;
        OnListenerRemoved(eventCode);
    }

    /// <summary>
    /// 带1参的监听订阅的移除
    /// </summary>
    /// <typeparam name="T">类型模板</typeparam>
    /// <param name="eventCode">事件码</param>
    /// <param name="callback">注册的委托函数</param>
    public static void RemoveListener<T>(EventCode eventCode, CallBack<T> callback)
    {
        OnListenerRemoving(eventCode, callback);
        eventTable[eventCode] = (CallBack<T>)eventTable[eventCode] + callback;
        OnListenerRemoved(eventCode);
    }

    /// <summary>
    /// 移除监听收尾
    /// </summary>
    /// <param name="eventCode">事件码</param>
    static void OnListenerRemoved(EventCode eventCode)
    {
        if (eventTable[eventCode] == null) eventTable.Remove(eventCode);
    }



    /// <summary>
    /// 广播无参的事件
    /// </summary>
    /// <param name="eventCode">事件码</param>
    public static void Broadcast(EventCode eventCode)
    {
        Delegate d;
        if(eventTable.TryGetValue(eventCode, out d))
        {
            CallBack callback = d as CallBack;
            if(callback != null)
            {
                callback();
            }
            else
            {
                throw new Exception(string.Format("广播事件错误:事件{0}对应的委托具有不同类型", eventCode));
            }
        }
    }

    /// <summary>
    /// 广播带1参的事件
    /// </summary>
    /// <typeparam name="T">类型模板</typeparam>
    /// <param name="eventCode">事件码</param>
    /// <param name="arg">带参信息</param>
    public static void Broadcast<T>(EventCode eventCode, T arg)
    {
        Delegate d;
        if (eventTable.TryGetValue(eventCode, out d))
        {
            CallBack<T> callback = d as CallBack<T>;
            if (callback != null)
            {
                callback(arg);
            }
            else
            {
                throw new Exception(string.Format("广播事件错误:事件{0}对应的委托具有不同类型", eventCode));
            }
        }
    }
}
