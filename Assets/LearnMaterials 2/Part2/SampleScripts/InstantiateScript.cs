using UnityEngine;

public class InstantiateScript : SampleScript
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private int copies = 5;
    [SerializeField] private float step = 1f;

    [ContextMenu("Run")]
    public override void Use()
    {
        Vector3 spawnPosition = transform.position;
        for (int i = 0; i < copies; i++)
        {
            Instantiate(prefab, spawnPosition, Quaternion.identity);
            spawnPosition += Vector3.forward * step;
        }
    }
}