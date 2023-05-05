using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ContaPlusAPI.Migrations
{
    /// <inheritdoc />
    public partial class ChartOfAccountsModelAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "ChartOfAccounts");

            migrationBuilder.DropColumn(
                name: "isCredit",
                table: "ChartOfAccounts");

            migrationBuilder.DropColumn(
                name: "isDebit",
                table: "ChartOfAccounts");

            migrationBuilder.InsertData(
                table: "ChartOfAccounts",
                columns: new[] { "AccountCode", "AccountDescription", "AccountName", "AccountNumber", "AccountType", "Product_Service" },
                values: new object[,]
                {
                    { 105, "Rezerve din reevaluare", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "P", "" },
                    { 107, "Diferenţe de curs valutar din conversie", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "B", "" },
                    { 121, "Profit sau pierdere", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "B", "" },
                    { 129, "Repartizarea profitului", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "A", "" },
                    { 167, "Alte împrumuturi şi datorii asimilate", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "P", "Serviciu" },
                    { 201, "Cheltuieli de constituire", "Conturi de imobilizari", 2, "A", "Serviciu" },
                    { 203, "Cheltuieli de dezvoltare", "Conturi de imobilizari", 2, "A", "Serviciu" },
                    { 205, "Concesiuni,Brevete, licenţe, mărci comerciale, drepturi şi active similare", "Conturi de imobilizari", 2, "A", "Bun" },
                    { 206, "Active necorporale de explorare şi evaluare a resurselor minerale", "Conturi de imobilizari", 2, "A", "Bun" },
                    { 208, "Alte imobilizări necorporale", "Conturi de imobilizari", 2, "A", "" },
                    { 211, "Terenuri şi amenajări de terenuri", "Conturi de imobilizari", 2, "A", "" },
                    { 212, "Construcţii", "Conturi de imobilizari", 2, "A", "Bun" },
                    { 214, "Mobilier, aparaturăBirotică, echipamente de protecţie a valorilor umane şi materiale şi alte active corporale", "Conturi de imobilizari", 2, "A", "Bun" },
                    { 215, "Investiţii imobiliare", "Conturi de imobilizari", 2, "A", "Bun" },
                    { 216, "Active corporale de explorare şi evaluare a resurselor minerale", "Conturi de imobilizari", 2, "A", "Bun" },
                    { 217, "ActiveBiologice productive", "Conturi de imobilizari", 2, "A", "Bun" },
                    { 223, "Instalaţii tehnice şi mijloace de transport în curs de aprovizionare", "Conturi de imobilizari", 2, "A", "Bun" },
                    { 224, "Mobilier, aparaturăBirotică, echipamente de protecţie a valorilor umane şi materiale şi alte active corporale în curs de aprovizionare", "Conturi de imobilizari", 2, "A", "Bun" },
                    { 227, "ActiveBiologice productive în curs de aprovizionare", "Conturi de imobilizari", 2, "A", "Bun" },
                    { 231, "Imobilizări corporale în curs de execuţie", "Conturi de imobilizari", 2, "A", "" },
                    { 235, "Investiţii imobiliare în curs de execuţie", "Conturi de imobilizari", 2, "A", "" },
                    { 261, "Acţiuni deţinute la entităţile afiliate", "Conturi de imobilizari", 2, "A", "" },
                    { 262, "Acţiuni deţinute la entităţi asociate", "Conturi de imobilizari", 2, "A", "" },
                    { 263, "Acţiuni deţinute la entităţi controlate în comun", "Conturi de imobilizari", 2, "A", "" },
                    { 264, "Titluri puse în echivalenţă", "Conturi de imobilizari", 2, "A", "" },
                    { 265, "Alte titluri imobilizate", "Conturi de imobilizari", 2, "A", "" },
                    { 266, "Certificate verzi amânate", "Conturi de imobilizari", 2, "A", "" },
                    { 301, "Materii prime", "Conturi de stocuri si productie in curs de executie", 3, "A", "Bun" },
                    { 303, "Materiale de natura obiectelor de inventar", "Conturi de stocuri si productie in curs de executie", 3, "A", "Bun" },
                    { 308, "Diferenţe de preţ la materii prime şi materiale", "Conturi de stocuri si productie in curs de executie", 3, "B", "Bun" },
                    { 321, "Materii prime în curs de aprovizionare", "Conturi de stocuri si productie in curs de executie", 3, "A", "Bun" },
                    { 322, "Materiale consumabile în curs de aprovizionare", "Conturi de stocuri si productie in curs de executie", 3, "A", "Bun" },
                    { 323, "Materiale de natura obiectelor de inventar în curs de aprovizionare", "Conturi de stocuri si productie in curs de executie", 3, "A", "Bun" },
                    { 326, "ActiveBiologice de natura stocurilor în curs de aprovizionare", "Conturi de stocuri si productie in curs de executie", 3, "A", "Bun" },
                    { 327, "Mărfuri în curs de aprovizionare", "Conturi de stocuri si productie in curs de executie", 3, "A", "Bun" },
                    { 328, "Ambalaje în curs de aprovizionare", "Conturi de stocuri si productie in curs de executie", 3, "A", "Bun" },
                    { 331, "Produse în curs de execuţie", "Conturi de stocuri si productie in curs de executie", 3, "A", "" },
                    { 332, "Servicii în curs de execuţie", "Conturi de stocuri si productie in curs de executie", 3, "A", "" },
                    { 341, "Semifabricate", "Conturi de stocuri si productie in curs de executie", 3, "A", "Bun" },
                    { 345, "Produse finite", "Conturi de stocuri si productie in curs de executie", 3, "A", "Bun" },
                    { 346, "Produse reziduale", "Conturi de stocuri si productie in curs de executie", 3, "A", "Bun" },
                    { 347, "Produse agricole", "Conturi de stocuri si productie in curs de executie", 3, "A", "Bun" },
                    { 348, "Diferenţe de preţ la produse", "Conturi de stocuri si productie in curs de executie", 3, "B", "" },
                    { 351, "Materii şi materiale aflate la terţi", "Conturi de stocuri si productie in curs de executie", 3, "A", "" },
                    { 354, "Produse aflate la terţi", "Conturi de stocuri si productie in curs de executie", 3, "A", "" },
                    { 356, "ActiveBiologice de natura stocurilor aflate la terţi", "Conturi de stocuri si productie in curs de executie", 3, "A", "" },
                    { 357, "Mărfuri aflate la terţi", "Conturi de stocuri si productie in curs de executie", 3, "A", "" },
                    { 358, "Ambalaje aflate la terţi", "Conturi de stocuri si productie in curs de executie", 3, "A", "" },
                    { 361, "ActiveBiologice de natura stocurilor", "Conturi de stocuri si productie in curs de executie", 3, "A", "Bun" },
                    { 368, "Diferenţe de preţ la activeBiologice de natura stocurilor", "Conturi de stocuri si productie in curs de executie", 3, "B", "" },
                    { 371, "Mărfuri", "Conturi de stocuri si productie in curs de executie", 3, "A", "Bun" },
                    { 378, "Diferenţe de preţ la mărfuri", "Conturi de stocuri si productie in curs de executie", 3, "B", "" },
                    { 381, "Ambalaje", "Conturi de stocuri si productie in curs de executie", 3, "A", "Bun" },
                    { 388, "Diferenţe de preţ la ambalaje", "Conturi de stocuri si productie in curs de executie", 3, "B", "" },
                    { 391, "Ajustări pentru deprecierea materiilor prime", "Conturi de stocuri si productie in curs de executie", 3, "P", "" },
                    { 393, "Ajustări pentru deprecierea producţiei în curs de execuţie", "Conturi de stocuri si productie in curs de executie", 3, "P", "" },
                    { 396, "Ajustări pentru deprecierea activelorBiologice de natura stocurilor", "Conturi de stocuri si productie in curs de executie", 3, "P", "" },
                    { 397, "Ajustări pentru deprecierea mărfurilor", "Conturi de stocuri si productie in curs de executie", 3, "P", "" },
                    { 398, "Ajustări pentru deprecierea ambalajelor", "Conturi de stocuri si productie in curs de executie", 3, "P", "" },
                    { 401, "Furnizori", "Conturi de terti", 4, "P", "" },
                    { 403, "Efecte de plătit", "Conturi de terti", 4, "P", "" },
                    { 404, "Furnizori de imobilizări", "Conturi de terti", 4, "P", "" },
                    { 405, "Efecte de plătit pentru imobilizări", "Conturi de terti", 4, "P", "" },
                    { 408, "Furnizori - facturi nesosite", "Conturi de terti", 4, "P", "Bun" },
                    { 413, "Efecte de primit de la clienţi", "Conturi de terti", 4, "A", "" },
                    { 418, "Clienţi - facturi de întocmit", "Conturi de terti", 4, "A", "Bun" },
                    { 419, "Clienţi - creditori", "Conturi de terti", 4, "P", "Bun" },
                    { 421, "Personal - salarii datorate", "Conturi de terti", 4, "P", "" },
                    { 423, "Personal - ajutoare materiale datorate", "Conturi de terti", 4, "P", "" },
                    { 424, "Prime reprezentând participarea personalului la profit", "Conturi de terti", 4, "P", "" },
                    { 425, "Avansuri acordate personalului", "Conturi de terti", 4, "A", "" },
                    { 426, "Drepturi de personal neridicate", "Conturi de terti", 4, "P", "" },
                    { 427, "Reţineri din salarii datorate terţilor", "Conturi de terti", 4, "P", "" },
                    { 431, "Asigurări sociale", "Conturi de terti", 4, "P", "" },
                    { 436, "Contribuţia asiguratorie pentru muncă", "Conturi de terti", 4, "P", "" },
                    { 444, "Impozitul pe venituri de natura salariilor", "Conturi de terti", 4, "P", "" },
                    { 446, "Alte impozite, taxe şi vărsăminte asimilate", "Conturi de terti", 4, "P", "" },
                    { 447, "Fonduri speciale - taxe şi vărsăminte asimilate", "Conturi de terti", 4, "P", "" },
                    { 456, "Decontări cu acţionarii/asociaţii privind capitalul", "Conturi de terti", 4, "B", "" },
                    { 457, "Dividende de plată", "Conturi de terti", 4, "P", "" },
                    { 461, "Debitori diverşi", "Conturi de terti", 4, "A", "" },
                    { 462, "Creditori diverşi", "Conturi de terti", 4, "P", "" },
                    { 463, "Creanţe reprezentând dividende repartizate în cursul exerciţiului financiar", "Conturi de terti", 4, "A", "" },
                    { 467, "Datorii aferente distribuirilor interimare de dividende", "Conturi de terti", 4, "P", "" },
                    { 471, "Cheltuieli înregistrate în avans", "Conturi de terti", 4, "A", "Serviciu" },
                    { 472, "Venituri înregistrate în avans", "Conturi de terti", 4, "P", "Serviciu" },
                    { 473, "Decontări din operaţiuni în curs de clarificare", "Conturi de terti", 4, "B", "" },
                    { 475, "Subvenţii pentru investiţii", "Conturi de terti", 4, "P", "" },
                    { 478, "Venituri în avans aferente activelor primite prin transfer de la clienţi", "Conturi de terti", 4, "P", "" },
                    { 481, "Decontări între unitate şi subunităţi", "Conturi de terti", 4, "B", "" },
                    { 482, "Decontări între subunităţi", "Conturi de terti", 4, "B", "" },
                    { 491, "Ajustări pentru deprecierea creanţelor - clienţi", "Conturi de terti", 4, "P", "" },
                    { 495, "Ajustări pentru deprecierea creanţelor - decontări în cadrul grupului şi cu acţionarii/asociaţii", "Conturi de terti", 4, "P", "" },
                    { 496, "Ajustări pentru deprecierea creanţelor - debitori diverşi", "Conturi de terti", 4, "P", "" },
                    { 501, "Acţiuni deţinute la entităţile afiliate", "Conturi de trezorerie", 5, "A", "" },
                    { 505, "Obligaţiuni emise şi răscumpărate", "Conturi de trezorerie", 5, "A", "" },
                    { 506, "Obligaţiuni", "Conturi de trezorerie", 5, "A", "" },
                    { 507, "Certificate verzi primite", "Conturi de trezorerie", 5, "A", "" },
                    { 542, "Avansuri de trezorerie", "Conturi de trezorerie", 5, "A", "" },
                    { 581, "Viramente interne", "Conturi de trezorerie", 5, "B", "" },
                    { 591, "Ajustări pentru pierderea de valoare a acţiunilor deţinute la entităţile afiliate", "Conturi de trezorerie", 5, "P", "" },
                    { 595, "Ajustări pentru pierderea de valoare a obligaţiunilor emise şi răscumpărate", "Conturi de trezorerie", 5, "P", "" },
                    { 596, "Ajustări pentru pierderea de valoare a obligaţiunilor", "Conturi de trezorerie", 5, "P", "" },
                    { 598, "Ajustări pentru pierderea de valoare a altor investiţii pe termen scurt şi creanţe asimilate", "Conturi de trezorerie", 5, "P", "" },
                    { 601, "Cheltuieli cu materiile prime", "Conturi de cheltuieli", 6, "A", "Bun" },
                    { 602, "Cheltuieli cu materialele consumabile", "Conturi de cheltuieli", 6, "A", "Bun" },
                    { 603, "Cheltuieli privind materialele de natura obiectelor de inventar", "Conturi de cheltuieli", 6, "A", "Bun" },
                    { 604, "Cheltuieli privind materialele nestocate", "Conturi de cheltuieli", 6, "A", "Bun" },
                    { 605, "Cheltuieli privind utilitățile", "Conturi de cheltuieli", 6, "A", "Bun" },
                    { 606, "Cheltuieli privind activeleBiologice de natura stocurilor", "Conturi de cheltuieli", 6, "A", "Bun" },
                    { 607, "Cheltuieli privind mărfurile", "Conturi de cheltuieli", 6, "A", "Bun" },
                    { 608, "Cheltuieli privind ambalajele", "Conturi de cheltuieli", 6, "A", "Bun" },
                    { 609, "Reduceri comerciale primite", "Conturi de cheltuieli", 6, "P", "Bun" },
                    { 611, "Cheltuieli cu întreţinerea şi reparaţiile", "Conturi de cheltuieli", 6, "A", "Serviciu" },
                    { 612, "Cheltuieli cu redevenţele, locaţiile de gestiune şi chiriile", "Conturi de cheltuieli", 6, "A", "Serviciu" },
                    { 613, "Cheltuieli cu primele de asigurare", "Conturi de cheltuieli", 6, "A", "Serviciu" },
                    { 614, "Cheltuieli cu studiile şi cercetările", "Conturi de cheltuieli", 6, "A", "Serviciu" },
                    { 615, "Cheltuieli cu pregătirea personalului", "Conturi de cheltuieli", 6, "A", "Serviciu" },
                    { 621, "Cheltuieli cu colaboratorii", "Conturi de cheltuieli", 6, "A", "Serviciu" },
                    { 622, "Cheltuieli privind comisioanele şi onorariile", "Conturi de cheltuieli", 6, "A", "Serviciu" },
                    { 623, "Cheltuieli de protocol, reclamă şi publicitate", "Conturi de cheltuieli", 6, "A", "Serviciu" },
                    { 624, "Cheltuieli cu transportul deBunuri şi personal", "Conturi de cheltuieli", 6, "A", "Serviciu" },
                    { 625, "Cheltuieli cu deplasări, detaşări şi transferări", "Conturi de cheltuieli", 6, "A", "Serviciu" },
                    { 626, "Cheltuieli poştale şi taxe de telecomunicaţii", "Conturi de cheltuieli", 6, "A", "Serviciu" },
                    { 627, "Cheltuieli cu serviciileBancare şi asimilate", "Conturi de cheltuieli", 6, "A", "Serviciu" },
                    { 628, "Alte cheltuieli cu serviciile executate de terţi", "Conturi de cheltuieli", 6, "A", "Serviciu" },
                    { 635, "Cheltuieli cu alte impozite, taxe şi vărsăminte asimilate", "Conturi de cheltuieli", 6, "A", "Serviciu" },
                    { 641, "Cheltuieli cu salariile personalului", "Conturi de cheltuieli", 6, "A", "" },
                    { 642, "Cheltuieli cu avantajele în natură şi tichetele acordate salariaţilor", "Conturi de cheltuieli", 6, "A", "" },
                    { 643, "Cheltuieli cu remunerarea în instrumente de capitaluri proprii", "Conturi de cheltuieli", 6, "A", "" },
                    { 644, "Cheltuieli cu primele reprezentând participarea personalului la profit", "Conturi de cheltuieli", 6, "A", "" },
                    { 645, "Cheltuieli privind asigurările şi protecţia socială", "Conturi de cheltuieli", 6, "A", "" },
                    { 646, "Cheltuieli privind contribuţia asiguratorie pentru muncă", "Conturi de cheltuieli", 6, "A", "" },
                    { 652, "Cheltuieli cu protecţia mediului înconjurător", "Conturi de cheltuieli", 6, "A", "" },
                    { 654, "Pierderi din creanţe şi debitori diverşi", "Conturi de cheltuieli", 6, "A", "" },
                    { 655, "Cheltuieli din reevaluarea imobilizărilor corporale", "Conturi de cheltuieli", 6, "A", "" },
                    { 658, "Alte cheltuieli de exploatare", "Conturi de cheltuieli", 6, "A", "" },
                    { 663, "Pierderi din creanţe legate de participaţii", "Conturi de cheltuieli", 6, "A", "" },
                    { 664, "Cheltuieli privind investiţiile financiare cedate", "Conturi de cheltuieli", 6, "A", "" },
                    { 665, "Cheltuieli din diferenţe de curs valutar", "Conturi de cheltuieli", 6, "A", "" },
                    { 666, "Cheltuieli privind dobânzile", "Conturi de cheltuieli", 6, "A", "" },
                    { 667, "Cheltuieli privind sconturile acordate", "Conturi de cheltuieli", 6, "A", "" },
                    { 668, "Alte cheltuieli financiare", "Conturi de cheltuieli", 6, "A", "" },
                    { 681, "Cheltuieli de exploatare privind amortizările, provizioanele şi ajustările pentru depreciere", "Conturi de cheltuieli", 6, "A", "" },
                    { 686, "Cheltuieli financiare privind amortizările, provizioanele şi ajustările pentru pierdere de valoare", "Conturi de cheltuieli", 6, "A", "" },
                    { 691, "Cheltuieli cu impozitul pe profit", "Conturi de cheltuieli", 6, "A", "" },
                    { 693, "Cheltuieli cu impozitul pe profit, determinate de incertitudinile legate de tratamentele fiscale", "Conturi de cheltuieli", 6, "A", "" },
                    { 694, "Cheltuieli cu impozitul pe profit rezultat din decontările în cadrul grupului fiscal în domeniul impozitului pe profit", "Conturi de cheltuieli", 6, "A", "" },
                    { 695, "Cheltuieli cu impozitul specific unor activităţi", "Conturi de cheltuieli", 6, "A", "" },
                    { 698, "Cheltuieli cu impozitul pe venit şi cu alte impozite care nu apar în elementele de mai sus", "Conturi de cheltuieli", 6, "A", "" },
                    { 701, "Venituri din vânzarea produselor finite, produselor agricole şi a activelorBiologice de natura stocurilor", "Conturi de venituri", 7, "P", "Bun" },
                    { 702, "Venituri din vânzarea semifabricatelor", "Conturi de venituri", 7, "P", "Bun" },
                    { 703, "Venituri din vânzarea produselor reziduale", "Conturi de venituri", 7, "P", "Bun" },
                    { 704, "Venituri din servicii prestate", "Conturi de venituri", 7, "P", "Serviciu" },
                    { 705, "Venituri din studii şi cercetări", "Conturi de venituri", 7, "P", "Serviciu" },
                    { 706, "Venituri din redevenţe, locaţii de gestiune şi chirii", "Conturi de venituri", 7, "P", "Serviciu" },
                    { 707, "Venituri din vânzarea mărfurilor", "Conturi de venituri", 7, "P", "Bun" },
                    { 708, "Venituri din activităţi diverse", "Conturi de venituri", 7, "P", "Bun" },
                    { 709, "Reduceri comerciale acordate", "Conturi de venituri", 7, "A", "Serviciu" },
                    { 711, "Venituri aferente costurilor stocurilor de produse", "Conturi de venituri", 7, "B", "" },
                    { 712, "Venituri aferente costurilor serviciilor în curs de execuţie", "Conturi de venituri", 7, "P", "" },
                    { 721, "Venituri din producţia de imobilizări necorporale", "Conturi de venituri", 7, "P", "" },
                    { 722, "Venituri din producţia de imobilizări corporale", "Conturi de venituri", 7, "P", "" },
                    { 725, "Venituri din producţia de investiţii imobiliare", "Conturi de venituri", 7, "P", "" },
                    { 741, "Venituri din subvenţii de exploatare", "Conturi de venituri", 7, "P", "" },
                    { 754, "Venituri din creanţe reactivate şi debitori diverşi", "Conturi de venituri", 7, "P", "" },
                    { 755, "Venituri din reevaluarea imobilizărilor corporale", "Conturi de venituri", 7, "P", "" },
                    { 758, "Alte venituri din exploatare", "Conturi de venituri", 7, "P", "" },
                    { 761, "Venituri din imobilizări financiare", "Conturi de venituri", 7, "P", "" },
                    { 762, "Venituri din investiţii financiare pe termen scurt", "Conturi de venituri", 7, "P", "" },
                    { 764, "Venituri din investiţii financiare cedate", "Conturi de venituri", 7, "P", "" },
                    { 765, "Venituri din diferenţe de curs valutar", "Conturi de venituri", 7, "P", "" },
                    { 766, "Venituri din dobânzi", "Conturi de venituri", 7, "P", "" },
                    { 767, "Venituri din sconturi obţinute", "Conturi de venituri", 7, "P", "" },
                    { 768, "Alte venituri financiare", "Conturi de venituri", 7, "P", "" },
                    { 781, "Venituri din provizioane şi ajustări pentru depreciere privind activitatea de exploatare", "Conturi de venituri", 7, "P", "" },
                    { 786, "Venituri financiare din amortizări şi ajustări pentru pierdere de valoare", "Conturi de venituri", 7, "P", "" },
                    { 792, "Venituri din impozitul pe profit amânat", "Conturi de venituri", 7, "P", "" },
                    { 794, "Venituri din impozitul pe profit rezultat din decontările în cadrul grupului fiscal în domeniul impozitului pe profit", "Conturi de venituri", 7, "P", "" },
                    { 801, "Angajamente acordate", "Conturi speciale", 8, "B", "" },
                    { 802, "Angajamente primite", "Conturi speciale", 8, "B", "" },
                    { 803, "Alte conturi în afaraBilanţului", "Conturi speciale", 8, "B", "" },
                    { 804, "Certificate verzi", "Conturi speciale", 8, "B", "" },
                    { 805, "Dobânzi aferente contractelor de leasing şi altor contracte asimilate, neajunse la scadenţă", "Conturi speciale", 8, "B", "" },
                    { 806, "Certificate de emisii de gaze cu efect de seră", "Conturi speciale", 8, "B", "" },
                    { 807, "Active contingente", "Conturi speciale", 8, "B", "" },
                    { 808, "Datorii contingente", "Conturi speciale", 8, "B", "" },
                    { 809, "Creanţe preluate prin cesionare", "Conturi speciale", 8, "B", "" },
                    { 891, "Bilanţ de deschidere", "Conturi speciale", 8, "B", "" },
                    { 892, "Bilanţ de închidere", "Conturi speciale", 8, "B", "" },
                    { 899, "Contrapartida", "Conturi speciale", 8, "B", "" },
                    { 1011, "Capital subscris nevărsat", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "P", "" },
                    { 1012, "Capital subscris vărsat", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "P", "" },
                    { 1015, "Patrimoniul regiei", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "P", "" },
                    { 1016, "Patrimoniul public", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "P", "" },
                    { 1017, "Patrimoniul privat", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "P", "" },
                    { 1018, "Patrimoniul institutelor naţionale de cercetare-dezvoltare", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "P", "" },
                    { 1031, "Beneficii acordate angajaţilor sub forma instrumentelor de capitaluri proprii", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "P", "" },
                    { 1033, "Diferenţe de curs valutar în relaţie cu investiţia netă într-o entitate străină", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "B", "" },
                    { 1038, "Diferenţe din modificarea valorii juste a activelor financiare disponibile în vederea vânzării şi alte elemente de capitaluri proprii", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "B", "" },
                    { 1041, "Prime de emisiune", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "P", "" },
                    { 1042, "Prime de fuziune/divizare", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "P", "" },
                    { 1043, "Prime de aport", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "P", "" },
                    { 1044, "Prime de conversie a obligaţiunilor în acţiuni", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "P", "" },
                    { 1061, "Rezerve legale", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "P", "" },
                    { 1063, "Rezerve statutare sau contractuale", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "P", "" },
                    { 1068, "Alte rezerve", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "P", "" },
                    { 1081, "Interese care nu controlează - rezultatul exerciţiului financiar", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "B", "" },
                    { 1082, "Interese care nu controlează - alte capitaluri proprii", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "B", "" },
                    { 1091, "Acţiuni proprii deţinute pe termen scurt", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "A", "" },
                    { 1092, "Acţiuni proprii deţinute pe termen lung", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "A", "" },
                    { 1095, "Acţiuni proprii reprezentând titluri deţinute de societatea absorbită la societatea absorbantă", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "A", "" },
                    { 1171, "Rezultatul reportat reprezentând profitul nerepartizat sau pierderea neacoperită", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "B", "" },
                    { 1172, "Rezultatul reportat provenit din adoptarea pentru prima dată a IAS, mai puţin IAS 2911 ", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "B", "" },
                    { 1173, "Rezultatul reportat provenit din modificările politicilor contabile", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "B", "" },
                    { 1174, "Rezultatul reportat provenit din corectarea erorilor contabile", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "B", "" },
                    { 1175, "Rezultatul reportat reprezentând surplusul realizat din rezerve din reevaluare", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "P", "" },
                    { 1176, "Rezultatul reportat provenit din trecerea la aplicarea reglementărilor contabile conforme cu directivele europene", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "B", "" },
                    { 1411, "Câştiguri legate de vânzarea instrumentelor de capitaluri proprii", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "P", "" },
                    { 1412, "Câştiguri legate de anularea instrumentelor de capitaluri proprii", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "P", "" },
                    { 1491, "Pierderi rezultate din vânzarea instrumentelor de capitaluri proprii", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "A", "" },
                    { 1495, "Pierderi rezultate din reorganizări, care sunt determinate de anularea titlurilor deţinute", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "A", "" },
                    { 1498, "Alte pierderi legate de instrumentele de capitaluri proprii", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "A", "" },
                    { 1511, "Provizioane pentru litigii", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "P", "" },
                    { 1512, "Provizioane pentru garanţii acordate clienţilor", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "P", "" },
                    { 1513, "Provizioane pentru dezafectare imobilizări corporale şi alte acţiuni similare legate de acestea", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "P", "" },
                    { 1514, "Provizioane pentru restructurare", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "P", "" },
                    { 1515, "Provizioane pentru pensii şi obligaţii similare", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "P", "" },
                    { 1516, "Provizioane pentru impozite", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "P", "" },
                    { 1517, "Provizioane pentru terminarea contractului de muncă", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "P", "" },
                    { 1518, "Alte provizioane", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "P", "" },
                    { 1614, "Împrumuturi externe din emisiuni de obligaţiuni garantate de stat", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "P", "" },
                    { 1615, "Împrumuturi externe din emisiuni de obligaţiuni garantate deBănci", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "P", "" },
                    { 1617, "Împrumuturi interne din emisiuni de obligaţiuni garantate de stat", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "P", "" },
                    { 1618, "Alte împrumuturi din emisiuni de obligaţiuni", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "P", "" },
                    { 1621, "CrediteBancare pe termen lung", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "P", "" },
                    { 1622, "CrediteBancare pe termen lung nerambursate la scadenţă", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "P", "" },
                    { 1623, "Credite externe guvernamentale", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "P", "" },
                    { 1624, "CrediteBancare externe garantate de stat", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "P", "" },
                    { 1625, "CrediteBancare externe garantate deBănci", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "P", "" },
                    { 1626, "Credite de la trezoreria statului", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "P", "" },
                    { 1627, "CrediteBancare interne garantate de stat", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "P", "" },
                    { 1661, "Datorii faţă de entităţile afiliate", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "P", "" },
                    { 1663, "Datorii faţă de entităţile asociate şi entităţile controlate în comun", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "P", "" },
                    { 1681, "Dobânzi aferente împrumuturilor din emisiuni de obligaţiuni", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "P", "" },
                    { 1682, "Dobânzi aferente creditelorBancare pe termen lung", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "P", "" },
                    { 1685, "Dobânzi aferente datoriilor faţă de entităţile afiliate", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "P", "" },
                    { 1686, "Dobânzi aferente datoriilor faţă de entităţile asociate şi entităţile controlate în comun", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "P", "" },
                    { 1687, "Dobânzi aferente altor împrumuturi şi datorii asimilate", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "P", "" },
                    { 1691, "Prime privind rambursarea obligaţiunilor", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "A", "" },
                    { 1692, "Prime privind rambursarea altor datorii", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "A", "" },
                    { 2071, "Fond comercial pozitiv", "Conturi de imobilizari", 2, "A", "" },
                    { 2075, "Fond comercial negativ", "Conturi de imobilizari", 2, "P", "" },
                    { 2111, "Terenuri", "Conturi de imobilizari", 2, "A", "Bun" },
                    { 2112, "Amenajări de terenuri", "Conturi de imobilizari", 2, "A", "" },
                    { 2131, "Echipamente tehnologice, maşini, utilaje şi instalaţii de lucru", "Conturi de imobilizari", 2, "A", "Bun" },
                    { 2132, "Aparate şi instalaţii de măsurare, control şi reglare", "Conturi de imobilizari", 2, "A", "Bun" },
                    { 2133, "Mijloace de transport", "Conturi de imobilizari", 2, "A", "Bun" },
                    { 2671, "Sume de încasat de la entităţile afiliate", "Conturi de imobilizari", 2, "A", "" },
                    { 2672, "Dobânda aferentă sumelor de încasat de la entităţile afiliate", "Conturi de imobilizari", 2, "A", "" },
                    { 2673, "Creanţe faţă de entităţile asociate şi entităţile controlate în comun", "Conturi de imobilizari", 2, "A", "" },
                    { 2674, "Dobânda aferentă creanţelor faţă de entităţile asociate şi entităţile controlate în comun", "Conturi de imobilizari", 2, "A", "" },
                    { 2675, "Împrumuturi acordate pe termen lung", "Conturi de imobilizari", 2, "A", "" },
                    { 2676, "Dobânda aferentă împrumuturilor acordate pe termen lung", "Conturi de imobilizari", 2, "A", "" },
                    { 2677, "Obligaţiuni achiziţionate cu ocazia emisiunilor efectuate de terţi", "Conturi de imobilizari", 2, "A", "" },
                    { 2678, "Alte creanţe imobilizate", "Conturi de imobilizari", 2, "A", "" },
                    { 2679, "Dobânzi aferente altor creanţe imobilizate", "Conturi de imobilizari", 2, "A", "" },
                    { 2691, "Vărsăminte de efectuat privind acţiunile deţinute la entităţile afiliate", "Conturi de imobilizari", 2, "P", "" },
                    { 2692, "Vărsăminte de efectuat privind acţiunile deţinute la entităţi asociate", "Conturi de imobilizari", 2, "P", "" },
                    { 2693, "Vărsăminte de efectuat privind acţiunile deţinute la entităţi controlate în comun", "Conturi de imobilizari", 2, "P", "" },
                    { 2695, "Vărsăminte de efectuat pentru alte imobilizări financiare", "Conturi de imobilizari", 2, "P", "" },
                    { 2801, "Amortizarea cheltuielilor de constituire", "Conturi de imobilizari", 2, "P", "" },
                    { 2803, "Amortizarea cheltuielilor de dezvoltare", "Conturi de imobilizari", 2, "P", "" },
                    { 2805, "Amortizarea concesiunilor,Brevetelor, licenţelor, mărcilor comerciale, drepturilor şi activelor similare", "Conturi de imobilizari", 2, "P", "" },
                    { 2806, "Amortizarea activelor necorporale de explorare şi evaluare a resurselor minerale", "Conturi de imobilizari", 2, "P", "" },
                    { 2807, "Amortizarea fondului comercial", "Conturi de imobilizari", 2, "P", "" },
                    { 2808, "Amortizarea altor imobilizări necorporale", "Conturi de imobilizari", 2, "P", "" },
                    { 2811, "Amortizarea amenajărilor de terenuri", "Conturi de imobilizari", 2, "P", "" },
                    { 2812, "Amortizarea construcţiilor", "Conturi de imobilizari", 2, "P", "" },
                    { 2813, "Amortizarea instalaţiilor şi mijloacelor de transport", "Conturi de imobilizari", 2, "P", "" },
                    { 2814, "Amortizarea altor imobilizări corporale", "Conturi de imobilizari", 2, "P", "" },
                    { 2815, "Amortizarea investiţiilor imobiliare", "Conturi de imobilizari", 2, "P", "" },
                    { 2816, "Amortizarea activelor corporale de explorare şi evaluare a resurselor minerale", "Conturi de imobilizari", 2, "P", "" },
                    { 2817, "Amortizarea activelorBiologice productive", "Conturi de imobilizari", 2, "P", "" },
                    { 2903, "Ajustări pentru deprecierea cheltuielilor de dezvoltare", "Conturi de imobilizari", 2, "P", "" },
                    { 2905, "Ajustări pentru deprecierea concesiunilor,Brevetelor, licenţelor, mărcilor comerciale, drepturilor şi activelor similare", "Conturi de imobilizari", 2, "P", "" },
                    { 2906, "Ajustări pentru deprecierea activelor necorporale de explorare şi evaluare a resurselor minerale", "Conturi de imobilizari", 2, "P", "" },
                    { 2908, "Ajustări pentru deprecierea altor imobilizări necorporale", "Conturi de imobilizari", 2, "P", "" },
                    { 2911, "Ajustări pentru deprecierea terenurilor şi amenajărilor de terenuri", "Conturi de imobilizari", 2, "P", "" },
                    { 2912, "Ajustări pentru deprecierea construcţiilor", "Conturi de imobilizari", 2, "P", "" },
                    { 2913, "Ajustări pentru deprecierea instalaţiilor şi mijloacelor de transport", "Conturi de imobilizari", 2, "P", "" },
                    { 2914, "Ajustări pentru deprecierea altor imobilizări corporale", "Conturi de imobilizari", 2, "P", "" },
                    { 2915, "Ajustări pentru deprecierea investiţiilor imobiliare", "Conturi de imobilizari", 2, "P", "" },
                    { 2916, "Ajustări pentru deprecierea activelor corporale de explorare şi evaluare a resurselor minerale", "Conturi de imobilizari", 2, "P", "" },
                    { 2917, "Ajustări pentru deprecierea activelorBiologice productive", "Conturi de imobilizari", 2, "P", "" },
                    { 2931, "Ajustări pentru deprecierea imobilizărilor corporale în curs de execuţie", "Conturi de imobilizari", 2, "P", "" },
                    { 2935, "Ajustări pentru deprecierea investiţiilor imobiliare în curs de execuţie", "Conturi de imobilizari", 2, "P", "" },
                    { 2961, "Ajustări pentru pierderea de valoare a acţiunilor deţinute la entităţile afiliate", "Conturi de imobilizari", 2, "P", "" },
                    { 2962, "Ajustări pentru pierderea de valoare a acţiunilor deţinute la entităţi asociate şi entităţi controlate în comun", "Conturi de imobilizari", 2, "P", "" },
                    { 2963, "Ajustări pentru pierderea de valoare a altor titluri imobilizate", "Conturi de imobilizari", 2, "P", "" },
                    { 2964, "Ajustări pentru pierderea de valoare a sumelor de încasat de la entităţile afiliate", "Conturi de imobilizari", 2, "P", "" },
                    { 2965, "Ajustări pentru pierderea de valoare a creanţelor faţă de entităţile asociate şi entităţile controlate în comun", "Conturi de imobilizari", 2, "P", "" },
                    { 2966, "Ajustări pentru pierderea de valoare a împrumuturilor acordate pe termen lung", "Conturi de imobilizari", 2, "P", "" },
                    { 2968, "Ajustări pentru pierderea de valoare a altor creanţe imobilizate", "Conturi de imobilizari", 2, "P", "" },
                    { 3021, "Materiale auxiliare", "Conturi de stocuri si productie in curs de executie", 3, "A", "Bun" },
                    { 3022, "Combustibili", "Conturi de stocuri si productie in curs de executie", 3, "A", "Bun" },
                    { 3023, "Materiale pentru ambalat", "Conturi de stocuri si productie in curs de executie", 3, "A", "Bun" },
                    { 3024, "Piese de schimb", "Conturi de stocuri si productie in curs de executie", 3, "A", "Bun" },
                    { 3025, "Seminţe şi materiale de plantat", "Conturi de stocuri si productie in curs de executie", 3, "A", "Bun" },
                    { 3026, "Furaje", "Conturi de stocuri si productie in curs de executie", 3, "A", "Bun" },
                    { 3028, "Alte materiale consumabile", "Conturi de stocuri si productie in curs de executie", 3, "A", "Bun" },
                    { 3921, "Ajustări pentru deprecierea materialelor consumabile", "Conturi de stocuri si productie in curs de executie", 3, "P", "" },
                    { 3922, "Ajustări pentru deprecierea materialelor de natura obiectelor de inventar", "Conturi de stocuri si productie in curs de executie", 3, "P", "" },
                    { 3941, "Ajustări pentru deprecierea semifabricatelor", "Conturi de stocuri si productie in curs de executie", 3, "P", "" },
                    { 3945, "Ajustări pentru deprecierea produselor finite", "Conturi de stocuri si productie in curs de executie", 3, "P", "" },
                    { 3946, "Ajustări pentru deprecierea produselor reziduale", "Conturi de stocuri si productie in curs de executie", 3, "P", "" },
                    { 3947, "Ajustări pentru deprecierea produselor agricole", "Conturi de stocuri si productie in curs de executie", 3, "P", "" },
                    { 3951, "Ajustări pentru deprecierea materiilor şi materialelor aflate la terţi", "Conturi de stocuri si productie in curs de executie", 3, "P", "" },
                    { 3952, "Ajustări pentru deprecierea semifabricatelor aflate la terţi", "Conturi de stocuri si productie in curs de executie", 3, "P", "" },
                    { 3953, "Ajustări pentru deprecierea produselor finite aflate la terţi", "Conturi de stocuri si productie in curs de executie", 3, "P", "" },
                    { 3954, "Ajustări pentru deprecierea produselor reziduale aflate la terţi", "Conturi de stocuri si productie in curs de executie", 3, "P", "" },
                    { 3955, "Ajustări pentru deprecierea produselor agricole aflate la terţi", "Conturi de stocuri si productie in curs de executie", 3, "P", "" },
                    { 3956, "Ajustări pentru deprecierea activelorBiologice de natura stocurilor aflate la terţi", "Conturi de stocuri si productie in curs de executie", 3, "P", "" },
                    { 3957, "Ajustări pentru deprecierea mărfurilor aflate la terţi", "Conturi de stocuri si productie in curs de executie", 3, "P", "" },
                    { 3958, "Ajustări pentru deprecierea ambalajelor aflate la terţi", "Conturi de stocuri si productie in curs de executie", 3, "P", "" },
                    { 4091, "Furnizori - debitori pentru cumpărări deBunuri de natura stocurilor", "Conturi de terti", 4, "A", "Bun" },
                    { 4092, "Furnizori - debitori pentru prestări de servicii", "Conturi de terti", 4, "A", "Serviciu" },
                    { 4093, "Avansuri acordate pentru imobilizări corporale", "Conturi de terti", 4, "A", "Bun" },
                    { 4094, "Avansuri acordate pentru imobilizări necorporale", "Conturi de terti", 4, "A", "Bun" },
                    { 4111, "Clienţi", "Conturi de terti", 4, "A", "" },
                    { 4118, "Clienţi incerţi sau în litigiu", "Conturi de terti", 4, "A", "" },
                    { 4281, "Alte datorii în legătură cu personalul", "Conturi de terti", 4, "P", "" },
                    { 4282, "Alte creanţe în legătură cu personalul", "Conturi de terti", 4, "A", "" },
                    { 4311, "Contribuţia unităţii la asigurările sociale", "Conturi de terti", 4, "P", "" },
                    { 4312, "Contribuţia personalului la asigurările sociale", "Conturi de terti", 4, "P", "" },
                    { 4313, "Contribuţia angajatorului pentru asigurările sociale de sănătate", "Conturi de terti", 4, "P", "" },
                    { 4314, "Contribuţia angajaţilor pentru asigurările sociale de sănătate", "Conturi de terti", 4, "P", "" },
                    { 4315, "Contribuţia de asigurări sociale", "Conturi de terti", 4, "P", "" },
                    { 4316, "Contribuţia de asigurări sociale de sănătate", "Conturi de terti", 4, "P", "" },
                    { 4318, "Alte contribuţii pentru asigurările sociale de sănătate", "Conturi de terti", 4, "P", "" },
                    { 4371, "Contribuţia unităţii la fondul de şomaj", "Conturi de terti", 4, "P", "" },
                    { 4372, "Contribuţia personalului la fondul de şomaj", "Conturi de terti", 4, "P", "" },
                    { 4381, "Alte datorii sociale", "Conturi de terti", 4, "P", "" },
                    { 4382, "Alte creanţe sociale", "Conturi de terti", 4, "A", "" },
                    { 4411, "Impozitul pe profit", "Conturi de terti", 4, "P", "" },
                    { 4413, "Diferențe de impozit determinate de incertitudinile legate de tratamentele fiscale", "Conturi de terti", 4, "B", "" },
                    { 4415, "Impozitul specific unor activităţi", "Conturi de terti", 4, "P", "" },
                    { 4418, "Impozitul pe venit", "Conturi de terti", 4, "P", "" },
                    { 4423, "TVA de plată", "Conturi de terti", 4, "P", "" },
                    { 4424, "TVA de recuperat", "Conturi de terti", 4, "A", "" },
                    { 4426, "TVA deductibilă", "Conturi de terti", 4, "A", "" },
                    { 4427, "TVA colectată", "Conturi de terti", 4, "P", "" },
                    { 4428, "TVA neexigibilă", "Conturi de terti", 4, "B", "" },
                    { 4451, "Subvenţii guvernamentale", "Conturi de terti", 4, "A", "" },
                    { 4452, "Împrumuturi nerambursabile cu caracter de subvenţii", "Conturi de terti", 4, "A", "" },
                    { 4458, "Alte sume primite cu caracter de subvenţii", "Conturi de terti", 4, "A", "" },
                    { 4481, "Alte datorii faţă deBugetul statului", "Conturi de terti", 4, "P", "" },
                    { 4482, "Alte creanţe privindBugetul statului", "Conturi de terti", 4, "A", "" },
                    { 4511, "Decontări între entităţile afiliate", "Conturi de terti", 4, "B", "" },
                    { 4518, "Dobânzi aferente decontărilor între entităţile afiliate", "Conturi de terti", 4, "B", "" },
                    { 4531, "Decontări cu entităţile asociate şi entităţile controlate", "Conturi de terti", 4, "B", "" },
                    { 4538, "Dobânzi aferente decontărilor cu entităţile asociate şi entităţile controlate în comun", "Conturi de terti", 4, "B", "" },
                    { 4551, "Acţionari/Asociaţi - conturi curente", "Conturi de terti", 4, "P", "" },
                    { 4558, "Acţionari/Asociaţi - dobânzi la conturi curente", "Conturi de terti", 4, "P", "" },
                    { 4581, "Decontări din operaţiuni în participaţie - pasiv", "Conturi de terti", 4, "P", "" },
                    { 4582, "Decontări din operaţiuni în participaţie - activ", "Conturi de terti", 4, "A", "" },
                    { 4661, "Datorii din operaţiuni de fiducie", "Conturi de terti", 4, "P", "" },
                    { 4662, "Creanţe din operaţiuni de fiducie", "Conturi de terti", 4, "A", "" },
                    { 4751, "Subvenţii guvernamentale pentru investiţii", "Conturi de terti", 4, "P", "" },
                    { 4752, "Împrumuturi nerambursabile cu caracter de subvenţii pentru investiţii", "Conturi de terti", 4, "P", "" },
                    { 4753, "Donaţii pentru investiţii", "Conturi de terti", 4, "P", "" },
                    { 4754, "Plusuri de inventar de natura imobilizărilor", "Conturi de terti", 4, "P", "" },
                    { 4758, "Alte sume primite cu caracter de subvenţii pentru investiţii", "Conturi de terti", 4, "P", "" },
                    { 4901, "Ajustări pentru deprecierea creanţelor aferente cumpărărilor deBunuri de natura stocurilor", "Conturi de terti", 4, "P", "" },
                    { 4902, "Ajustări pentru deprecierea creanţelor aferente prestărilor de servicii", "Conturi de terti", 4, "P", "" },
                    { 4903, "Ajustări pentru deprecierea creanţelor aferente imobilizărilor corporale", "Conturi de terti", 4, "P", "" },
                    { 4904, "Ajustări pentru deprecierea creanţelor aferente imobilizărilor necorporale", "Conturi de terti", 4, "P", "" },
                    { 5081, "Alte titluri de plasament", "Conturi de trezorerie", 5, "A", "" },
                    { 5088, "Dobânzi la obligaţiuni şi titluri de plasament", "Conturi de trezorerie", 5, "A", "" },
                    { 5091, "Vărsăminte de efectuat pentru acţiunile deţinute la entităţile afiliate", "Conturi de trezorerie", 5, "P", "" },
                    { 5092, "Vărsăminte de efectuat pentru alte investiţii pe termen scurt", "Conturi de trezorerie", 5, "P", "" },
                    { 5112, "Cecuri de încasat", "Conturi de trezorerie", 5, "A", "" },
                    { 5113, "Efecte de încasat", "Conturi de trezorerie", 5, "A", "" },
                    { 5114, "Efecte remise spre scontare", "Conturi de trezorerie", 5, "A", "" },
                    { 5121, "Conturi laBănci în lei", "Conturi de trezorerie", 5, "A", "" },
                    { 5124, "Conturi laBănci în valută", "Conturi de trezorerie", 5, "A", "" },
                    { 5125, "Sume în curs de decontare", "Conturi de trezorerie", 5, "A", "" },
                    { 5126, "Conturi laBănci în lei - TVA defalcat", "Conturi de trezorerie", 5, "A", "" },
                    { 5127, "Conturi laBănci în valută - TVA defalcat", "Conturi de trezorerie", 5, "A", "" },
                    { 5186, "Dobânzi de plătit", "Conturi de trezorerie", 5, "P", "" },
                    { 5187, "Dobânzi de încasat", "Conturi de trezorerie", 5, "A", "" },
                    { 5191, "CrediteBancare pe termen scurt", "Conturi de trezorerie", 5, "P", "" },
                    { 5192, "CrediteBancare pe termen scurt nerambursate la scadenţă", "Conturi de trezorerie", 5, "P", "" },
                    { 5193, "Credite externe guvernamentale", "Conturi de trezorerie", 5, "P", "" },
                    { 5194, "Credite externe garantate de stat", "Conturi de trezorerie", 5, "P", "" },
                    { 5195, "Credite externe garantate deBănci", "Conturi de trezorerie", 5, "P", "" },
                    { 5196, "Credite de la Trezoreria Statului", "Conturi de trezorerie", 5, "P", "" },
                    { 5197, "Credite interne garantate de stat", "Conturi de trezorerie", 5, "P", "" },
                    { 5198, "Dobânzi aferente creditelorBancare pe termen scurt", "Conturi de trezorerie", 5, "P", "" },
                    { 5311, "Casa în lei", "Conturi de trezorerie", 5, "A", "" },
                    { 5314, "Casa în valută", "Conturi de trezorerie", 5, "A", "" },
                    { 5321, "Timbre fiscale şi poştale", "Conturi de trezorerie", 5, "A", "" },
                    { 5322, "Bilete de tratament şi odihnă", "Conturi de trezorerie", 5, "A", "" },
                    { 5323, "Tichete şiBilete de călătorie", "Conturi de trezorerie", 5, "A", "" },
                    { 5328, "Alte valori", "Conturi de trezorerie", 5, "A", "" },
                    { 5411, "Acreditive în lei", "Conturi de trezorerie", 5, "A", "" },
                    { 5414, "Acreditive în valută", "Conturi de trezorerie", 5, "A", "" },
                    { 6021, "Cheltuieli cu materialele auxiliare", "Conturi de cheltuieli", 6, "A", "Bun" },
                    { 6022, "Cheltuieli privind combustibilii", "Conturi de cheltuieli", 6, "A", "Bun" },
                    { 6023, "Cheltuieli privind materialele pentru ambalat", "Conturi de cheltuieli", 6, "A", "Bun" },
                    { 6024, "Cheltuieli privind piesele de schimb", "Conturi de cheltuieli", 6, "A", "Bun" },
                    { 6025, "Cheltuieli privind seminţele şi materialele de plantat", "Conturi de cheltuieli", 6, "A", "Bun" },
                    { 6026, "Cheltuieli privind furajele", "Conturi de cheltuieli", 6, "A", "Bun" },
                    { 6028, "Cheltuieli privind alte materiale consumabile", "Conturi de cheltuieli", 6, "A", "Bun" },
                    { 6051, "Cheltuieli privind consumul de energie", "Conturi de cheltuieli", 6, "A", "Bun" },
                    { 6052, "Cheltuieli privind consumul de apă", "Conturi de cheltuieli", 6, "A", "Bun" },
                    { 6053, "Cheltuieli privind consumul de gaze naturale", "Conturi de cheltuieli", 6, "A", "Bun" },
                    { 6058, "Cheltuieli cu alte utilităţi", "Conturi de cheltuieli", 6, "A", "Bun" },
                    { 6231, "Cheltuieli de protocol", "Conturi de cheltuieli", 6, "A", "Serviciu" },
                    { 6232, "Cheltuieli de reclamă şi publicitate", "Conturi de cheltuieli", 6, "A", "Serviciu" },
                    { 6421, "Cheltuieli cu avantajele în natură acordate salariaţilor", "Conturi de cheltuieli", 6, "A", "" },
                    { 6422, "Cheltuieli cu tichetele acordate salariaţilor", "Conturi de cheltuieli", 6, "A", "" },
                    { 6451, "Cheltuieli privind contribuţia unităţii la asigurările sociale", "Conturi de cheltuieli", 6, "A", "" },
                    { 6452, "Cheltuieli privind contribuţia unităţii pentru ajutorul de şomaj", "Conturi de cheltuieli", 6, "A", "" },
                    { 6453, "Cheltuieli privind contribuţia angajatorului pentru asigurările sociale de sănătate", "Conturi de cheltuieli", 6, "A", "" },
                    { 6455, "Cheltuieli privind contribuţia unităţii la asigurările de viaţă", "Conturi de cheltuieli", 6, "A", "" },
                    { 6456, "Cheltuieli privind contribuţia unităţii la fondurile de pensii facultative", "Conturi de cheltuieli", 6, "A", "" },
                    { 6457, "Cheltuieli privind contribuţia unităţii la primele de asigurare voluntară de sănătate", "Conturi de cheltuieli", 6, "A", "" },
                    { 6458, "Alte cheltuieli privind asigurările şi protecţia socială", "Conturi de cheltuieli", 6, "A", "" },
                    { 6461, "Cheltuieli privind contribuția asiguratorie pentru muncă corespunzătoare salariaților", "Conturi de cheltuieli", 6, "A", "" },
                    { 6462, "Cheltuieli privind contribuția asiguratorie pentru muncă corespunzătoare altor persoane, decât salariații", "Conturi de cheltuieli", 6, "A", "" },
                    { 6511, "Cheltuieli ocazionate de constituirea fiduciei", "Conturi de cheltuieli", 6, "A", "" },
                    { 6512, "Cheltuieli din derularea operaţiunilor de fiducie", "Conturi de cheltuieli", 6, "A", "" },
                    { 6513, "Cheltuieli din lichidarea operaţiunilor de fiducie", "Conturi de cheltuieli", 6, "A", "" },
                    { 6565, "Pierderi din evaluarea la valoarea justă a activelor aferente dreptului de utilizare care corespund definiției unei investiții imobiliare", "Conturi de cheltuieli", 6, "A", "" },
                    { 6581, "Despăgubiri, amenzi şi penalităţi", "Conturi de cheltuieli", 6, "A", "" },
                    { 6582, "Donaţii acordate", "Conturi de cheltuieli", 6, "A", "" },
                    { 6583, "Cheltuieli privind activele cedate şi alte operaţiuni de capital", "Conturi de cheltuieli", 6, "A", "" },
                    { 6584, "Cheltuieli cu sumele sauBunurile acordate ca sponsorizări", "Conturi de cheltuieli", 6, "A", "" },
                    { 6586, "Cheltuieli reprezentând transferuri şi contribuţii datorate înBaza unor acte normative speciale", "Conturi de cheltuieli", 6, "A", "" },
                    { 6587, "Cheltuieli privind calamităţile şi alte evenimente similare", "Conturi de cheltuieli", 6, "A", "" },
                    { 6588, "Alte cheltuieli de exploatare", "Conturi de cheltuieli", 6, "A", "" },
                    { 6641, "Cheltuieli privind imobilizările financiare cedate", "Conturi de cheltuieli", 6, "A", "" },
                    { 6642, "Pierderi din investiţiile pe termen scurt cedate", "Conturi de cheltuieli", 6, "A", "" },
                    { 6651, "Diferenţe nefavorabile de curs valutar legate de elementele monetare exprimate în valută", "Conturi de cheltuieli", 6, "A", "" },
                    { 6652, "Diferenţe nefavorabile de curs valutar din evaluarea elementelor monetare care fac parte din investiţia netă într-o entitate străină", "Conturi de cheltuieli", 6, "A", "" },
                    { 6811, "Cheltuieli de exploatare privind amortizarea imobilizărilor", "Conturi de cheltuieli", 6, "A", "" },
                    { 6812, "Cheltuieli de exploatare privind provizioanele", "Conturi de cheltuieli", 6, "A", "" },
                    { 6813, "Cheltuieli de exploatare privind ajustările pentru deprecierea imobilizărilor", "Conturi de cheltuieli", 6, "A", "" },
                    { 6814, "Cheltuieli de exploatare privind ajustările pentru deprecierea activelor circulante", "Conturi de cheltuieli", 6, "A", "" },
                    { 6817, "Cheltuieli de exploatare privind ajustările pentru deprecierea fondului comercial", "Conturi de cheltuieli", 6, "A", "" },
                    { 6818, "Cheltuieli de exploatare privind ajustările pentru deprecierea creanţelor reprezentând avansuri acordate furnizorilor", "Conturi de cheltuieli", 6, "A", "" },
                    { 6861, "Cheltuieli privind actualizarea provizioanelor", "Conturi de cheltuieli", 6, "A", "" },
                    { 6863, "Cheltuieli financiare privind ajustările pentru pierderea de valoare a imobilizărilor financiare", "Conturi de cheltuieli", 6, "A", "" },
                    { 6864, "Cheltuieli financiare privind ajustările pentru pierderea de valoare a activelor circulante", "Conturi de cheltuieli", 6, "A", "" },
                    { 6865, "Cheltuieli financiare privind amortizarea diferenţelor aferente titlurilor de stat", "Conturi de cheltuieli", 6, "A", "" },
                    { 6868, "Cheltuieli financiare privind amortizarea primelor de rambursare a obligaţiunilor şi a altor datorii", "Conturi de cheltuieli", 6, "A", "" },
                    { 7015, "Venituri din vânzarea produselor finite", "Conturi de venituri", 7, "P", "Bun" },
                    { 7017, "Venituri din vânzarea produselor agricole", "Conturi de venituri", 7, "P", "Bun" },
                    { 7018, "Venituri din vânzarea activelorBiologice de natura stocurilor", "Conturi de venituri", 7, "P", "Bun" },
                    { 7411, "Venituri din subvenţii de exploatare aferente cifrei de afaceri", "Conturi de venituri", 7, "P", "" },
                    { 7412, "Venituri din subvenţii de exploatare pentru materii prime şi materiale", "Conturi de venituri", 7, "P", "" },
                    { 7413, "Venituri din subvenţii de exploatare pentru alte cheltuieli externe", "Conturi de venituri", 7, "P", "" },
                    { 7414, "Venituri din subvenţii de exploatare pentru plata personalului", "Conturi de venituri", 7, "P", "" },
                    { 7415, "Venituri din subvenţii de exploatare pentru asigurări şi protecţie socială", "Conturi de venituri", 7, "P", "" },
                    { 7416, "Venituri din subvenţii de exploatare pentru alte cheltuieli de exploatare", "Conturi de venituri", 7, "P", "" },
                    { 7417, "Venituri din subvenţii de exploatare în caz de calamităţi şi alte evenimente similare", "Conturi de venituri", 7, "P", "" },
                    { 7418, "Venituri din subvenţii de exploatare pentru dobânda datorată", "Conturi de venituri", 7, "P", "" },
                    { 7419, "Venituri din subvenţii de exploatare aferente altor venituri", "Conturi de venituri", 7, "P", "" },
                    { 7511, "Venituri ocazionate de constituirea fiduciei", "Conturi de venituri", 7, "P", "" },
                    { 7512, "Venituri din derularea operaţiunilor de fiducie", "Conturi de venituri", 7, "P", "" },
                    { 7513, "Venituri din lichidarea operaţiunilor de fiducie", "Conturi de venituri", 7, "P", "" },
                    { 7565, "Câștiguri din evaluarea la valoarea justă a activelor aferente dreptului de utilizare care corespund definiției unei investiții imobiliare", "Conturi de venituri", 7, "P", "" },
                    { 7581, "Venituri din despăgubiri, amenzi şi penalităţi", "Conturi de venituri", 7, "P", "" },
                    { 7582, "Venituri din donaţii primite", "Conturi de venituri", 7, "P", "" },
                    { 7583, "Venituri din vânzarea activelor şi alte operaţiuni de capital", "Conturi de venituri", 7, "P", "Bun" },
                    { 7584, "Venituri din subvenţii pentru investiţii", "Conturi de venituri", 7, "P", "" },
                    { 7586, "Venituri reprezentând transferuri cuvenite înBaza unor acte normative speciale", "Conturi de venituri", 7, "P", "" },
                    { 7588, "Alte venituri din exploatare", "Conturi de venituri", 7, "P", "Bun" },
                    { 7611, "Venituri din acţiuni deţinute la entităţile afiliate", "Conturi de venituri", 7, "P", "" },
                    { 7612, "Venituri din acţiuni deţinute la entităţi asociate", "Conturi de venituri", 7, "P", "" },
                    { 7613, "Venituri din acţiuni deţinute la entităţi controlate în comun", "Conturi de venituri", 7, "P", "" },
                    { 7615, "Venituri din alte imobilizări financiare", "Conturi de venituri", 7, "P", "" },
                    { 7641, "Venituri din imobilizări financiare cedate", "Conturi de venituri", 7, "P", "" },
                    { 7642, "Câştiguri din investiţii pe termen scurt cedate", "Conturi de venituri", 7, "P", "" },
                    { 7651, "Diferenţe favorabile de curs valutar legate de elementele monetare exprimate în valută", "Conturi de venituri", 7, "P", "" },
                    { 7652, "Diferenţe favorabile de curs valutar din evaluarea elementelor monetare care fac parte din investiţia netă într-o entitate străină", "Conturi de venituri", 7, "P", "" },
                    { 7812, "Venituri din provizioane", "Conturi de venituri", 7, "P", "" },
                    { 7813, "Venituri din ajustări pentru deprecierea imobilizărilor", "Conturi de venituri", 7, "P", "" },
                    { 7814, "Venituri din ajustări pentru deprecierea activelor circulante", "Conturi de venituri", 7, "P", "" },
                    { 7815, "Venituri din fondul comercial negativ", "Conturi de venituri", 7, "P", "" },
                    { 7818, "Venituri din ajustări pentru deprecierea creanţelor reprezentând avansuri acordate furnizorilor", "Conturi de venituri", 7, "P", "" },
                    { 7863, "Venituri financiare din ajustări pentru pierderea de valoare a imobilizărilor financiare", "Conturi de venituri", 7, "P", "" },
                    { 7864, "Venituri financiare din ajustări pentru pierderea de valoare a activelor circulante", "Conturi de venituri", 7, "P", "" },
                    { 7865, "Venituri financiare din amortizarea diferenţelor aferente titlurilor de stat", "Conturi de venituri", 7, "P", "" },
                    { 8011, "Giruri şi garanţii acordate", "Conturi speciale", 8, "B", "" },
                    { 8018, "Alte angajamente acordate", "Conturi speciale", 8, "B", "" },
                    { 8021, "Giruri şi garanţii primite", "Conturi speciale", 8, "B", "" },
                    { 8028, "Alte angajamente primite", "Conturi speciale", 8, "B", "" },
                    { 8031, "Imobilizări corporale primite cu chirie sau înBaza altor contracte similare", "Conturi speciale", 8, "B", "" },
                    { 8032, "Valori materiale primite spre prelucrare sau reparare", "Conturi speciale", 8, "B", "" },
                    { 8033, "Valori materiale primite în păstrare sau custodie", "Conturi speciale", 8, "B", "" },
                    { 8034, "Debitori scoşi din activ, urmăriţi în continuare", "Conturi speciale", 8, "B", "" },
                    { 8035, "Stocuri de natura obiectelor de inventar date în folosinţă", "Conturi speciale", 8, "B", "" },
                    { 8036, "Redevenţe, locaţii de gestiune, chirii şi alte datorii asimilate", "Conturi speciale", 8, "B", "" },
                    { 8037, "Efecte scontate neajunse la scadenţă", "Conturi speciale", 8, "B", "" },
                    { 8038, "Bunuri primite în administrare, concesiune, cu chirie şi alteBunuri similare", "Conturi speciale", 8, "B", "" },
                    { 8039, "Alte valori în afaraBilanţului", "Conturi speciale", 8, "B", "" },
                    { 8051, "Dobânzi de plătit", "Conturi speciale", 8, "B", "" },
                    { 8052, "Dobânzi de încasat", "Conturi speciale", 8, "B", "" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 121);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 129);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 167);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 201);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 203);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 205);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 206);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 208);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 211);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 212);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 214);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 215);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 216);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 217);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 223);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 224);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 227);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 231);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 235);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 261);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 262);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 263);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 264);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 265);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 266);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 301);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 303);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 308);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 321);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 322);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 323);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 326);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 327);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 328);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 331);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 332);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 341);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 345);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 346);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 347);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 348);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 351);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 354);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 356);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 357);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 358);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 361);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 368);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 371);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 378);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 381);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 388);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 391);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 393);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 396);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 397);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 398);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 401);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 403);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 404);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 405);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 408);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 413);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 418);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 419);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 421);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 423);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 424);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 425);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 426);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 427);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 431);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 436);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 444);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 446);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 447);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 456);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 457);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 461);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 462);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 463);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 467);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 471);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 472);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 473);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 475);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 478);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 481);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 482);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 491);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 495);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 496);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 501);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 505);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 506);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 507);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 542);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 581);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 591);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 595);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 596);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 598);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 601);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 602);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 603);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 604);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 605);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 606);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 607);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 608);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 609);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 611);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 612);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 613);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 614);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 615);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 621);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 622);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 623);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 624);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 625);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 626);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 627);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 628);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 635);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 641);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 642);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 643);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 644);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 645);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 646);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 652);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 654);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 655);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 658);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 663);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 664);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 665);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 666);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 667);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 668);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 681);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 686);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 691);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 693);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 694);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 695);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 698);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 701);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 702);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 703);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 704);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 705);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 706);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 707);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 708);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 709);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 711);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 712);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 721);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 722);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 725);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 741);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 754);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 755);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 758);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 761);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 762);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 764);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 765);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 766);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 767);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 768);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 781);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 786);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 792);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 794);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 801);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 802);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 803);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 804);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 805);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 806);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 807);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 808);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 809);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 891);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 892);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 899);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1011);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1012);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1015);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1016);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1017);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1018);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1031);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1033);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1038);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1041);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1042);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1043);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1044);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1061);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1063);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1068);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1081);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1082);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1091);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1092);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1095);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1171);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1172);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1173);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1174);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1175);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1176);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1411);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1412);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1491);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1495);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1498);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1511);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1512);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1513);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1514);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1515);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1516);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1517);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1518);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1614);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1615);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1617);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1618);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1621);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1622);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1623);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1624);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1625);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1626);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1627);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1661);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1663);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1681);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1682);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1685);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1686);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1687);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1691);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1692);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2071);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2075);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2111);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2112);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2131);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2132);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2133);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2671);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2672);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2673);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2674);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2675);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2676);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2677);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2678);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2679);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2691);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2692);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2693);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2695);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2801);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2803);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2805);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2806);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2807);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2808);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2811);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2812);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2813);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2814);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2815);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2816);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2817);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2903);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2905);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2906);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2908);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2911);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2912);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2913);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2914);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2915);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2916);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2917);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2931);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2935);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2961);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2962);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2963);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2964);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2965);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2966);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2968);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 3021);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 3022);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 3023);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 3024);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 3025);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 3026);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 3028);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 3921);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 3922);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 3941);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 3945);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 3946);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 3947);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 3951);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 3952);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 3953);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 3954);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 3955);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 3956);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 3957);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 3958);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4091);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4092);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4093);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4094);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4111);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4118);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4281);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4282);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4311);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4312);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4313);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4314);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4315);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4316);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4318);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4371);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4372);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4381);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4382);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4411);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4413);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4415);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4418);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4423);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4424);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4426);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4427);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4428);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4451);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4452);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4458);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4481);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4482);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4511);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4518);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4531);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4538);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4551);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4558);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4581);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4582);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4661);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4662);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4751);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4752);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4753);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4754);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4758);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4901);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4902);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4903);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4904);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 5081);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 5088);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 5091);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 5092);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 5112);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 5113);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 5114);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 5121);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 5124);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 5125);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 5126);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 5127);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 5186);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 5187);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 5191);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 5192);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 5193);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 5194);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 5195);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 5196);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 5197);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 5198);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 5311);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 5314);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 5321);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 5322);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 5323);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 5328);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 5411);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 5414);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6021);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6022);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6023);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6024);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6025);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6026);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6028);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6051);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6052);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6053);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6058);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6231);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6232);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6421);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6422);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6451);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6452);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6453);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6455);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6456);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6457);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6458);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6461);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6462);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6511);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6512);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6513);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6565);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6581);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6582);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6583);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6584);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6586);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6587);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6588);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6641);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6642);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6651);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6652);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6811);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6812);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6813);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6814);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6817);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6818);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6861);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6863);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6864);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6865);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6868);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 7015);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 7017);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 7018);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 7411);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 7412);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 7413);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 7414);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 7415);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 7416);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 7417);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 7418);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 7419);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 7511);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 7512);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 7513);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 7565);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 7581);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 7582);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 7583);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 7584);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 7586);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 7588);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 7611);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 7612);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 7613);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 7615);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 7641);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 7642);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 7651);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 7652);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 7812);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 7813);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 7814);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 7815);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 7818);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 7863);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 7864);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 7865);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 8011);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 8018);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 8021);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 8028);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 8031);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 8032);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 8033);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 8034);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 8035);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 8036);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 8037);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 8038);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 8039);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 8051);

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 8052);

            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                table: "ChartOfAccounts",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "isCredit",
                table: "ChartOfAccounts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isDebit",
                table: "ChartOfAccounts",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
