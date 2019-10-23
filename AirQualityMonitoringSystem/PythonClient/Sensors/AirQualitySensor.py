import board
import adafruit_sgp30
from busio import I2C

class AirQualitySensor(object):
    """This class is a wrapper over SGP30 sensor."""
    
    __DEFAULT_CO2 = 400
    __DEFAULT_TVOC = 0

    def __init__(self, **kwargs):
        """Create an instance of AirQualitySensor.

        Parameters:
           
        """

        self.__sensor = adafruit_sgp30.Adafruit_SGP30(I2C(board.SCL, board.SDA, frequency=100000))
        self.__sensor.iaq_init()
        self.__sensor.set_iaq_baseline(0x8973, 0x8aae)
    
    def get_eCO2(self):
        """Get the eCO2 value.

        Parameters:
            None
            
        Returns:
            dict: contains the calibration status and the eCO2 value

        """
        return {
            'calibrated' : self.__is_calibrated(),
            'value' : self.__sensor.eCO2
            }

    def get_TVOC(self):
        """Get the TVOC value (Total Volatile Organic Compounds).
        
        Parameters:
            None

        Returns:
            dict: contains the calibration status and the TVOC value

        """
        return {
            'calibrated' : self.__is_calibrated(),
            'value' : self.__sensor.TVOC
            }


    def __is_calibrated(self):
        """Check whether the sensor is calibrated or not.
           
        Parameters:
            None

        Returns:
            bool: the calibration check result
        """
        return (self.__sensor.eCO2 != self.__DEFAULT_CO2) or  (self.__sensor.TVOC != self.__DEFAULT_TVOC)