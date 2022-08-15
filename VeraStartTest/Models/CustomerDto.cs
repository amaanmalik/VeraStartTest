using CsvHelper.Configuration.Attributes;

namespace VeraStartTest.Models
{
    public class CustomerDto
    {
        [Name("customer_id")]
        public int CustomerId { get; set; }

        [Name("first_name")]
        public string FirstName { get; set; }

        [Name("last_name")]
        public string LastName { get; set; }

        [Name("phone")]
        public string Phone { get; set; }

        [Name("email")]
        public string Email { get; set; }

        [Name("street")]
        public string Street { get; set; }

        [Name("city")]
        public string City { get; set; }

        [Name("state")]
        public string State { get; set; }

        [Name("zip_code")]
        public int ZipCode { get; set; }

    }
}
