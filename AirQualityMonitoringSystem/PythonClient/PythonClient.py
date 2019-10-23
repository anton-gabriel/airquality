import sys
import grpc_tools
import grpc
import sensors_pb2
import sensors_pb2_grpc



def main():
    channel = grpc.insecure_channel('localhost:50051')
    stub = sensors_pb2_grpc.SensorAirQualityServiceStub(channel)

    request = sensors_pb2.SensorAirQualityRequest(air_feature = sensors_pb2.eCO2)
    print('Client sending request')
    result = stub.SendAirFeature(request)
    print(f'Response: {result}')
    pass

if __name__ == "__main__":
    sys.exit(int(main() or 0))