public class SettingsManager : Singleton<SettingsManager>
{
    protected override void Awake()
    {
        base.Awake();

        DontDestroyOnLoad(gameObject);
    }

    public Settings Settings;
}
