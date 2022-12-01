interface ItemElement
{
    int Accept(ShoppingCartVisitor visitor);
}

class Book : ItemElement
{
    private int price;
    private string isbnNumber;
    public Book(int cost, string isbn)
    {
        price = cost;
        isbnNumber = isbn;
    }
    public int GetPrice() => price;
    public string GetIsbnNumber() => isbnNumber;

    public int Accept(ShoppingCartVisitor visitor) => visitor.Visit(this);
}

class Fruit : ItemElement
{
    private int pricePerKG;
    private int weight;
    private string name;

    public Fruit(int pricePerKG, int weight, string name)
    {
        this.pricePerKG = pricePerKG;
        this.weight = weight;
        this.name = name;
    }

    public int GetPricePerKG() => pricePerKG;
    public int GetWeight() => weight;
    public string GetName() => name;
    public int Accept(ShoppingCartVisitor visitor) => visitor.Visit(this);
}

interface ShoppingCartVisitor
{
    int Visit(Book book);
    int Visit(Fruit fruit);
}

class ShoppingCartVisitorImpl : ShoppingCartVisitor
{
    public int Visit(Book book)
    {
        int cost = 0;
        if (book.GetPrice() > 50)
            cost = book.GetPrice() - 5;
        else
            cost = book.GetPrice();
        Console.WriteLine("Book ISBN: " + book.GetIsbnNumber() + " Cost: " + cost);
        return cost;
    }

    public int Visit(Fruit fruit)
    {
        int cost = fruit.GetPricePerKG() * fruit.GetWeight();
        Console.WriteLine(fruit.GetName() + " Cost: " + cost);
        return cost;
    }
}

class Program
{
    static void Main()
    {
        ItemElement[] items = new ItemElement[] { new Book(20, "1234"), new Book(100, "123123123"), new Fruit(10, 2, "Apple") };
        int sum = 0;
        foreach (var item in items)
            sum = sum + item.Accept(new ShoppingCartVisitorImpl());
        Console.WriteLine("Total Price: " + sum);
    }
}