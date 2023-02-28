using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goldBlock : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    private Material[] original;

    void Update()
    {
        Flash();
    }


    IEnumerator Flash()
    {
        Material[] mats = meshRenderer.materials;
        for(int i = 0; i < meshRenderer.materials.Length; i++)
        {
            mats[i] = original[i];
        }

        meshRenderer.materials = mats;
        yield return new WaitForSeconds(1f);
        
        for(int i = 0; i < meshRenderer.materials.Length; i++)
        {
            mats[i] = original[i];
        }

        meshRenderer.materials = mats;
    }
}
