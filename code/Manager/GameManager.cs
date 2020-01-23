using System.Collections;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private void OnEnable()
    {
        GameEvents.OnSongStart += OnSongStart;
        GameEvents.OnHitGood += OnHitGood;
        GameEvents.OnHitBad += OnHitBad;
        GameEvents.OnHitMiss += OnHitMiss;
        GameEvents.OnDeath += OnDeath;
    }

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        CurrentIndex = 0;
    }
    void OnSongStart()
    {
        StartCoroutine(Run());
    }

    IEnumerator PlaySong(float songDelay)
    {
        yield return new WaitForSeconds(songDelay);

        AudioManager.Instance.Play(SongManager.Instance.CurrentSong.Name);
    }

    IEnumerator Run()
    {
        yield return new WaitForSeconds(SettingsManager.Instance.Settings.StartDelay);

        float songDelay = SongManager.Instance.CurrentSong.GoodHitTime - SongManager.Instance.CurrentSong.FirstNoteTiming;

        if (songDelay >= 0)
        {
            StartCoroutine(PlaySong(songDelay));
        }

        while (true)
        {
            NoteManager.Instance.EnableNote(SongManager.Instance.CurrentSong.WallIndex[WallIndex], SongManager.Instance.CurrentSong.NoteIndex[NoteIndex]);
            ++TimingIndex;
            ++WallIndex;
            ++NoteIndex;

            if (TimingIndex >= SongManager.Instance.CurrentSong.SongTiming.Count)
            {
                break;
            }

            if (EndGame)
            { 
                break;
            }

            yield return new WaitForSeconds(SongManager.Instance.CurrentSong.SongTiming[TimingIndex]);
        }

        yield return new WaitForSeconds(SettingsManager.Instance.Settings.EndDelay);

        EndGame = false;
        PlayerPrefs.Save();
        LevelManager.Instance.LoadNextScene("PostGame");
    }

    void OnDeath()
    {
        AudioManager.Instance.Stop(SongManager.Instance.CurrentSong.Name);
        NoteManager.Instance.DisableAllNotes();
        EndGame = true;
    }

    void OnHitGood()
    {
        UIEvents.ScoreChanged(SettingsManager.Instance.Settings.GoodHitScoreValue);
        AudioManager.Instance.Play("Hit Good");
    }

    void OnHitBad()
    {
        UIEvents.ScoreChanged(SettingsManager.Instance.Settings.BadHitScoreValue);
        AudioManager.Instance.Play("Hit Bad");
    }

    void OnHitMiss(GameObject gameObject)
    {
        ++CurrentIndex;
        AudioManager.Instance.Play("Hit Miss");
        GameObject bullet = Instantiate(Bullet, gameObject.transform.position, gameObject.transform.rotation);
        Utility.FaceTarget(bullet.transform, Player.transform);
    }

    private void OnDisable()
    {
        GameEvents.OnSongStart -= OnSongStart;
        GameEvents.OnHitGood -= OnHitGood;
        GameEvents.OnHitBad -= OnHitBad;
        GameEvents.OnHitMiss -= OnHitMiss;
        GameEvents.OnDeath -= OnDeath;
    }

    [SerializeField] GameObject Bullet;
    GameObject Player;
    int TimingIndex;
    int WallIndex;
    int NoteIndex;
    public int CurrentIndex;
    public bool EndGame;
}
