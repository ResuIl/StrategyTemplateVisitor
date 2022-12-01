abstract class OrderProcessTemplate
{
    public bool isGift;
    public abstract void DoSelect();
    public abstract void DoPayment();
    public void GiftWrap()
    {
        try
        {
            Console.WriteLine("Successfuly");
        }
        catch (Exception e)
        {
            Console.WriteLine("Unsuccessfuly");
        }
    }

    public abstract void DoDelivery();
    public void ProcessOrder(bool isGift)
    {
        DoSelect();
        DoPayment();
        if (isGift)
            GiftWrap();
        DoDelivery();
    }
}

class NetOrder : OrderProcessTemplate
{
    public override void DoSelect()
    {
        Console.WriteLine("Item added to online shopping cart");
        Console.WriteLine("Get gift wrap preference");
        Console.WriteLine("Get delivery address.");
    }

    public override void DoPayment() => Console.WriteLine("Online Payment through Netbanking, card or Paytm");
    public override void DoDelivery() => Console.WriteLine("Ship the item through post to delivery address");
}

class StoreOrder : OrderProcessTemplate
{
    public override void DoSelect() => Console.WriteLine("Customer chooses the item from shelf.");
    public override void DoPayment() => Console.WriteLine("Pays at counter through cash/POS");
    public override void DoDelivery() => Console.WriteLine("Item delivered to in delivery counter.");
}

class Program
{
    static void Main()
    {
        OrderProcessTemplate netOrder = new NetOrder();
        netOrder.ProcessOrder(true);
        Console.WriteLine();
        OrderProcessTemplate storeOrder = new StoreOrder();
        storeOrder.ProcessOrder(true);
    }
}