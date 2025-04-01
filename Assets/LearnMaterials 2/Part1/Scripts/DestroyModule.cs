using System.Collections;
using UnityEngine;

[HelpURL("https://docs.google.com/document/d/1RMamVxE-yUpSfsPD_dEa4-Ak1qu6NTo83qY1O4XLxUY/edit?usp=sharing")]
public class DestroyModule : MonoBehaviour
{
    [Header("Module Settings")]
    [Tooltip("Задержка между удалениями отдельных частей (в секундах)")]
    [Range(0.1f, 10f)]
    [SerializeField] private float destroyDelay = 1f;

    [Tooltip("Минимальное количество дочерних объектов, при достижении которого модуль удаляется")]
    [Min(0)]
    [SerializeField] private int minimalDestroyingObjectsCount = 0;

    private Transform myTransform;

    private void Awake()
    {
        myTransform = transform;
    }

    [ContextMenu("Начать удаление объектов")]
    public void ActivateModule()
    {
        StartCoroutine(DestroyRandomChildObjectCoroutine());
    }

    private IEnumerator DestroyRandomChildObjectCoroutine()
    {
        while (myTransform.childCount > minimalDestroyingObjectsCount)
        {
            int index = Random.Range(0, myTransform.childCount);
            Destroy(myTransform.GetChild(index).gameObject);
            yield return new WaitForSeconds(destroyDelay);
        }
        Destroy(gameObject, Time.deltaTime);
    }
}
