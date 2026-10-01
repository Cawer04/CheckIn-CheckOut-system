using Hydac;

namespace CheckInTest
{
    [TestClass]
    public sealed class Test1
    {
        [TestMethod]
        public void TestMethod1()
        {

           
            // 1. ARRANGE (Forberedelse)
            // Her opretter vi de objekter og de data, vi skal bruge. 
            Employee employee = new Employee("Peter", 10);
            Guest newGuest = new Guest();

            string testNavn = "Jens Jensen";
            string testFirma = "Tech Solutions";
            int testTime = 10;
            int testMinut = 15;

            // 2. ACT (Handling)
            // Her udfører vi den handling, der skal testes 
            // (svarende til det brugeren gjorde i konsollen).
            newGuest.SetName(testNavn);
            newGuest.SetCompany(testFirma);
            newGuest.SetArrivalHour(testTime);
            newGuest.SetArrivalMinute(testMinut);

            // Medarbejderen tilføjer gæsten
            employee.AddGuest(newGuest);


            // 3. ASSERT (Verificering)
            // Her tjekker vi, om resultatet er som forventet
            // Tjek at gæstens data er sat korrekt (kræver at du har Get-metoder)
            Assert.AreEqual(testNavn, newGuest.GetName());
            Assert.AreEqual(testFirma, newGuest.GetCompany());
            Assert.AreEqual(testTime, newGuest.GetArrivalHour());
            Assert.AreEqual(testMinut, newGuest.GetArrivalMinute());
            // Tjek at gæsten faktisk er blevet tilføjet til medarbejderens liste.
            // som returnerer listen af gæster, f.eks. employee.GetGuests() eller en property).
            // Assert.Contains(newGuest, employee.GetGuests());

        }
    }
}
