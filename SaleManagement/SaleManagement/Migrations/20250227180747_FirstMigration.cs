using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SaleManagement.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Firstname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Lastname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomerDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: true),
                    Job = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerDetails_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    BrandId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Monster" },
                    { 2, "Apple" },
                    { 3, "Sony" },
                    { 4, "Samsung" },
                    { 5, "Logitech" },
                    { 6, "Asus" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Firstname", "Lastname" },
                values: new object[,]
                {
                    { 1, "Ömer", "Tomakin" },
                    { 2, "Ahmet", "Yılmaz" },
                    { 3, "Mehmet", "Kaya" },
                    { 4, "Ayşe", "Demir" },
                    { 5, "Fatma", "Çelik" },
                    { 6, "Ali", "Şahin" },
                    { 7, "Zeynep", "Koç" },
                    { 8, "Hasan", "Öztürk" },
                    { 9, "Elif", "Arslan" },
                    { 10, "Burak", "Güneş" },
                    { 11, "Merve", "Aydın" },
                    { 12, "Emre", "Taş" },
                    { 13, "Hüseyin", "Erdem" },
                    { 14, "Büşra", "Yıldırım" },
                    { 15, "Cem", "Karaca" }
                });

            migrationBuilder.InsertData(
                table: "CustomerDetails",
                columns: new[] { "Id", "Address", "Age", "CustomerId", "Job" },
                values: new object[,]
                {
                    { 1, "Çekmeköy/İstanbul", 20, 1, "JR. Backend Developer" },
                    { 2, "Kadıköy/İstanbul", 25, 2, "Frontend Developer" },
                    { 3, "Beşiktaş/İstanbul", 30, 3, "Full Stack Developer" },
                    { 4, "Bakırköy/İstanbul", 27, 4, "UI/UX Designer" },
                    { 5, "Bornova/İzmir", 35, 5, "Data Scientist" },
                    { 6, "Keçiören/Ankara", 22, 6, "Software Engineer" },
                    { 7, "Konak/İzmir", 28, 7, "DevOps Engineer" },
                    { 8, "Esenyurt/İstanbul", 33, 8, "Cloud Engineer" },
                    { 9, "Nilüfer/Bursa", 24, 9, "Mobile Developer" },
                    { 10, "Meram/Konya", 26, 10, "Game Developer" },
                    { 11, "Seyhan/Adana", 29, 11, "Cyber Security Expert" },
                    { 12, "Şişli/İstanbul", 31, 12, "AI Engineer" },
                    { 13, "Tepebaşı/Eskişehir", 23, 13, "Embedded Systems Engineer" },
                    { 14, "Ortahisar/Trabzon", 27, 14, "Database Administrator" },
                    { 15, "Odunpazarı/Eskişehir", 34, 15, "Business Analyst" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "CustomerId", "Description", "Name", "Price", "Stock" },
                values: new object[,]
                {
                    { 1, 1, 1, "Taşınabilir bilgisayar", "Dizüstü Bilgisayar", 100, 1 },
                    { 2, 2, 2, "Son model akıllı telefon", "Akıllı Telefon", 200, 5 },
                    { 3, 3, 3, "Bluetooth destekli kulaklık", "Kablosuz Kulaklık", 50, 10 },
                    { 4, 4, 4, "Sağlık takibi yapabilen saat", "Akıllı Saat", 120, 3 },
                    { 5, 5, 5, "RGB ışıklı mekanik klavye", "Mekanik Klavye", 80, 7 },
                    { 6, 5, 6, "Hassasiyet ayarlı oyun mouse", "Oyun Mouse", 40, 4 },
                    { 7, 4, 7, "144Hz oyuncu monitörü", "Monitör", 300, 2 },
                    { 8, 2, 8, "Çok amaçlı tablet", "Tablet", 180, 6 },
                    { 9, 3, 9, "1TB taşınabilir disk", "Harici Disk", 90, 8 },
                    { 10, 3, 10, "Kablosuz taşınabilir hoparlör", "Hoparlör", 70, 5 },
                    { 11, 6, 11, "64GB USB bellek", "USB Bellek", 20, 15 },
                    { 12, 6, 12, "Oyun için güçlü bilgisayar", "Masaüstü Bilgisayar", 500, 1 },
                    { 13, 6, 13, "Yüksek hızlı WiFi yönlendirici", "Router", 60, 9 },
                    { 14, 5, 14, "Full HD web kamera", "Web Kamera", 45, 3 },
                    { 15, 3, 15, "Sanal gerçeklik gözlüğü", "VR Gözlük", 250, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerDetails_CustomerId",
                table: "CustomerDetails",
                column: "CustomerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_BrandId",
                table: "Products",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CustomerId",
                table: "Products",
                column: "CustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerDetails");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
