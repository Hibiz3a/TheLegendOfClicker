using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnCubeScript : MonoBehaviour
{
    public void spawnCube()
    {
        MovManager.instance.Remove(gameObject);
    }
}