using Microsoft.EntityFrameworkCore;




public class ProductContext : DbContext
{
    public ProductContext(DbContextOptions<ProductContext> options)
    : base(options) {}

protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
    optionsBuilder.UseSqlite("Data Source=Db/webshop.db");
}
    public DbSet<Product> Products { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<OrderRow> OrderRows { get; set; }
    public DbSet<Order> Orders { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<OrderRow>()
            .HasKey(or => new { or.OrderId, or.ProductId });
        modelBuilder.Entity<OrderRow>()
           //.HasForeignKey(p => p.ProductId)
            .HasOne(or => or.Product)
            .WithMany(p => p.OrderRows);
        modelBuilder.Entity<OrderRow>()
            .HasOne(or => or.Order)
            .WithMany(o => o.OrderRows);
            //.HasForeignKey(o => o.OrderId);
        modelBuilder.Entity<OrderRow>()
            .HasKey(or => new { or.OrderId, or.ProductId });
        modelBuilder.Entity<Order>()
            .HasOne(o=> o.Customer)
            .WithMany(c=> c.Orders);

        //CUSTOMER-SEEDS
        Customer c1 = new Customer {Id = 1, Name="Philip Sidlo", Address="Fridensborgsvägen 161", ZipCode="17062", City="Solna"};
        Customer c2 = new Customer {Id = 2, Name="Arja Halkola", Address="Betongvägen 9", ZipCode="17062", City="Bålsta"};
        Customer c3 = new Customer {Id = 3, Name="Jessica Persson", Address="Brushanevägen 26", ZipCode="17062", City="Bro"};
        Customer c4 = new Customer {Id = 4, Name="Izabelle Persson", Address="Gamlaekenvägen 89", ZipCode="17062", City="Örsundsbro"};
        Customer c5 = new Customer {Id = 5, Name="Anni Halkola", Address="Stenvägen 20", ZipCode="17062", City="Smedjebacken"};
        Customer c6 = new Customer {Id = 6, Name="Rauno Halkola", Address="Lustikullsvägen 20", ZipCode="17062", City="Ludvika"};
        modelBuilder.Entity<Customer>().HasData(c1, c2, c3, c4, c5, c6);

        //PRODUCT-SEEDS
        Product p1 = new Product {Id = 1,
                                  Title = "Focal hörlurar Utopia", 
                                  Description= "Focal Utopia är en referenshörlur från Franska Focal med deras välkända Beryllium-element! Utopia hörluren ingår i deras storsatsning av High-End hörlurar där Utopia är toppmodellen och ett statement från företaget. Konstruktionen påminner mer om en högtalare där ett 40mm Beryllium-element tar hand om hela registret.",
                                  Image = "https://www.hembiobutiken.se/images/prod/242660_2.jpg",
                                  Price = 44990};
        Product p2 = new Product {Id = 2,
                                  Title = "Hifiman Susvara", 
                                  Description= "Hifiman Susvara är bolagets toppmodell och tar vara på Hifimans spetskompetens när det gäller att utveckla en high-end lur för inbitna musikälskare. Styrkan ligger i deras planarelement som tar fram en extremt stor och naturlig ljudbild med låg distorsion och bästa möjliga ljudupplevelse. Susvara använder sig av ett ”Stealth” magnetsystem som är en av deras senaste innovationer tillsammans med deras nanometer-membran som är ett av världens tunnaste material. Det här är en otroligt välbyggd hörlur som andas lyx och välljud och bara måste upplevas!",
                                  Image = "https://www.hembiobutiken.se/images/prod/293280_2.jpg",
                                  Price = 65990};
        Product p3 = new Product {Id = 3,
                                  Title = "Focal hörlurar Stellia", 
                                  Description= "Stellia är en sluten referenshörlur från Focal, den franska anrika Hi-Fi-tillverkaren som dominerat hörlursmarknaden för bättre hörlurar de senaste åren. De flesta detaljerna är hämtade från Utopia-modellen men med den stora skillnaden att detta är en sluten modell. Läcker design och ett fantastiskt ljud gör att vi varmt kan rekommendera denna exklusiva hörlur.",
                                  Image = "https://www.hembiobutiken.se/images/prod/290260_2.jpg",
                                  Price = 33990};
        Product p4 = new Product {Id = 4,
                                  Title = "Kennerton Odin", 
                                  Description= "Kennerton Odin är ett par referenshörlurar med planar-magnetic konstruktion, egenbyggda element tillverkade i Ryssland. Odin spelar med en imponerade dynamik och transparens och målar upp klangbilden åt det varmare hållet utan förlorad finess eller detalj.",
                                  Image = "https://www.hembiobutiken.se/images/prod/273110_2.jpg",
                                  Price = 25990};
        Product p5 = new Product {Id = 5,
                                  Title = "Hifiman Arya", 
                                  Description= "Hifiman Arya är en enastående hifi-hörlur för de som längtar efter riktigt välljud. Inspirationen till Arya ligger i den tidigare HE-1000 V2, enligt många en av de bästa hörlurarna de hört, och använder planarmagnetiska element med nanometer-membran. Världens tunnaste element som tar fram detaljer på ett mycket imponerande sätt samtidigt som ljudet bli otroligt transparent och helt neutralt.",
                                  Image = "https://www.hembiobutiken.se/images/prod/293190_2.jpg",
                                  Price = 18990};
        Product p6 = new Product {Id = 6,
                                  Title = "Focal hörlurar Clear", 
                                  Description= "Focal Clear är en helt ny mellanmodell av Focals premiumlurar. Clear befinner sig prismässigt under referensmodellen Utopia men bygger på samma filosofi, med enklare materialval. Focal Clear är handbyggd i Frankrike.",
                                  Image = "https://www.hembiobutiken.se/images/prod/267210_2.jpg",
                                  Price = 17990};
        Product p7 = new Product {Id = 7,
                                  Title = "Klipsch Heritage HP-3", 
                                  Description= "Klipsch Heritage HP-3 är en halvöppen stereolur i Klipsch hyllade Heritage-serie. Kraftulla 52 mm-element med premium byggkvalitet och en häftig design med kåpor i solid trä, huvudband i koläder och precisionstillverkade aluminiumkomponenter. En fantastisk hörlur som tar vara på Klipsch dynamiska spelstil.",
                                  Image = "https://www.hembiobutiken.se/images/prod/282840_2.jpg",
                                  Price = 13990};
        Product p8 = new Product {Id = 8,
                                  Title = "Hifiman Ananda-BT", 
                                  Description= "Hifiman Ananda-BT är en trådlös öppen hörlur med stöd för högupplöst ljud och enastående ljudkvalitet i high-end klass.",
                                  Image = "https://www.hembiobutiken.se/images/prod/318420-hifiman-ananda-bt-579_2.jpg",
                                  Price = 13990};
        Product p9 = new Product {Id = 9,
                                  Title = "Audio Technica ATH-W5000", 
                                  Description= "Audio Technica ATH-W5000 är det japanska bolagets referenshörlur och en utsökt kompanjon runt öronen. Njut av ett rikt och fylligt ljud från dessa slutna hi-end lurar med exklusiva och specialbyggda element inuti ebenholtsträ-kåpor som ger den extra luxuösa känslan!",
                                  Image = "https://www.hembiobutiken.se/images/prod/210840_2.jpg",
                                  Price = 13795};
        Product p10 = new Product {Id = 10,
                                  Title = "Focal hörlurar Elear", 
                                  Description= "Focal Elear är en High-End hörlur från Franska Focal och räknas som lillebror till referensmodellen Utopia. Elear bygger på samma filosofi och tänk som sin storebror men med mycket enklare materialval för att få ner kostnaden och ge dig som lyssnare ett steg in till High-End världens mitt till en betydligt lägre kostnad.",
                                  Image = "https://www.hembiobutiken.se/images/prod/242810_2.jpg",
                                  Price = 10990};

        modelBuilder.Entity<Product>().HasData(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10);

        //ORDER-SEEDS
        Order o1 = new Order {Id = 1, TotalPrice=320, CustomerId=c1.Id};
        Order o2= new Order {Id = 2, TotalPrice=5320, CustomerId=c2.Id};
        Order o3 = new Order {Id = 3, TotalPrice=65000, CustomerId=c3.Id};
        Order o4 = new Order {Id = 4, TotalPrice=47500, CustomerId=c4.Id};
        Order o5 = new Order {Id=5, TotalPrice=10300, CustomerId=c5.Id};
        Order o6 = new Order {Id=6, TotalPrice=6500, CustomerId=c6.Id};
        modelBuilder.Entity<Order>().HasData(o1, o2, o3, o4, o5, o6);

        //ORDERROW-SEEDS

        modelBuilder.Entity<OrderRow>().HasData(new OrderRow{OrderId = o1.Id, ProductId = p2.Id});
        modelBuilder.Entity<OrderRow>().HasData(new OrderRow{OrderId = o1.Id, ProductId = p1.Id});



    }
}