namespace AirQualityServer.Validators
{
    internal static class AirQualityValidator
    {
        //reference values should be declared in a file (persistence)
        
        /// <summary>
        /// </summary>
        /// <param name="value">The resistence in Ohms of the gas sensor.</param>
        /// <returns>Whether the C02 value is in normal limits or not.</returns>
        static bool ValidateCO2(int value)
        {
            ///
            return default;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value">The resistence in Ohms of the gas sensor.</param>
        /// <returns>Whether the TVOC value is in normal limits or not.</returns>
        static bool ValidateTVOC(int value)
        {
            ///
            return default;
        }
    }
}