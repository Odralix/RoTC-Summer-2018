﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class O_RandPowUps : MonoBehaviour
{
    public GameObject[] prefabs;
    public GameObject road;
    public Vector3 thePos;
    public int minPUPsPerSect = 0;
    public int maxPUPsPerSect = 4;
    public int nrOfSect = 20;
	// Use this for initialization
	void Start ()
    {
        Mesh roadMesh = road.GetComponent<MeshFilter>().mesh;
        Vector3[] vertices = roadMesh.vertices;

        int nrOfPUPs = 0;

        for (int i = 2; i < nrOfSect; i++)
        {
            nrOfPUPs = (int) (Mathf.Round(Random.Range(minPUPsPerSect, maxPUPsPerSect)));
            if(nrOfPUPs != 0)
            {
                float lPoint = (i-1) * (vertices.Length / nrOfSect);
                float hPoint = i * (vertices.Length / nrOfSect);

                int []spawnPointLst;

                for (int j = 0; j < nrOfPUPs; j++)
                {
                    //spawnPointLst[j] = Math.round(Random.Range(lPoint, hPoint));
                    //GameObject cubey = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    int a = (int)Mathf.Round(Random.Range(lPoint, hPoint));

                    int type = (int)Mathf.Round(Random.Range(0, 3));

                    Instantiate(prefabs[type], vertices[a], Quaternion.identity);

                    Debug.Log(a);
                    //cubey.transform.position = vertices[a];

                    Debug.Log("End of PUPs");
                }

                //float distance = Vector3.Distance((vertices[i * (vertices.Length / 20)].transform.positon), (vertices[(i-1)* (vertices.Length / 20)].transform.position));
            }
        }

        //for(int i=0; i<vertices.Length; i++)
        //{
        //    if(i> (vertices.Length/20))
        //    {
        //        GameObject cubey = GameObject.CreatePrimitive(PrimitiveType.Cube);
        //        thePos = transform.TransformPoint(vertices[i]);
        //        Debug.Log(thePos);
        //        cubey.transform.position = vertices[i];
        //    }
        //}
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
