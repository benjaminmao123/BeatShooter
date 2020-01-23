using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Song", menuName = "Song")]
public class Song : ScriptableObject
{
    public void ComputeTotalScore()
    {
        TotalScore = NoteIndex.Count * SettingsManager.Instance.Settings.GoodHitScoreValue;
    }

    public string Name;
    public string SongTimingPath;
    public string WallIndexPath;
    public string NoteIndexPath;
    public List<float> SongTiming;
    public List<int> WallIndex;
    public List<int> NoteIndex;
    public int TotalScore;
    public float FirstNoteTiming;
    public float GoodHitTime;
}
