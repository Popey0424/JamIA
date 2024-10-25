using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPrefab : MonoBehaviour
{
    private void OnBecameInvisible()
    {
        Destroy(gameObject);  
    }
}
