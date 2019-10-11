import sys
import grpc_tools
import grpc
import remote_keyboard_pb2
import remote_keyboard_pb2_grpc

def send_keys():
    while True:
        key = input()
        if key == 'stop':
            return
        yield remote_keyboard_pb2.KeyPressRequest(key_name=key)

def run():
    with grpc.insecure_channel('localhost:50051') as channel:
        stub = remote_keyboard_pb2_grpc.RemoteKeyboardServiceStub(channel)
        print("Client sending request")
        responses = stub.SendKeyboardCalls(send_keys())
        for response in responses:
            print(f'Response: {response}')

def main():
    run()

if __name__ == "__main__":
    sys.exit(int(main() or 0))