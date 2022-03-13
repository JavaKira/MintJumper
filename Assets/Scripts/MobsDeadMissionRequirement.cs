public class MobsDeadMissionRequirement : MissionRequirement
{
    private readonly Mob _mobType;

    public MobsDeadMissionRequirement(string title, Mob mobType) : base(title)
    {
        _mobType = mobType;
    }

    public override void AddDoneCheck()
    {
        Game.Instance.Stats.Changed.AddListener( () =>
        {
            if (Game.Instance.Stats.GetMobsLive(_mobType.name) == 0)
                DoneEvent.Invoke();
        });
    }
}