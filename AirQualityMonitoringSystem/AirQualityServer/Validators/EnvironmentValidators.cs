namespace AirQualityServer.Validators
{
    internal static class EnvironmentValidators
    {
        //Instead of bool return Enum that specify the risk Level (Normal, Alert, Danger...)

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value">The resistence in Ohms of the sensor.</param>
        /// <returns>Whether the value is in normal limits or not.</returns>
        static bool ValidateGas(int value)
        {
            ///
            return default;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Whether the value is in normal limits or not.</returns>
        static bool ValidateHumidity(double value)
        {
            ///
            return default;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Whether the value is in normal limits or not.</returns>
        static bool ValidatePressure(double value)
        {
            ///
            return default;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Whether the value is in normal limits or not.</returns>
        static bool ValidateTemperature(double value)
        {
            ///
            return default;
        }
    }
}