using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HistoryUI : MonoBehaviour {

    public Font m_font;
    public GameObject m_historyEntriesParentGO;
    private List<GameObject> historyEntries;

    private void Awake()
    {
        historyEntries = new List<GameObject>();
    }

    public void AddEntry(string name)
    {
        GameObject newGO = new GameObject("name");
        newGO.transform.parent = m_historyEntriesParentGO.transform;
        UnityEngine.UI.Text txt = newGO.AddComponent<UnityEngine.UI.Text>();
        txt.text = name;
        txt.color = Color.black;
        txt.font = m_font;
        txt.rectTransform.sizeDelta = new Vector2(txt.rectTransform.sizeDelta.x, 24);
        txt.alignment = TextAnchor.MiddleCenter;
        historyEntries.Add(newGO);
    }

    public void RemoveLastEntry()
    {
        Destroy(historyEntries[historyEntries.Count - 1]);
        historyEntries.RemoveAt(historyEntries.Count - 1);
    }
}
