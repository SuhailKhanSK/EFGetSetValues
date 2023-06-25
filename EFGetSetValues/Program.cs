using EFGetSetValues.Models;

namespace EFGetSetValues
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            Country country = new Country()
            {
                CountryCode = 001,
                CountryName = "IND",
                Id = new Guid("7D13F4ED-E9B2-40A1-BA37-08DB60C5A1B8"),
                States = new List<State>()
                {
                    new State() {
                        StateName = "KAR",
                        StateCode = 002,
                        Id = new Guid("4F54F7F7-43F8-427C-CD01-08DB60D208A6"),
                        Districts = new List<District> {
                            new District() {
                                Id = new Guid("615B5C11-9A26-4657-D482-08DB60D29822"),
                                DistrictName = "DIS",
                                DistrictCode = 003
                            }
                        }
                    }
                }
            };


            Repository repository = new Repository();
            repository.Save(country);

            Console.WriteLine("Completed");

        }
    }
}