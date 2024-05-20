namespace Fire_Emblem;

public class NeutralizeOpponentBonusStats : Effect
{
    private StatTypeList _statsToNeutralize;
    
    public NeutralizeOpponentBonusStats(StatTypeList statsToNeutralize)
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
                    opponent.BonusNeutralizationManager.Atk = NEUTRALIZED_STAT_VALUE;
                    break;
                case StatType.Spd:
                    opponent.BonusNeutralizationManager.Spd = NEUTRALIZED_STAT_VALUE;
                    break;
                case StatType.Def:
                    opponent.BonusNeutralizationManager.Def = NEUTRALIZED_STAT_VALUE;
                    break;
                case StatType.Res:
                    opponent.BonusNeutralizationManager.Res = NEUTRALIZED_STAT_VALUE;
                    break;
                case StatType.HP:
                    opponent.BonusNeutralizationManager.HP = NEUTRALIZED_STAT_VALUE;
                    break;
            }
        }
    }
}