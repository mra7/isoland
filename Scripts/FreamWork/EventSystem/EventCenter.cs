using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventCenter
{
    private static Dictionary<EventType, Delegate> eventDic = new Dictionary<EventType, Delegate>();
    #region ͨ�ò��� + ���쳣
    private static void OnListenerAdding(EventType eventType, Delegate callBack)
    {
        if (!eventDic.ContainsKey(eventType))
        {
            eventDic.Add(eventType, null);
        }
        Delegate d = eventDic[eventType];
        if (d != null && d.GetType() != callBack.GetType())
        {
            throw new Exception(string.Format("����Ϊ�¼�{0}��Ӳ�ͬ���͵�ί�У���ǰ�¼�����Ӧ��ί����{1}��Ҫ��ӵ�ί������Ϊ{2}", eventType, d.GetType(), callBack.GetType()));
        }
    }
    private static void OnListenerRemoving(EventType eventType, Delegate callBack)
    {
        if (eventDic.ContainsKey(eventType))
        {
            Delegate d = eventDic[eventType];
            if (d == null)
            {
                throw new Exception(String.Format("���¼�����û���¼�", eventType));
            }
            if (d != null && d.GetType() != callBack.GetType())
            {
                throw new Exception(String.Format("����Ϊ�¼�{0}�Ƴ���ͬ���͵�ί�У���ǰ�¼�����Ӧ��ί����{1}��Ҫ��ӵ�ί������Ϊ{2}", eventType, d.GetType(), callBack.GetType()));
            }
        }
        else
        {
            throw new Exception(String.Format("û���¼���{0}", eventType));
        }
    }
    #endregion
    #region �޲����¼�
    public static void AddListener(EventType eventType, CallBack callBack)
    {
        OnListenerAdding(eventType, callBack);
        eventDic[eventType] = (CallBack)eventDic[eventType] + callBack;
    }
    public static void RemoveListener(EventType eventType, CallBack callBack)
    {
        OnListenerRemoving(eventType, callBack);
        eventDic[eventType] = (CallBack)eventDic[eventType] - callBack;
    }
    public static void Boardcast(EventType eventType)
    {
        Delegate d;
        if (eventDic.TryGetValue(eventType, out d))
        { 
            CallBack callback = d as CallBack;
            if (callback == null)
            {
                throw new Exception(String.Format("�㲥�¼������¼�{0}���в�ͬ��ί������", eventType));
            }
            else
            {
                callback();   
            }
        }
    }
    #endregion
    #region һ������
    public static void AddListener<T>(EventType eventType, CallBack<T> callBack)
    {
        OnListenerAdding(eventType, callBack);
        eventDic[eventType] = (CallBack<T>)eventDic[eventType] + callBack;
    }
    public static void RemoveListener<T>(EventType eventType, CallBack<T> callBack)
    {
        OnListenerRemoving(eventType, callBack);
        eventDic[eventType] = (CallBack<T>)eventDic[eventType] - callBack;
    }
    public static void Boardcast<T>(EventType eventType, T arg)
    {
        Delegate d;
        if (eventDic.TryGetValue(eventType, out d))
        {
            CallBack<T> callback = d as CallBack<T>;
            if (callback == null)
            {
                throw new Exception(String.Format("�㲥�¼������¼�{0}���в�ͬ��ί������", eventType));
            }
            else
            {
                callback(arg);
            }
        }
    }
    #endregion
    #region ��������
    public static void AddListener<T, X>(EventType eventType, CallBack<T, X> callBack)
    {
        OnListenerAdding(eventType, callBack);
        eventDic[eventType] = (CallBack<T, X>)eventDic[eventType] + callBack;
    }
    public static void RemoveListener<T, X>(EventType eventType, CallBack<T, X> callBack)
    {
        OnListenerRemoving(eventType, callBack);
        eventDic[eventType] = (CallBack<T, X>)eventDic[eventType] - callBack;
    }
    public static void Boardcast<T, X>(EventType eventType, T arg, X arg2)
    {
        Delegate d;
        if (eventDic.TryGetValue(eventType, out d))
        {
            CallBack<T, X> callback = d as CallBack<T, X>;
            if (callback == null)
            {
                throw new Exception(String.Format("�㲥�¼������¼�{0}���в�ͬ��ί������", eventType));
            }
            else
            {
                callback(arg, arg2);
            }
        }
    }
    #endregion
    #region ��������
    public static void AddListener<T, X, Y>(EventType eventType, CallBack<T, X, Y> callBack)
    {
        OnListenerAdding(eventType, callBack);
        eventDic[eventType] = (CallBack<T, X, Y>)eventDic[eventType] + callBack;
    }
    public static void RemoveListener<T, X, Y>(EventType eventType, CallBack<T, X, Y> callBack)
    {
        OnListenerRemoving(eventType, callBack);
        eventDic[eventType] = (CallBack<T, X, Y>)eventDic[eventType] - callBack;
    }
    public static void Boardcast<T, X, Y>(EventType eventType, T arg, X arg2, Y arg3)
    {
        Delegate d;
        if (eventDic.TryGetValue(eventType, out d))
        {
            CallBack<T, X, Y> callback = d as CallBack<T, X, Y>;
            if (callback == null)
            {
                throw new Exception(String.Format("�㲥�¼������¼�{0}���в�ͬ��ί������", eventType));
            }
            else
            {
                callback(arg, arg2, arg3);
            }
        }
    }
    #endregion
    #region �ĸ�����
    public static void AddListener<T, X, Y, Z>(EventType eventType, CallBack<T, X, Y, Z> callBack)
    {
        OnListenerAdding(eventType, callBack);
        eventDic[eventType] = (CallBack<T, X, Y, Z>)eventDic[eventType] + callBack;
    }
    public static void RemoveListener<T, X, Y, Z>(EventType eventType, CallBack<T, X, Y, Z> callBack)
    {
        OnListenerRemoving(eventType, callBack);
        eventDic[eventType] = (CallBack<T, X, Y, Z>)eventDic[eventType] - callBack;
    }
    public static void Boardcast<T, X, Y, Z>(EventType eventType, T arg, X arg2, Y arg3, Z arg4)
    {
        Delegate d;
        if (eventDic.TryGetValue(eventType, out d))
        {
            CallBack<T, X, Y, Z> callback = d as CallBack<T, X, Y, Z>;
            if (callback == null)
            {
                throw new Exception(String.Format("�㲥�¼������¼�{0}���в�ͬ��ί������", eventType));
            }
            else
            {
                callback(arg, arg2, arg3, arg4);
            }
        }
    }
    #endregion
    #region �������
    public static void AddListener<T, X, Y, Z, W>(EventType eventType, CallBack<T, X, Y, Z, W> callBack)
    {
        OnListenerAdding(eventType, callBack);
        eventDic[eventType] = (CallBack<T, X, Y, Z, W>)eventDic[eventType] + callBack;
    }
    public static void RemoveListener<T, X, Y, Z, W>(EventType eventType, CallBack<T, X, Y, Z, W> callBack)
    {
        OnListenerRemoving(eventType, callBack);
        eventDic[eventType] = (CallBack<T, X, Y, Z, W>)eventDic[eventType] - callBack;
    }
    public static void Boardcast<T, X, Y, Z, W>(EventType eventType, T arg, X arg2, Y arg3, Z arg4, W arg5)
    {
        Delegate d;
        if (eventDic.TryGetValue(eventType, out d))
        {
            CallBack<T, X, Y, Z, W> callback = d as CallBack<T, X, Y, Z, W>;
            if (callback == null)
            {
                throw new Exception(String.Format("�㲥�¼������¼�{0}���в�ͬ��ί������", eventType));
            }
            else
            {
                callback(arg, arg2, arg3, arg4, arg5);
            }
        }
    }
    #endregion
}
