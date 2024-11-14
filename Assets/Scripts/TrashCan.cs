using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCan : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<TrashZone>().OnEnterEvent.AddListener(RemoveTrash);
    }

    public void RemoveTrash(GameObject go)
    {
        if (go != null)
        {
            Destroy(go);
        }
    }
}
