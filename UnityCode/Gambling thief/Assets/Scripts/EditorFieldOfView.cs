using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor (typeof (fieldOfView))]
public class EditorFieldOfView : Editor
{
    void OnSceneGUI(){
        fieldOfView fow = (fieldOfView)target;
        Handles.color = Color.white;
        Handles.DrawWireArc (fow.transform.position,Vector3.forward,Vector3.up,360,fow.viewRadius);

        Vector3 viewAngleA = fow.DirFromAngle(-fow.viewAngle/2,false);
        Vector3 viewAngleB = fow.DirFromAngle(fow.viewAngle/2,false);
        Handles.DrawWireArc(fow.transform.position,Vector3.forward,Vector3.up,fow.viewAngle,fow.viewRadius);
        Handles.DrawLine(fow.transform.position,fow.transform.position+viewAngleA * fow.viewRadius);
        Handles.DrawLine(fow.transform.position,fow.transform.position+viewAngleB * fow.viewRadius);
        foreach (Transform visibleTarget in fow.visibleTargets)
        {
            Handles.DrawLine(fow.transform.position, visibleTarget.position);
        }
    }
}
