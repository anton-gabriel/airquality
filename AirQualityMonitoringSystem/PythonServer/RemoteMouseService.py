import logging
import remote_mouse_pb2
import remote_mouse_pb2_grpc

from pynput.mouse import Button
from MouseSimulator import MouseSimulator

class RemoteMouseService(remote_mouse_pb2_grpc.RemoteMouseServiceServicer):

    def SendMouseMovement(self, request, context):
        MouseSimulator.getInstance().move_cursor(request.x, request.y)
        return remote_mouse_pb2.MouseMovementResponse(x= request.x, y= request.y,result= True)

    def SendMouseClick(self, request, context):
        button
        if request.button == remote_mouse_pb2.Left:
            button = Button.Left
        else:
            button = Button.Right
        if request.action == remote_mouse_pb2.Press:
            MouseSimulator.getInstance().press_cursor(button)
        else:
            MouseSimulator.getInstance().release_cursor(button)