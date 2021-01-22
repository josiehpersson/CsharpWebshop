using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace dotnetwebshop.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Address = table.Column<string>(type: "TEXT", nullable: true),
                    ZipCode = table.Column<int>(type: "INTEGER", nullable: false),
                    City = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Image = table.Column<string>(type: "TEXT", nullable: true),
                    Price = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TotalPrice = table.Column<int>(type: "INTEGER", nullable: false),
                    CustomerId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderRows",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderRows", x => new { x.OrderId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_OrderRows_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderRows_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "City", "Name", "ZipCode" },
                values: new object[] { 1, "Fridensborgsvägen 161", "Solna", "Philip Sidlo", 17062 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "City", "Name", "ZipCode" },
                values: new object[] { 2, "Betongvägen 9", "Bålsta", "Arja Halkola", 74633 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "City", "Name", "ZipCode" },
                values: new object[] { 3, "Brushanevägen 26", "Bro", "Jessica Persson", 12345 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "City", "Name", "ZipCode" },
                values: new object[] { 4, "Gamlaekenvägen 89", "Örsundsbro", "Izabelle Persson", 17062 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "City", "Name", "ZipCode" },
                values: new object[] { 5, "Stenvägen 20", "Smedjebacken", "Anni Halkola", 77733 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "City", "Name", "ZipCode" },
                values: new object[] { 6, "Lustikullsvägen 20", "Ludvika", "Rauno Halkola", 77712 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Image", "Price", "Title" },
                values: new object[] { 1, "Focal Utopia är en referenshörlur från Franska Focal med deras välkända Beryllium-element! Utopia hörluren ingår i deras storsatsning av High-End hörlurar där Utopia är toppmodellen och ett statement från företaget. Konstruktionen påminner mer om en högtalare där ett 40mm Beryllium-element tar hand om hela registret.", "https://www.hembiobutiken.se/images/prod/242660_2.jpg", 44990, "Focal hörlurar Utopia" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Image", "Price", "Title" },
                values: new object[] { 2, "Hifiman Susvara är bolagets toppmodell och tar vara på Hifimans spetskompetens när det gäller att utveckla en high-end lur för inbitna musikälskare. Styrkan ligger i deras planarelement som tar fram en extremt stor och naturlig ljudbild med låg distorsion och bästa möjliga ljudupplevelse. Susvara använder sig av ett ”Stealth” magnetsystem som är en av deras senaste innovationer tillsammans med deras nanometer-membran som är ett av världens tunnaste material. Det här är en otroligt välbyggd hörlur som andas lyx och välljud och bara måste upplevas!", "https://www.hembiobutiken.se/images/prod/293280_2.jpg", 65990, "Hifiman Susvara" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Image", "Price", "Title" },
                values: new object[] { 3, "Stellia är en sluten referenshörlur från Focal, den franska anrika Hi-Fi-tillverkaren som dominerat hörlursmarknaden för bättre hörlurar de senaste åren. De flesta detaljerna är hämtade från Utopia-modellen men med den stora skillnaden att detta är en sluten modell. Läcker design och ett fantastiskt ljud gör att vi varmt kan rekommendera denna exklusiva hörlur.", "https://www.hembiobutiken.se/images/prod/290260_2.jpg", 33990, "Focal hörlurar Stellia" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Image", "Price", "Title" },
                values: new object[] { 4, "Kennerton Odin är ett par referenshörlurar med planar-magnetic konstruktion, egenbyggda element tillverkade i Ryssland. Odin spelar med en imponerade dynamik och transparens och målar upp klangbilden åt det varmare hållet utan förlorad finess eller detalj.", "https://www.hembiobutiken.se/images/prod/273110_2.jpg", 25990, "Kennerton Odin" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Image", "Price", "Title" },
                values: new object[] { 5, "Hifiman Arya är en enastående hifi-hörlur för de som längtar efter riktigt välljud. Inspirationen till Arya ligger i den tidigare HE-1000 V2, enligt många en av de bästa hörlurarna de hört, och använder planarmagnetiska element med nanometer-membran. Världens tunnaste element som tar fram detaljer på ett mycket imponerande sätt samtidigt som ljudet bli otroligt transparent och helt neutralt.", "https://www.hembiobutiken.se/images/prod/293190_2.jpg", 18990, "Hifiman Arya" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Image", "Price", "Title" },
                values: new object[] { 6, "Focal Clear är en helt ny mellanmodell av Focals premiumlurar. Clear befinner sig prismässigt under referensmodellen Utopia men bygger på samma filosofi, med enklare materialval. Focal Clear är handbyggd i Frankrike.", "https://www.hembiobutiken.se/images/prod/267210_2.jpg", 17990, "Focal hörlurar Clear" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Image", "Price", "Title" },
                values: new object[] { 7, "Klipsch Heritage HP-3 är en halvöppen stereolur i Klipsch hyllade Heritage-serie. Kraftulla 52 mm-element med premium byggkvalitet och en häftig design med kåpor i solid trä, huvudband i koläder och precisionstillverkade aluminiumkomponenter. En fantastisk hörlur som tar vara på Klipsch dynamiska spelstil.", "https://www.hembiobutiken.se/images/prod/282840_2.jpg", 13990, "Klipsch Heritage HP-3" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Image", "Price", "Title" },
                values: new object[] { 8, "Hifiman Ananda-BT är en trådlös öppen hörlur med stöd för högupplöst ljud och enastående ljudkvalitet i high-end klass.", "https://www.hembiobutiken.se/images/prod/318420-hifiman-ananda-bt-579_2.jpg", 13990, "Hifiman Ananda-BT" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Image", "Price", "Title" },
                values: new object[] { 9, "Audio Technica ATH-W5000 är det japanska bolagets referenshörlur och en utsökt kompanjon runt öronen. Njut av ett rikt och fylligt ljud från dessa slutna hi-end lurar med exklusiva och specialbyggda element inuti ebenholtsträ-kåpor som ger den extra luxuösa känslan!", "https://www.hembiobutiken.se/images/prod/210840_2.jpg", 13795, "Audio Technica ATH-W5000" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Image", "Price", "Title" },
                values: new object[] { 10, "Focal Elear är en High-End hörlur från Franska Focal och räknas som lillebror till referensmodellen Utopia. Elear bygger på samma filosofi och tänk som sin storebror men med mycket enklare materialval för att få ner kostnaden och ge dig som lyssnare ett steg in till High-End världens mitt till en betydligt lägre kostnad.", "https://www.hembiobutiken.se/images/prod/242810_2.jpg", 10990, "Focal hörlurar Elear" });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "Created", "CustomerId", "TotalPrice" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 320 });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "Created", "CustomerId", "TotalPrice" },
                values: new object[] { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 5320 });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "Created", "CustomerId", "TotalPrice" },
                values: new object[] { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 65000 });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "Created", "CustomerId", "TotalPrice" },
                values: new object[] { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 47500 });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "Created", "CustomerId", "TotalPrice" },
                values: new object[] { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 10300 });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "Created", "CustomerId", "TotalPrice" },
                values: new object[] { 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 6500 });

            migrationBuilder.InsertData(
                table: "OrderRows",
                columns: new[] { "OrderId", "ProductId" },
                values: new object[] { 1, 2 });

            migrationBuilder.InsertData(
                table: "OrderRows",
                columns: new[] { "OrderId", "ProductId" },
                values: new object[] { 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_OrderRows_ProductId",
                table: "OrderRows",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderRows");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
