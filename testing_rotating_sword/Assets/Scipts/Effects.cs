using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effects : MonoBehaviour
{
    public static void SpawnDeathFX(Vector3 aPostion)
    {
        Instantiate(Resources.Load<GameObject>("Blast"), aPostion, Quaternion.identity);
    }
}
