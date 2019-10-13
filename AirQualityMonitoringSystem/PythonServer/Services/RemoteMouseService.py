import logging
import remote_mouse_pb2
import remote_mouse_pb2_grpc

from Utils.MouseSimulator import MouseSimulator

class RemoteMouseService(remote_mouse_pb2_grpc.RemoteMouseServiceServicer):

    def SendMouseMovement(self, request, context):
        MouseSimulator.getInstance().move_cursor(request.x, request.y)
        return remote_mouse_pb2.MouseMovementResponse(result= True)

    def SendMouseClick(self, request, context):
        pass