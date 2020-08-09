using Ardalis.SmartEnum;

namespace Domain.Enums
{
    public abstract class Position : SmartEnum<Position>
    {
        public static readonly Position QuarterBack = new QuarterBack("QB", 1);
        public static readonly Position RunningBack = new RunningBack("RB", 2);
        public static readonly Position WideReceiver = new WideReceiver("WR", 3);
        public static readonly Position TightEnd = new TightEnd("TE", 4);
        public static readonly Position Defense = new Defense("DEF", 5);

        public Position(string name, int value) : base(name, value) { }

        public abstract int[] PerYearContractPriceTable();

        // TODO: Revisit ContractOption
    }

    public class QuarterBack : Position
    {
        public QuarterBack(string name, int value) : base(name, value)
        {
        }

        public override int[] PerYearContractPriceTable()
        {
            return new[] { 1, 20, 30, 50, 85, 150 };
        }
    }

    public class RunningBack : Position
    {
        public RunningBack(string name, int value) : base(name, value)
        {
        }

        public override int[] PerYearContractPriceTable()
        {
            return new[] { 1, 50, 80, 120, 200, 300 };
        }
    }

    public class WideReceiver : Position
    {
        public WideReceiver(string name, int value) : base(name, value)
        {
        }

        public override int[] PerYearContractPriceTable()
        {
            return new[] { 1, 30, 40, 60, 90, 150 };
        }
    }

    public class TightEnd : Position
    {
        public TightEnd(string name, int value) : base(name, value)
        {
        }

        public override int[] PerYearContractPriceTable()
        {
            return new[] { 1, 20, 30, 50, 85, 145 };
        }
    }

    public class Defense : Position
    {
        public Defense(string name, int value) : base(name, value)
        {
        }

        public override int[] PerYearContractPriceTable()
        {
            return new[] { 1, 2, 3, 4, 5, 6 };
        }
    }
}
