import board
import adafruit_bme680
from busio import I2C

class EnvironmentSensor(object):
    """This class is a wrapper over BME680 sensor."""

    def __init__(self, **kwargs):
        """Create an instance of EnviorementSensor.
        
        Parameters:
            altitude_enabled (bool): if it's enabled the pressure will be set at sea level to get the most accurate measure
            sea_level_pressure (float): local sea level pressure to be set
            """

        altitude_enabled = kwargs.get(key= 'altitude_enabled', default= None)
        sea_level_pressure = kwargs.get(key= 'sea_level_pressure', default= None)
        
        self.__sensor = adafruit_bme680.Adafruit_BME680_I2C(I2C(board.SCL, board.SDA), debug=False)
        if altitude_enabled != None:
            if sea_level_pressure == None:
                raise ValueError("The altitude is enabled but the sea_level_pressure is missing.")
            else:
                self.__sensor.seaLevelhPa = sea_level_pressure

    def get_humidity(self):
        """Get the precent humidity as a float value from 0 to 100%.
        
        Parameters:
            None
            
        Returns:
            float: the humidity precent
        """
        return self.__sensor.humidity


    def get_temperatrure(self):
        """Get the temperature in degrees Celsius.

        Parameters:
            None

        Returns:
            float: the temperature value
        """
        return self.__sensor.temperature

    def get_gas(self):
        """Get the resistance of the gas sensor.
        
        Parameters:
            None
            
        Returns:
            int: the resistence in ohms"""
        return self.__sensor.gas

    def get_pressure(self):
        """Get the pressure value in hPa.
        
        Parameters:
            None
            
        Returns:
            float: the pressure in hPa"""
        return self.__sensor.pressure

    def get_altitude(self):
        """Get the altitude in meters.
        
        Parameters:
            None
            
        Returns:
            float: the altitude in meters"""
        return self.__sensor.altitude