namespace Fire_Emblem;

public class IncreaseOpponentStats : BonusEffect
{
    private StatTypeList _bufferedStatsList;
    private List<int> _changeFactorsList;
    
    public IncreaseOpponentStats(StatTypeList bufferedStatsList, List<int> changeFactorsList)
    {
        _bufferedStatsList = bufferedStatsList;
        _changeFactorsList = changeFactorsList;
        this.SetPriority(1);
    }
    
    public override void ApplyEffect(Unit unit, Unit opponent)
    {
        for (int i = 0; i < _bufferedStatsList.Count; i++)
        {
            switch (_bufferedStatsList[i])
            {
                case StatType.Atk:
                    opponent.BonusStatsDiff.Atk += _changeFactorsList[i];
                    break;
                case StatType.Spd:
                    opponent.BonusStatsDiff.Spd += _changeFactorsList[i];
                    break;
                case StatType.Def:
                    opponent.BonusStatsDiff.Def += _changeFactorsList[i];
                    break;
                case StatType.Res:
                    opponent.BonusStatsDiff.Res += _changeFactorsList[i];
                    break;
            }
        }
    }
}