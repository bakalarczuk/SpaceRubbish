using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int trashesCollected = 0;
    [SerializeField] private List<GameObject> trashesToCollect = new List<GameObject>();

    [SerializeField] private TextMeshProUGUI rubbishLeftText;
    [SerializeField] private TextMeshProUGUI rubbishCollectedText;

    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); 
        }
        else
        {
            Instance = this; 
            DontDestroyOnLoad(gameObject); 
        }
    }

    private void Start()
    {
        rubbishCollectedText.text = trashesCollected.ToString("F0");
        rubbishLeftText.text = (trashesToCollect.Count - trashesCollected).ToString("F0");
    }

    public void CollectTrash()
    {
        trashesCollected++;
        rubbishCollectedText.text = trashesCollected.ToString("F0");
        rubbishLeftText.text = (trashesToCollect.Count - trashesCollected).ToString("F0");

    }
}
