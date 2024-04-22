using TMPro;
using UnityEngine;

public class StatAnzeige : MonoBehaviour
{
    public TMP_Text firstTime;
    public TMP_Text secondTime;
    public TMP_Text firstKills;
    public TMP_Text secondKills;

    private StatTracker _statTracker;

    private void Start()
    {
        _statTracker = StatTracker.Instance;
    }

    private void Update()
    {
        _statTracker.ShowStats(this);
    }
}
