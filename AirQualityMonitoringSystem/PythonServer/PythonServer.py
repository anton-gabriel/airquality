import sys
import grpc
import time
from concurrent import futures

_ONE_DAY_IN_SECONDS = 60 * 60 * 24


def open_server(port: str):
  server = grpc.server(futures.ThreadPoolExecutor(max_workers=2))
  #remote_keyboard_pb2_grpc.add_RemoteKeyboardServiceServicer_to_server(RemoteKeyboardService(), server)
  #remote_mouse_pb2_grpc.add_RemoteMouseServiceServicer_to_server(RemoteMouseService(), server)
  server.add_insecure_port(port)
  server.start()
  try:
      while True:
          time.sleep(_ONE_DAY_IN_SECONDS)
  except KeyboardInterrupt:
      server.stop(0)

def main():
    open_server(port= 'localhost:8080')

if __name__ == "__main__":
    sys.exit(int(main() or 0))