import remote_keyboard_pb2
import remote_keyboard_pb2_grpc
import pickle
from pynput.keyboard import Controller

keyboard_test = Controller()

class RemoteKeyboardService(remote_keyboard_pb2_grpc.RemoteKeyboardServiceServicer):

    def SendKeyboardCall(self, request, context):
        key = pickle.loads(request.content)
        print(f"{key} - {type(key)}")
        keyboard_test.press(pickle.loads(request.content))
        return remote_keyboard_pb2.KeyPressResponse(result= True)