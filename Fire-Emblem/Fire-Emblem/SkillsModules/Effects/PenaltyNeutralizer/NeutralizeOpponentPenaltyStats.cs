namespace Fire_Emblem;

public class NeutralizeOpponentPenaltyStats : Effect
{
    private List<StatType> _statsToNeutralize;
    
    public NeutralizeOpponentPenaltyStats(List<StatType> statsToNeutralize)
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
                    opponent.PenaltyNeutralizationManager.Atk = NEUTRALIZED_STAT_VALUE;
                    break;
                case StatType.Spd:
                    opponent.PenaltyNeutralizationManager.Spd = NEUTRALIZED_STAT_VALUE;
                    break;
                case StatType.Def:
                    opponent.PenaltyNeutralizationManager.Def = NEUTRALIZED_STAT_VALUE;
                    break;
                case StatType.Res:
                    opponent.PenaltyNeutralizationManager.Res = NEUTRALIZED_STAT_VALUE;
                    break;
                case StatType.HP:
                    opponent.PenaltyNeutralizationManager.HP = NEUTRALIZED_STAT_VALUE;
                    break;
            }
        }
    } 
}