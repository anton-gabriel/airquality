from pynput.mouse import Button, Controller

class MouseSimulator(object):

   __instance = None
   __mouse = Controller()

   @staticmethod 
   def getInstance():
      if MouseSimulator.__instance == None:
         MouseSimulator()
      return MouseSimulator.__instance

   def __init__(self):
      if MouseSimulator.__instance != None:
         raise Exception("This class is a singleton!")
      else:
         MouseSimulator.__instance = self

   def move_cursor(self, x, y):
       self.__mouse.position = (x,y)

   def press_cursor(self, button: Button):
       self.__mouse.press(button)

   def release_cursor(self, button: Button):
       self.__mouse.release(button)