using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp3.Data
{
    public class MedicamentDbContext : DbContext
    {
        public DbSet<Medicament> Medicaments { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<JobTitle> JobTitles { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<OrderClient> Orders { get; set; }
        public DbSet<Shipment> Shipments { get; set; }
        public DbSet<Storage> Storages { get; set; }
        public DbSet<MedicamentFirms> MedicamentFirms { get; set; }
        public MedicamentDbContext(DbContextOptions<MedicamentDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public MedicamentDbContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Medicament>().HasData(GetMedicaments());
            modelBuilder.Entity<MedicamentFirms>().HasData(GetMedicamentFirms());          
            modelBuilder.Entity<Client>().HasData(GetClient());
            modelBuilder.Entity<Basket>().HasData(GetBasket());
            modelBuilder.Entity<JobTitle>().HasData(GetJobTitle());
            modelBuilder.Entity<Employee>().HasData(GetEmployee());
            modelBuilder.Entity<OrderClient>().HasData(GetOrderClient());  
            modelBuilder.Entity<Storage>().HasData(GetStorage());
            modelBuilder.Entity<Shipment>().HasData(GetShipment());

            base.OnModelCreating(modelBuilder);
        }

        private Medicament[] GetMedicaments()
        {
            return new Medicament[]
            {
                new Medicament { id_Medicament = 1, nameMedicament = "Парацетамол", medicamentOnRecept = false,healthEffect="Жаропонижающее и обезболивающее",priceMedicament = 150},
                new Medicament { id_Medicament = 2, nameMedicament = "Ремантадин", medicamentOnRecept = false,healthEffect="Противовирусное",priceMedicament = 300},
                new Medicament { id_Medicament = 3, nameMedicament = "Морфин", medicamentOnRecept = true,healthEffect="Обезболивающее",priceMedicament = 1500}
            };
        }
        private Client[] GetClient()
        {
            return new Client[]
            {
                new Client {id_Client=1, ageClient = 25, fioClient = "Иванов Иван Иванович", gender = "М", hasRecept = true, phoneNumber = "89123460067"},
                new Client {id_Client=2, ageClient = 38, fioClient = "Глебов Глеб Глебович", gender = "М", hasRecept = false, phoneNumber = "89878990321"},
                new Client {id_Client=3, ageClient = 19, fioClient = "Никитов Никита Никитович", gender = "М", hasRecept = true, phoneNumber = "89228841465"}
            };
        }
        private Basket[] GetBasket()
        {
            return new Basket[]
            {
                new Basket {id_Basket=1, id_Medicament = 1, fioClient = "Иванов Иван Иванович", countMedicament = 2},
                new Basket {id_Basket=2, id_Medicament = 2, fioClient = "Глебов Глеб Глебович", countMedicament = 1},
                new Basket {id_Basket=3, id_Medicament = 3, fioClient = "Никитов Никита Никитович", countMedicament = 3}
            };
        }
        private Employee[] GetEmployee()
        {
            return new Employee[]
            {
                new Employee {id_Employee=1, fioEmployee = "Тиньков Олег Денисович", gender = "М", id_JobTitle = 1},
                new Employee {id_Employee=2, fioEmployee = "Кузнецова Анна Владимировна", gender = "Ж", id_JobTitle = 2},
                new Employee {id_Employee=3, fioEmployee = "Смирнова Елена Владимировна", gender = "Ж", id_JobTitle = 3}
            };
        }
        private JobTitle[] GetJobTitle()
        {
            return new JobTitle[]
            {
                new JobTitle {id_JobTitle=1, nameJobTitle = "Менеджер"},
                new JobTitle {id_JobTitle=2, nameJobTitle = "Продавец"},
                new JobTitle {id_JobTitle=3, nameJobTitle = "Кассир"}
            };
        }
        private MedicamentFirms[] GetMedicamentFirms()
        {
            return new MedicamentFirms[]
            {
                new MedicamentFirms { id_Firms = 1, nameFirms = "Русская фирма", countryPlace = "Россия", id_Medicament = 1},
                new MedicamentFirms { id_Firms = 2, nameFirms = "Русская фирма", countryPlace = "Россия", id_Medicament = 2},
                new MedicamentFirms { id_Firms = 3, nameFirms = "Другая фирма", countryPlace = "Не Россия", id_Medicament = 1},

            };
        }
        private OrderClient[] GetOrderClient()
        {
            return new OrderClient[]
            {
                new OrderClient {id_Order=1, dateOrder = new DateTime(2024, 12, 31, 23, 59, 59), id_Basket = 1, id_Employee = 2},
                new OrderClient {id_Order=2, dateOrder = new DateTime(2024, 12, 31, 23, 59, 59), id_Basket = 2, id_Employee = 3},
                new OrderClient {id_Order=3, dateOrder = new DateTime(2024, 12, 31, 23, 59, 59), id_Basket = 3, id_Employee = 1}

            };
        }
        private Shipment[] GetShipment()
        {
            return new Shipment[]
            {
                new Shipment {id_Shipment=1, dateShipment = new DateTime(2024, 12, 31, 23, 59, 59), id_Employee = 2, id_Firms = 1, id_Medicament = 2},
                new Shipment {id_Shipment=2, dateShipment = new DateTime(2024, 12, 31, 23, 59, 59), id_Employee = 3, id_Firms = 2, id_Medicament = 1},
                new Shipment {id_Shipment=3, dateShipment = new DateTime(2024, 12, 31, 23, 59, 59), id_Employee = 1, id_Firms = 3, id_Medicament = 3}

            };
        }
        private Storage[] GetStorage()
        {
            return new Storage[]
            {
                new Storage {id_MedicamentPosition=1, id_Medicament = 1, countOnStorage = 100},
                new Storage {id_MedicamentPosition=2, id_Medicament = 2, countOnStorage = 200},
                new Storage {id_MedicamentPosition=3, id_Medicament = 3, countOnStorage = 300}
            };
        }

    }
}
