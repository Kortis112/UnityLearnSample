using UnityEngine;
using System.Collections;

public class ShrinkAndDestroyScript : SampleScript
{
    [SerializeField] private Transform target;
    [SerializeField] private float shrinkSpeed = 1f;

    [ContextMenu("Run")]
    public override void Use()
    {
        if (target != null)
            StartCoroutine(ShrinkAndDestroyCoroutine());
    }

    private IEnumerator ShrinkAndDestroyCoroutine()
    {
        foreach (Transform child in target)
        {
            StartCoroutine(ShrinkObject(child));
            yield return new WaitForSeconds(0.1f);
        }
    }

    private IEnumerator ShrinkObject(Transform obj)
    {
        Vector3 originalScale = obj.localScale;
        float timer = 0;

        while (timer < 1)
        {
            timer += Time.deltaTime * shrinkSpeed;
            obj.localScale = Vector3.Lerp(originalScale, Vector3.zero, timer);
            yield return null;
        }

        Destroy(obj.gameObject);
    }
}