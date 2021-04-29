using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fieldOfView : MonoBehaviour
{
    public float viewRadius;
    [Range(0,360)]
    public float viewAngle;
    public LayerMask targetMask;
    public LayerMask obstacleMask;
    public List<Transform> visibleTargets = new List<Transform>();
    public float meshResolution;
    public MeshFilter viewMeshFilter;
    public int Spot = 0;
    Mesh viewMesh;
    void Start() {
        viewMesh = new Mesh();
        viewMesh.name = "View Mesh";
        viewMeshFilter.mesh = viewMesh;
        StartCoroutine("FindTargetsWithDelay",.2f);
    }
    IEnumerator FindTargetsWithDelay(float delay){
        while(true){
            yield return new WaitForSeconds (delay);
            FindVisibleTargets();
        }
    }
    void Update() {
        DrawFieldOfView();
        if(Spot==0){
            transform.rotation = Quaternion.Euler(0,0,0);
        }
        if(Spot==1){
            transform.rotation = Quaternion.Euler(0,0,270);
        }
        if(Spot==2){
            transform.rotation = Quaternion.Euler(0,0,180);
        }
        if(Spot==3){
            transform.rotation = Quaternion.Euler(0,0,90);
        }
    }
    void FindVisibleTargets(){
        visibleTargets.Clear();
        Collider2D[] targetsInViewRadius = Physics2D.OverlapCircleAll(transform.position,viewRadius,targetMask);
        for(int i=0; i<targetsInViewRadius.Length; i++){
            Transform target = targetsInViewRadius[i].transform;
            Vector3 dirToTarget = (target.position - transform.position).normalized;
            if (Vector3.Angle(transform.up,dirToTarget) < viewAngle / 2){
                float dstToTarget = Vector3.Distance(transform.position,target.position);
                if (!Physics2D.Raycast(transform.position,dirToTarget,dstToTarget,obstacleMask)){
                    visibleTargets.Add(target);
                    gameObject.GetComponentInParent<PoliceMovement>().chase=true;
                }else{
                    gameObject.GetComponentInParent<PoliceMovement>().chase=false;
                }
            }
        }
    }
    
    void DrawFieldOfView(){
        int stepCount = Mathf.RoundToInt(viewAngle * meshResolution);
        float stepAngleSize = viewAngle / stepCount;
        List<Vector3> viewPoints = new List<Vector3>();
        for (int i = 0; i < stepCount; i++){
          float angle = transform.eulerAngles.y - viewAngle / 2 + stepAngleSize * i;
          Debug.DrawLine(transform.position, transform.position + DirFromAngle (angle,true) * viewRadius, Color.red);
          ViewCastInfo newViewCast = ViewCast (angle);
          viewPoints.Add(newViewCast.point);
        }
        int vertexCount = viewPoints.Count +1;
        Vector3[] vertices = new Vector3[vertexCount];
        int[] triangles = new int [(vertexCount-2)*3];

        vertices[0] = Vector3.zero;
        for(int i = 0; i < vertexCount - 1; i++){
            vertices[i+1] = viewPoints[i];
            if(i<vertexCount-2){
                triangles[i*3] = 0;
                triangles[i*3+1] = i+1;
                triangles[i*3+2]=i+2;
            }
        }
        viewMesh.Clear();
        viewMesh.vertices = vertices;
        viewMesh.triangles = triangles;
        viewMesh.RecalculateNormals();
    }

    ViewCastInfo ViewCast(float globalAngle){
        Vector3 dir = DirFromAngle(globalAngle,true);
        RaycastHit2D hit = Physics2D.Raycast(transform.position,new Vector2(dir.x,dir.y),viewRadius,obstacleMask);
        if(hit==true && hit.collider==true){
            return new ViewCastInfo(true,hit.point,hit.distance,globalAngle);
        }else{
            return new ViewCastInfo(false,transform.position + dir * viewRadius, viewRadius, globalAngle);
        }
    }
    public Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal){
        if (!angleIsGlobal){
            angleInDegrees -= transform.eulerAngles.z;
        }
        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad),Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }
    public struct ViewCastInfo {
        public bool hit;
        public Vector3 point;
        public float dst;
        public float angle;
        public ViewCastInfo(bool _HIT, Vector3 _point, float _dst, float _angle){
            hit = _HIT;
            point = _point;
            dst = _dst;
            angle = _angle;
        }
    }
}
