import remote_keyboard_pb2
import remote_keyboard_pb2_grpc
from Utils.KeyboardSimulator import KeyboardSimulator


class RemoteKeyboardService(remote_keyboard_pb2_grpc.RemoteKeyboardServiceServicer):

    def SendKeyboardCalls(self, request_iterator, context):
        for key_press in request_iterator:
            KeyboardSimulator.getInstance().press_key(key_press.content)
            yield remote_keyboard_pb2.KeyPressResponse(content=key_press.content)