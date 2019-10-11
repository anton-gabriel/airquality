import remote_keyboard_pb2
import remote_keyboard_pb2_grpc


class RemoteKeyboardService(remote_keyboard_pb2_grpc.RemoteKeyboardServiceServicer):

    def SendKeyboardCalls(self, request_iterator, context):
        for key in request_iterator:
            yield remote_keyboard_pb2.KeyPressResponse(key_name='a')