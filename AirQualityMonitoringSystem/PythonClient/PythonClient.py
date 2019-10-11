import sys
import grpc_tools
import grpc
import remote_keyboard_pb2
import remote_keyboard_pb2_grpc

def send_keys():
    yield remote_keyboard_pb2.KeyPressRequest(key_name='a')
    yield remote_keyboard_pb2.KeyPressRequest(key_name='a')
    yield remote_keyboard_pb2.KeyPressRequest(key_name='a')
    yield remote_keyboard_pb2.KeyPressRequest(key_name='a')

def main():
    channel = grpc.insecure_channel('localhost:50051')
    stub = remote_keyboard_pb2_grpc.RemoteKeyboardServiceStub(channel)
    
    print("Client sending request")
    result = stub.SendKeyboardCalls(send_keys())
    print(f'Response: {result}')
    

if __name__ == "__main__":
    sys.exit(int(main() or 0))