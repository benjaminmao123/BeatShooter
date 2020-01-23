using System;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager : Singleton<NoteManager>
{
    void Start()
    {
        Walls = new List<GameObject>();
        Walls.Add(GameObject.FindGameObjectWithTag("Left"));
        Walls.Add(GameObject.FindGameObjectWithTag("Middle"));
        Walls.Add(GameObject.FindGameObjectWithTag("Right"));

        WallNotes = new List<ColorChanger[]>();
        WallNotes.Add(Walls[0].GetComponentsInChildren<ColorChanger>());
        WallNotes.Add(Walls[1].GetComponentsInChildren<ColorChanger>());
        WallNotes.Add(Walls[2].GetComponentsInChildren<ColorChanger>());

        WallRenderers = new List<Renderer>();
        WallRenderers.Add(Walls[0].GetComponent<Renderer>());
        WallRenderers.Add(Walls[1].GetComponent<Renderer>());
        WallRenderers.Add(Walls[2].GetComponent<Renderer>());

        OriginalWallMaterial = WallRenderers[0].material;

        GameEvents.SongStart();
    }

    public void EnableNote(int wallIndex, int noteIndex)
    {
        WallNotes[wallIndex][noteIndex].enabled = true;
        WallNotes[wallIndex][noteIndex].Index = Index;
        ++Index;
    }

    public void DisableAllNotes()
    {
        WallNotes.ForEach(colorChangers => Array.ForEach(colorChangers, colorChanger => colorChanger.enabled = false));
    }

    private void Update()
    {
        for (int i = 0; i < WallNotes.Count; ++i)
        {
            for (int j = 0; j < WallNotes[i].Length; ++j)
            {
                if (WallNotes[i][j].enabled)
                {
                    WallRenderers[i].material = HighlightMaterial;
                    break;
                }
                else
                {
                    WallRenderers[i].material = OriginalWallMaterial;
                }
            }
        }
    }

    List<GameObject> Walls;
    List<Renderer> WallRenderers;
    Material OriginalWallMaterial;
    public List<ColorChanger[]> WallNotes;
    [SerializeField] Material HighlightMaterial;
    int Index;
}
