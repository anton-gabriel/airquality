import sys
import grpc_tools
import grpc
from threading import Thread
from time import sleep
import remote_keyboard_pb2
import remote_keyboard_pb2_grpc
import remote_mouse_pb2
import remote_mouse_pb2_grpc
from pynput.mouse import Listener

port = '192.168.1.8:50051'

channel = grpc.insecure_channel(port)
keyboard_stub = remote_keyboard_pb2_grpc.RemoteKeyboardServiceStub(channel)
mouse_stub = remote_mouse_pb2_grpc.RemoteMouseServiceStub(channel)

def on_move(x, y):
    response = mouse_stub.SendMouseMovement(remote_mouse_pb2.MouseMovementRequest(x= x, y= y))
    print(f'Mouse response: {response.result}')

def on_click(x, y, button, pressed):
    pass
    #'Pressed' if pressed else 'Released'
    


def send_keys():
    while True:
        content = input()
        if content == 'stop':
            return
        yield remote_keyboard_pb2.KeyPressRequest(content=content)

def run():
    print("Client sending request")
    keyboard_responses = keyboard_stub.SendKeyboardCalls(send_keys())
    for response in keyboard_responses:
        print(f'Response: {response}')


def main():
    run()
    thread = Thread(target = run)
    thread.start()
    with Listener(
            on_move=on_move,
            on_click=on_click) as listener:
        listener.join()
    thread.join()

if __name__ == "__main__":
    sys.exit(int(main() or 0))