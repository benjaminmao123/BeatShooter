using System.Collections.Generic;

public class SongManager : Singleton<SongManager>
{
    protected override void Awake()
    {
        base.Awake();

        DontDestroyOnLoad(gameObject);

        foreach (Song song in Songs)
        {
            SongReader fileReader = new SongReader(song.SongTimingPath);
            fileReader.ReadSongTiming(ref song.SongTiming);
            fileReader = new SongReader(song.WallIndexPath);
            fileReader.ReadSongIndex(ref song.WallIndex);
            fileReader = new SongReader(song.NoteIndexPath);
            fileReader.ReadSongIndex(ref song.NoteIndex);
        }
    }

    private void Start()
    {
        Songs.ForEach(song => song.ComputeTotalScore());
    }

    public void SetSong(string name)
    {
        CurrentSong = Songs.Find(song => song.Name == name);
    }

    public List<Song> Songs;
    public Song CurrentSong;
}
