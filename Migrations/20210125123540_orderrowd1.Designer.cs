﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace dotnetwebshop.Migrations
{
    [DbContext(typeof(ProductContext))]
    [Migration("20210125123540_orderrowd1")]
    partial class orderrowd1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .HasColumnType("TEXT");

                    b.Property<string>("City")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("ZipCode")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Fridensborgsvägen 161",
                            City = "Solna",
                            Name = "Philip Sidlo",
                            ZipCode = 17062
                        },
                        new
                        {
                            Id = 2,
                            Address = "Betongvägen 9",
                            City = "Bålsta",
                            Name = "Arja Halkola",
                            ZipCode = 74633
                        },
                        new
                        {
                            Id = 3,
                            Address = "Brushanevägen 26",
                            City = "Bro",
                            Name = "Jessica Persson",
                            ZipCode = 12345
                        },
                        new
                        {
                            Id = 4,
                            Address = "Gamlaekenvägen 89",
                            City = "Örsundsbro",
                            Name = "Izabelle Persson",
                            ZipCode = 17062
                        },
                        new
                        {
                            Id = 5,
                            Address = "Stenvägen 20",
                            City = "Smedjebacken",
                            Name = "Anni Halkola",
                            ZipCode = 77733
                        },
                        new
                        {
                            Id = 6,
                            Address = "Lustikullsvägen 20",
                            City = "Ludvika",
                            Name = "Rauno Halkola",
                            ZipCode = 77712
                        });
                });

            modelBuilder.Entity("Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<int>("CustomerId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TotalPrice")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CustomerId = 1,
                            TotalPrice = 320
                        },
                        new
                        {
                            Id = 2,
                            Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CustomerId = 2,
                            TotalPrice = 5320
                        },
                        new
                        {
                            Id = 3,
                            Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CustomerId = 3,
                            TotalPrice = 65000
                        },
                        new
                        {
                            Id = 4,
                            Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CustomerId = 4,
                            TotalPrice = 47500
                        },
                        new
                        {
                            Id = 5,
                            Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CustomerId = 5,
                            TotalPrice = 10300
                        },
                        new
                        {
                            Id = 6,
                            Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CustomerId = 6,
                            TotalPrice = 6500
                        });
                });

            modelBuilder.Entity("OrderRow", b =>
                {
                    b.Property<int>("OrderId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProductId")
                        .HasColumnType("INTEGER");

                    b.HasKey("OrderId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderRows");

                    b.HasData(
                        new
                        {
                            OrderId = 1,
                            ProductId = 2
                        },
                        new
                        {
                            OrderId = 1,
                            ProductId = 1
                        });
                });

            modelBuilder.Entity("Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Image")
                        .HasColumnType("TEXT");

                    b.Property<int>("Price")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Focal Utopia är en referenshörlur från Franska Focal med deras välkända Beryllium-element! Utopia hörluren ingår i deras storsatsning av High-End hörlurar där Utopia är toppmodellen och ett statement från företaget. Konstruktionen påminner mer om en högtalare där ett 40mm Beryllium-element tar hand om hela registret.",
                            Image = "https://www.hembiobutiken.se/images/prod/242660_2.jpg",
                            Price = 44990,
                            Title = "Focal hörlurar Utopia"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Hifiman Susvara är bolagets toppmodell och tar vara på Hifimans spetskompetens när det gäller att utveckla en high-end lur för inbitna musikälskare. Styrkan ligger i deras planarelement som tar fram en extremt stor och naturlig ljudbild med låg distorsion och bästa möjliga ljudupplevelse. Susvara använder sig av ett ”Stealth” magnetsystem som är en av deras senaste innovationer tillsammans med deras nanometer-membran som är ett av världens tunnaste material. Det här är en otroligt välbyggd hörlur som andas lyx och välljud och bara måste upplevas!",
                            Image = "https://www.hembiobutiken.se/images/prod/293280_2.jpg",
                            Price = 65990,
                            Title = "Hifiman Susvara"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Stellia är en sluten referenshörlur från Focal, den franska anrika Hi-Fi-tillverkaren som dominerat hörlursmarknaden för bättre hörlurar de senaste åren. De flesta detaljerna är hämtade från Utopia-modellen men med den stora skillnaden att detta är en sluten modell. Läcker design och ett fantastiskt ljud gör att vi varmt kan rekommendera denna exklusiva hörlur.",
                            Image = "https://www.hembiobutiken.se/images/prod/290260_2.jpg",
                            Price = 33990,
                            Title = "Focal hörlurar Stellia"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Kennerton Odin är ett par referenshörlurar med planar-magnetic konstruktion, egenbyggda element tillverkade i Ryssland. Odin spelar med en imponerade dynamik och transparens och målar upp klangbilden åt det varmare hållet utan förlorad finess eller detalj.",
                            Image = "https://www.hembiobutiken.se/images/prod/273110_2.jpg",
                            Price = 25990,
                            Title = "Kennerton Odin"
                        },
                        new
                        {
                            Id = 5,
                            Description = "Hifiman Arya är en enastående hifi-hörlur för de som längtar efter riktigt välljud. Inspirationen till Arya ligger i den tidigare HE-1000 V2, enligt många en av de bästa hörlurarna de hört, och använder planarmagnetiska element med nanometer-membran. Världens tunnaste element som tar fram detaljer på ett mycket imponerande sätt samtidigt som ljudet bli otroligt transparent och helt neutralt.",
                            Image = "https://www.hembiobutiken.se/images/prod/293190_2.jpg",
                            Price = 18990,
                            Title = "Hifiman Arya"
                        },
                        new
                        {
                            Id = 6,
                            Description = "Focal Clear är en helt ny mellanmodell av Focals premiumlurar. Clear befinner sig prismässigt under referensmodellen Utopia men bygger på samma filosofi, med enklare materialval. Focal Clear är handbyggd i Frankrike.",
                            Image = "https://www.hembiobutiken.se/images/prod/267210_2.jpg",
                            Price = 17990,
                            Title = "Focal hörlurar Clear"
                        },
                        new
                        {
                            Id = 7,
                            Description = "Klipsch Heritage HP-3 är en halvöppen stereolur i Klipsch hyllade Heritage-serie. Kraftulla 52 mm-element med premium byggkvalitet och en häftig design med kåpor i solid trä, huvudband i koläder och precisionstillverkade aluminiumkomponenter. En fantastisk hörlur som tar vara på Klipsch dynamiska spelstil.",
                            Image = "https://www.hembiobutiken.se/images/prod/282840_2.jpg",
                            Price = 13990,
                            Title = "Klipsch Heritage HP-3"
                        },
                        new
                        {
                            Id = 8,
                            Description = "Hifiman Ananda-BT är en trådlös öppen hörlur med stöd för högupplöst ljud och enastående ljudkvalitet i high-end klass.",
                            Image = "https://www.hembiobutiken.se/images/prod/318420-hifiman-ananda-bt-579_2.jpg",
                            Price = 13990,
                            Title = "Hifiman Ananda-BT"
                        },
                        new
                        {
                            Id = 9,
                            Description = "Audio Technica ATH-W5000 är det japanska bolagets referenshörlur och en utsökt kompanjon runt öronen. Njut av ett rikt och fylligt ljud från dessa slutna hi-end lurar med exklusiva och specialbyggda element inuti ebenholtsträ-kåpor som ger den extra luxuösa känslan!",
                            Image = "https://www.hembiobutiken.se/images/prod/210840_2.jpg",
                            Price = 13795,
                            Title = "Audio Technica ATH-W5000"
                        },
                        new
                        {
                            Id = 10,
                            Description = "Focal Elear är en High-End hörlur från Franska Focal och räknas som lillebror till referensmodellen Utopia. Elear bygger på samma filosofi och tänk som sin storebror men med mycket enklare materialval för att få ner kostnaden och ge dig som lyssnare ett steg in till High-End världens mitt till en betydligt lägre kostnad.",
                            Image = "https://www.hembiobutiken.se/images/prod/242810_2.jpg",
                            Price = 10990,
                            Title = "Focal hörlurar Elear"
                        });
                });

            modelBuilder.Entity("Order", b =>
                {
                    b.HasOne("Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("OrderRow", b =>
                {
                    b.HasOne("Order", "Order")
                        .WithMany("OrderRows")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Product", "Product")
                        .WithMany("OrderRows")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Customer", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Order", b =>
                {
                    b.Navigation("OrderRows");
                });

            modelBuilder.Entity("Product", b =>
                {
                    b.Navigation("OrderRows");
                });
#pragma warning restore 612, 618
        }
    }
}
