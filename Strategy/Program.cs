interface Strategy
{
    void Solve();
}

abstract class StrategySolution : Strategy
{
    public void Solve()
    {
        Start();
        while (NextTry() && !isSolution()) { }
        Stop();
    }

    public abstract void Start();
    public abstract bool NextTry();
    public abstract bool isSolution();
    public abstract void Stop();
}

class Foo : StrategySolution
{
    private int State = 1;
    public override void Start() => Console.WriteLine("Start");
    public override bool NextTry()
    {
        Console.WriteLine("NextTry - " + State++);
        return true;
    }
    public override bool isSolution()
    {
        Console.WriteLine("IsSolution " + (State == 3));
        return State == 3;
    }
    public override void Stop() => Console.WriteLine("Stop");
}

abstract class StrategySearch : Strategy
{
    public void Solve()
    {
        while(true)
        {
            PreProcess();
            if (Search())
                break;
            PostProcess();
        }
    }

    public abstract void PreProcess();
    public abstract bool Search();
    public abstract void PostProcess();
}

class Bar : StrategySearch
{
    private int State = 1;
    public override void PreProcess() => Console.WriteLine("PreProcess");
    public override bool Search()
    {
        Console.WriteLine("Search " + State++);
        return State == 3 ? true : false;
    }
    public override void PostProcess() => Console.WriteLine("PostProcess");
}

class Program
{
    private static void Execute(Strategy strategy) 
    {
        strategy.Solve();
    }

    static void Main()
    {
        List<Strategy> list = new List<Strategy>();
        list.Add(new Foo());
        list.Add(new Bar());
        foreach (var item in list)
            Execute(item);
    }
}