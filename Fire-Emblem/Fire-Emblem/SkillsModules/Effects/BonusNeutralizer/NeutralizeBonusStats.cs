namespace Fire_Emblem;

public class NeutralizeBonusOnStats : Effect
{
    private List<StatType> _statsToNeutralize;
    
    public NeutralizeBonusOnStats(List<StatType> statsToNeutralize)
    {
        _statsToNeutralize = statsToNeutralize;
        this.SetPriority(1);
    }

    public override void ApplyEffect(Unit unit, Unit opponent)
    {
        const int NEUTRALIZED_STAT_VALUE = 0;
        foreach (var stat in _statsToNeutralize)
        {
            switch (stat)
            {
                case StatType.Atk:
                    unit.BonusNeutralizationManager.Atk = NEUTRALIZED_STAT_VALUE;
                    break;
                case StatType.Spd:
                    unit.BonusNeutralizationManager.Spd = NEUTRALIZED_STAT_VALUE;
                    break;
                case StatType.Def:
                    unit.BonusNeutralizationManager.Def = NEUTRALIZED_STAT_VALUE;
                    break;
                case StatType.Res:
                    unit.BonusNeutralizationManager.Res = NEUTRALIZED_STAT_VALUE;
                    break;
                case StatType.HP:
                    unit.BonusNeutralizationManager.HP = NEUTRALIZED_STAT_VALUE;
                    break;
            }
        }
    }
}