
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generateAnts : MonoBehaviour
{
    public GameObject Ant;
    public Transform Self;
    public int objectQuantity;
    private int objectGeneratedQuantity;

    void Start()
    {
        StartCoroutine(GenerateObjects());
    }

    IEnumerator GenerateObjects()
    {
        while(objectGeneratedQuantity < objectQuantity)
        {
            Instantiate(Ant, new Vector2(Self.position.x, Self.position.y), Quaternion.identity);
            yield return new WaitForSeconds(0.01f);
            objectGeneratedQuantity += 1;
        }
    }

}
