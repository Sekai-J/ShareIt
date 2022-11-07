using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utils 
{
    //Set layer propio para no verse a si mismo
    public static void SetRenderLayerInChildren(Transform transform, int layerNum)
    {
        foreach(Transform trans in transform.GetComponentInChildren<Transform>(true))
        {
            trans.gameObject.layer = layerNum;
        }
    }
  
}
