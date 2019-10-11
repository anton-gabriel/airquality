import logging
import remote_keyboard_pb2
import remote_keyboard_pb2_grpc
from KeyboardSimulator import KeyboardSimulator


class RemoteKeyboardService(remote_keyboard_pb2_grpc.RemoteKeyboardServiceServicer):

    def SendKeyboardCalls(self, request_iterator, context):
        for key in request_iterator:
            logging.info(f'Received {key} request.')
            KeyboardSimulator.getInstance().press_key(key.key_name)
            yield remote_keyboard_pb2.KeyPressResponse(key_name=key.key_name)