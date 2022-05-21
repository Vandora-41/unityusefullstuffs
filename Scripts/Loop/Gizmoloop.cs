using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gizmoloop : MonoBehaviour
{
        const float GizmoRad = 0.27f;

        private void OnDrawGizmos() {
            for (int i = 0; i < transform.childCount; i++)
            {
                int j = GetNextIndex(i);
                Gizmos.DrawSphere(GetWaypoint(i), GizmoRad);
                Gizmos.DrawLine(GetWaypoint(i), GetWaypoint(j));       
            }
        }
        public int GetNextIndex(int i)
        {
            if (i + 1 == transform.childCount)
            {
                return 0;
            }
            return i + 1;
        }
        public Vector3 GetWaypoint(int i)
        {
            return transform.GetChild(i).position;
        }
}

/*
Bunu bir şeye atadığınızda (tavsiyem empty object)atadığınız şeye ne kadar çok child obje yaratırsanız
Gizmo ile gelirler ve hepsi bir diğeriyle bağlıdır sıralı şekilde. 

Bununla loop,rotasyon vs. oluşturabilirsiniz ne kadar child obje varsa aralarında sırasıyla döner durur.

*/
