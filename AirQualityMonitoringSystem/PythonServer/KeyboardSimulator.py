from pynput.keyboard import Key, Controller

class KeyboardSimulator(object):

   __instance = None
   __keyboard = Controller()

   @staticmethod 
   def getInstance():
      if KeyboardSimulator.__instance == None:
         KeyboardSimulator()
      return KeyboardSimulator.__instance

   def __init__(self):
      if KeyboardSimulator.__instance != None:
         raise Exception("This class is a singleton!")
      else:
         KeyboardSimulator.__instance = self

   def press_key(self, key):
       self.__keyboard.type(key)

