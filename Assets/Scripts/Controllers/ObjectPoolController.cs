using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPoolController : MonoBehaviour
{
    private List<GameObject> usedObjects = new List<GameObject>();
    private List<GameObject> unusedObjects = new List<GameObject>();

    public List<T> UsedObjects<T>() where T : MonoBehaviour
    {
        return usedObjects.Select(e => e.GetComponent<T>()).Where(e => e != null).ToList();
    }

    public List<T> UnusedObjects<T>() where T : MonoBehaviour
    {
        return unusedObjects.Select(e => e.GetComponent<T>()).Where(e => e != null).ToList();
    }

    public void MarkAsUsed(GameObject gameObject)
    {
        gameObject.transform.SetParent(transform);

        usedObjects.Add(gameObject);
        unusedObjects.Remove(gameObject);
    }

    public void MarkAsUnused(GameObject gameObject)
    {
        gameObject.transform.SetParent(transform);

        usedObjects.Remove(gameObject);
        unusedObjects.Add(gameObject);
    }

    public bool IsMarkedAsUsed(GameObject gameObject)
    {
        return usedObjects.Contains(gameObject);
    }

    public bool IsMarkedAsUnused(GameObject gameObject)
    {
        return unusedObjects.Contains(gameObject);
    }
}
