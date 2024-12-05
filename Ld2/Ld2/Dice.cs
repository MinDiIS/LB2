public class Dice
{
    public TypeColor typeColor;
    public int GetReversCount(TypeColor typeColor, int first)
    {
        if (typeColor.Equals(TypeColor.White)) return first;
        else
        {
            switch (first)
            {
                case 1:
                    return 6;
                case 2:
                    return 5;
                case 3:
                    return 4;
                case 4:
                    return 3;
                case 5:
                    return 2;
                case 6: return 1;
                default:
                    return 0;
            }
        }
    }
    public Dice(TypeColor newColor)
    {
        typeColor = newColor;
    }
}
public enum TypeColor
{
    Black, White
}