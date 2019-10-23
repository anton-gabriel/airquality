import sys
import grpc_tools
import grpc
import pickle
from threading import Thread
from time import sleep
import remote_keyboard_pb2
import remote_keyboard_pb2_grpc
import remote_mouse_pb2
import remote_mouse_pb2_grpc
from pynput.mouse import Button
from pynput import keyboard, mouse

keyboard_test = keyboard.Controller()

port = '10.2.60.189:50051'

channel = grpc.insecure_channel(port)
keyboard_stub = remote_keyboard_pb2_grpc.RemoteKeyboardServiceStub(channel)
mouse_stub = remote_mouse_pb2_grpc.RemoteMouseServiceStub(channel)


#-----------------------Mouse handlers---------------------------------#
def on_move(x, y):
    request = remote_mouse_pb2.MouseMovementRequest(x= x, y= y)
    response = mouse_stub.SendMouseMovement(request)
    print(f'Response: {response}')

def on_click(x, y, button, pressed):
    request_button, request_action = remote_mouse_pb2.Left, remote_mouse_pb2.Press
    if button == Button.right:
        request_button = remote_mouse_pb2.Left
    if not pressed:
        request_action = remote_mouse_pb2.Release
    request = remote_mouse_pb2.MouseClickRequest(button= request_button,
                                                 action= request_action)
    response = mouse_stub.SendMouseClick(request)
    print(f'Response: {response}')
#----------------------------------------------------------------------#


#--------------------------Keyboard handlers---------------------------#

def on_key_press(key):
    print(f'Key: {key}')
    request = remote_keyboard_pb2.KeyPressRequest(content= pickle.dumps(key, pickle.HIGHEST_PROTOCOL))
    response = keyboard_stub.SendKeyboardCall(request)
    print(f'Response: {response}')
#----------------------------------------------------------------------#


def main():
    #thread = Thread(target = run)
    #thread.start()
    ##with mouse.Listener(
    ##        on_move=on_move,
    ##        on_click=on_click) as listener:
    ##    listener.join()
    #thread.join()

    with keyboard.Listener(on_press=on_key_press) as listener:
        listener.join()

if __name__ == "__main__":
    sys.exit(int(main() or 0))