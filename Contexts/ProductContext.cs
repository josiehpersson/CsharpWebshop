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
        Customer c1 = new Customer {Id = 1, Name="Philip Sidlo", Address="Fridensborgsv�gen 161", ZipCode="17062", City="Solna"};
        Customer c2 = new Customer {Id = 2, Name="Arja Halkola", Address="Betongv�gen 9", ZipCode="17062", City="B�lsta"};
        Customer c3 = new Customer {Id = 3, Name="Jessica Persson", Address="Brushanev�gen 26", ZipCode="17062", City="Bro"};
        Customer c4 = new Customer {Id = 4, Name="Izabelle Persson", Address="Gamlaekenv�gen 89", ZipCode="17062", City="�rsundsbro"};
        Customer c5 = new Customer {Id = 5, Name="Anni Halkola", Address="Stenv�gen 20", ZipCode="17062", City="Smedjebacken"};
        Customer c6 = new Customer {Id = 6, Name="Rauno Halkola", Address="Lustikullsv�gen 20", ZipCode="17062", City="Ludvika"};
        modelBuilder.Entity<Customer>().HasData(c1, c2, c3, c4, c5, c6);

        //PRODUCT-SEEDS
        Product p1 = new Product {Id = 1,
                                  Title = "Focal h�rlurar Utopia", 
                                  Description= "Focal Utopia �r en referensh�rlur fr�n Franska Focal med deras v�lk�nda Beryllium-element! Utopia h�rluren ing�r i deras storsatsning av High-End h�rlurar d�r Utopia �r toppmodellen och ett statement fr�n f�retaget. Konstruktionen p�minner mer om en h�gtalare d�r ett 40mm Beryllium-element tar hand om hela registret.",
                                  Image = "https://www.hembiobutiken.se/images/prod/242660_2.jpg",
                                  Price = 44990};
        Product p2 = new Product {Id = 2,
                                  Title = "Hifiman Susvara", 
                                  Description= "Hifiman Susvara �r bolagets toppmodell och tar vara p� Hifimans spetskompetens n�r det g�ller att utveckla en high-end lur f�r inbitna musik�lskare. Styrkan ligger i deras planarelement som tar fram en extremt stor och naturlig ljudbild med l�g distorsion och b�sta m�jliga ljudupplevelse. Susvara anv�nder sig av ett �Stealth� magnetsystem som �r en av deras senaste innovationer tillsammans med deras nanometer-membran som �r ett av v�rldens tunnaste material. Det h�r �r en otroligt v�lbyggd h�rlur som andas lyx och v�lljud och bara m�ste upplevas!",
                                  Image = "https://www.hembiobutiken.se/images/prod/293280_2.jpg",
                                  Price = 65990};
        Product p3 = new Product {Id = 3,
                                  Title = "Focal h�rlurar Stellia", 
                                  Description= "Stellia �r en sluten referensh�rlur fr�n Focal, den franska anrika Hi-Fi-tillverkaren som dominerat h�rlursmarknaden f�r b�ttre h�rlurar de senaste �ren. De flesta detaljerna �r h�mtade fr�n Utopia-modellen men med den stora skillnaden att detta �r en sluten modell. L�cker design och ett fantastiskt ljud g�r att vi varmt kan rekommendera denna exklusiva h�rlur.",
                                  Image = "https://www.hembiobutiken.se/images/prod/290260_2.jpg",
                                  Price = 33990};
        Product p4 = new Product {Id = 4,
                                  Title = "Kennerton Odin", 
                                  Description= "Kennerton Odin �r ett par referensh�rlurar med planar-magnetic konstruktion, egenbyggda element tillverkade i Ryssland. Odin spelar med en imponerade dynamik och transparens och m�lar upp klangbilden �t det varmare h�llet utan f�rlorad finess eller detalj.",
                                  Image = "https://www.hembiobutiken.se/images/prod/273110_2.jpg",
                                  Price = 25990};
        Product p5 = new Product {Id = 5,
                                  Title = "Hifiman Arya", 
                                  Description= "Hifiman Arya �r en enast�ende hifi-h�rlur f�r de som l�ngtar efter riktigt v�lljud. Inspirationen till Arya ligger i den tidigare HE-1000 V2, enligt m�nga en av de b�sta h�rlurarna de h�rt, och anv�nder planarmagnetiska element med nanometer-membran. V�rldens tunnaste element som tar fram detaljer p� ett mycket imponerande s�tt samtidigt som ljudet bli otroligt transparent och helt neutralt.",
                                  Image = "https://www.hembiobutiken.se/images/prod/293190_2.jpg",
                                  Price = 18990};
        Product p6 = new Product {Id = 6,
                                  Title = "Focal h�rlurar Clear", 
                                  Description= "Focal Clear �r en helt ny mellanmodell av Focals premiumlurar. Clear befinner sig prism�ssigt under referensmodellen Utopia men bygger p� samma filosofi, med enklare materialval. Focal Clear �r handbyggd i Frankrike.",
                                  Image = "https://www.hembiobutiken.se/images/prod/267210_2.jpg",
                                  Price = 17990};
        Product p7 = new Product {Id = 7,
                                  Title = "Klipsch Heritage HP-3", 
                                  Description= "Klipsch Heritage HP-3 �r en halv�ppen stereolur i Klipsch hyllade Heritage-serie. Kraftulla 52 mm-element med premium byggkvalitet och en h�ftig design med k�por i solid tr�, huvudband i kol�der och precisionstillverkade aluminiumkomponenter. En fantastisk h�rlur som tar vara p� Klipsch dynamiska spelstil.",
                                  Image = "https://www.hembiobutiken.se/images/prod/282840_2.jpg",
                                  Price = 13990};
        Product p8 = new Product {Id = 8,
                                  Title = "Hifiman Ananda-BT", 
                                  Description= "Hifiman Ananda-BT �r en tr�dl�s �ppen h�rlur med st�d f�r h�guppl�st ljud och enast�ende ljudkvalitet i high-end klass.",
                                  Image = "https://www.hembiobutiken.se/images/prod/318420-hifiman-ananda-bt-579_2.jpg",
                                  Price = 13990};
        Product p9 = new Product {Id = 9,
                                  Title = "Audio Technica ATH-W5000", 
                                  Description= "Audio Technica ATH-W5000 �r det japanska bolagets referensh�rlur och en uts�kt kompanjon runt �ronen. Njut av ett rikt och fylligt ljud fr�n dessa slutna hi-end lurar med exklusiva och specialbyggda element inuti ebenholtstr�-k�por som ger den extra luxu�sa k�nslan!",
                                  Image = "https://www.hembiobutiken.se/images/prod/210840_2.jpg",
                                  Price = 13795};
        Product p10 = new Product {Id = 10,
                                  Title = "Focal h�rlurar Elear", 
                                  Description= "Focal Elear �r en High-End h�rlur fr�n Franska Focal och r�knas som lillebror till referensmodellen Utopia. Elear bygger p� samma filosofi och t�nk som sin storebror men med mycket enklare materialval f�r att f� ner kostnaden och ge dig som lyssnare ett steg in till High-End v�rldens mitt till en betydligt l�gre kostnad.",
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