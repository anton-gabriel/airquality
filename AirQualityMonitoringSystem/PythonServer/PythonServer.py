import sys
import grpc
import time
from concurrent import futures
import remote_keyboard_pb2
import remote_keyboard_pb2_grpc
from RemoteKeyboardService import RemoteKeyboardService

_ONE_DAY_IN_SECONDS = 60 * 60 * 24

def open_server():
  server = grpc.server(futures.ThreadPoolExecutor(max_workers=1))
  remote_keyboard_pb2_grpc.add_RemoteKeyboardServiceServicer_to_server(RemoteKeyboardService(), server)
  server.add_insecure_port('[::]:50051')
  server.start()
  try:
      while True:
          time.sleep(_ONE_DAY_IN_SECONDS)
  except KeyboardInterrupt:
      server.stop(0)

def main():
    open_server()

if __name__ == "__main__":
    sys.exit(int(main() or 0))