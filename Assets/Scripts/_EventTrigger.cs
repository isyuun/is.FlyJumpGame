using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;

public class _EventTrigger : EventTrigger
{

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected string GetMethodName()
    {
        MethodBase method = (new StackTrace()).GetFrame(1).GetMethod();
        string name = this.GetType().Name + "::" + (new StackTrace()).GetFrame(1).GetMethod().Name;
        //name = MethodBase.GetCurrentMethod().Name;
        ParameterInfo[] _params = GetMethodParams(method);
        if (_params != null && _params.Length > 0)
        {
            name += "(...)";
            foreach (var param in _params)
            {
                name += param/* + "=" + param.value(?)*/;
            }
        }
        else
        {
            name += "()";
        }
        return DateTime.Now.ToString(/*"yyyy/MM/dd" + "-" + */"HH:mm:ss.fff") + "-" + Time.deltaTime + ":" + name;
    }

    private ParameterInfo[] GetMethodParams(MethodBase method)
    {
        ParameterInfo[] pars = method.GetParameters();
        //foreach (ParameterInfo p in pars)
        //{
        //    Console.WriteLine(p.ParameterType);
        //}
        return pars;
    }

    protected Bounds GetTotalMeshFilterBounds(Transform objectTransform)
    {
        var meshFilter = objectTransform.GetComponent<MeshFilter>();
        var result = meshFilter != null ? meshFilter.mesh.bounds : new Bounds();

        foreach (Transform transform in objectTransform)
        {
            var bounds = GetTotalMeshFilterBounds(transform);
            result.Encapsulate(bounds.min);
            result.Encapsulate(bounds.max);
        }
        var scaledMin = result.min;
        scaledMin.Scale(objectTransform.localScale);
        result.min = scaledMin;
        var scaledMax = result.max;
        scaledMax.Scale(objectTransform.localScale);
        result.max = scaledMax;
        return result;
    }

    //// Use this for initialization
    //protected virtual void Awake()
    //{
    //}

    //// Use this for initialization
    //protected virtual void Start()
    //{
    //}

    //// Update is called once per frame
    //protected virtual void Update()
    //{
    //}

    //protected virtual void OnCollisionEnter(Collision collision)
    //{
    //}
}
