using System;
using System.Collections.Generic;
using UnityEngine;

public enum PointType { Default,Start,WaitOrder,Exit }

public class NPC_Path : MonoBehaviour
{
    [SerializeField] private List<PathPoint> _path = new List<PathPoint>();

    public List<PathPoint> path => _path;

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        foreach (var p in _path) 
        {
            if(p.point == null) continue;

            switch (p.type)
            {
                case PointType.Start:
                    Gizmos.color = Color.green;
                    break;
                case PointType.WaitOrder:
                    Gizmos.color = Color.yellow;
                    break;
                case PointType.Exit:
                    Gizmos.color = Color.red;
                    break;
                case PointType.Default:
                    Gizmos.color = Color.white;
                    break;
            }

            Gizmos.DrawSphere(p.point.transform.position, 0.1f);
        }

        Gizmos.color = Color.blue;

        for (int i = 0; i < _path.Count; i++) 
        {
            if (i != _path.Count - 1 && _path[i].point != null)
            {
                Gizmos.DrawLine(_path[i].point.transform.position, path[i + 1].point.transform.position);
            }
        }
    }
#endif
}

[Serializable]
public class PathPoint 
{
    public GameObject point;
    public PointType type;
}
