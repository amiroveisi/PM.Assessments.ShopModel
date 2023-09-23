namespace PM.Assessments.ShopModel.Models.Domains.User
{
    /// <summary>
    /// This record represents an address with specific fields.
    /// It support value comparison by default using == operator.
    /// </summary>
    /// <param name="CountryCode">The ISO format of country code.</param>
    /// <param name="City">The city name.</param>
    /// <param name="Region">The region name. If there was no region name, it could be null.</param>
    /// <param name="AddressLine1">The 1st address line.</param>
    /// <param name="AddressLine2">The 2nd address line. If there was no 2nd address line, it could be null.</param>
    /// <param name="PostalCode">The postal code or ZIP code.</param>
    public record Address(string CountryCode, string City, string Region, string AddressLine1, string AddressLine2, string PostalCode)
    {

    }
}
