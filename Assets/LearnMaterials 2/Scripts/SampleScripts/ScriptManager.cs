using UnityEngine;
using System.Collections.Generic;

public class SampleScriptManager : MonoBehaviour
{
    private List<SampleScript> scripts = new List<SampleScript>();

    private void Awake()
    {
        scripts.AddRange(FindObjectsOfType<SampleScript>());
    }

    public void UseAll()
    {
        foreach (var script in scripts)
        {
            script.Use();
        }
    }
}