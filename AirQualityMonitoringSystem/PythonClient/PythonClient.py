import sys
import grpc_tools
import grpc
import air_quality_pb2
import air_quality_pb2_grpc

def main():
    channel = grpc.insecure_channel('localhost:50051')
    stub = air_quality_pb2_grpc.AirQualityServiceStub(channel)

    
    request = air_quality_pb2.AirQualityRequest(air_feature=air_quality_pb2.CO2)
    print("Client sending request")
    result = stub.GetAirQuality(request)
    print(f'Response: {result}')
    

if __name__ == "__main__":
    sys.exit(int(main() or 0))