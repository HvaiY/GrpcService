# Grpc AspNetCore ����Demo

## Grpc����(GrpcService.Ben.Demo) 
 - ֱ��ʹ��΢���ṩ���ֱ�Ӵ���������һ������
## Grpc AspNetCore �ͻ���(GrpcClient.Ben.NetCore.Demo)

#### ��ɱ�дproto buffer �ļ��ӿ�֮��ֱ������ ֮����дʵ�ַ����� �̳�proto ���ɵĻ��࣬
 (proto3�﷨����)[https://developers.google.com/protocol-buffers/docs/proto3]
 - ע����Ҫ���¹����ļ� ��proto �ļ��������� �������������� 
  ```
  <ItemGroup>
		<Protobuf Include=".\Protos\*.proto" GrpcServices="Server" Link="Protos\%(RecursiveDir)%(Filename)%(Extension)" />
	</ItemGroup>
  ```
   
  - �����ͻ��˷���  `https://localhost:44349/api/Blog?code=12365&name=grpc Related&title=grpc ��ôǿ�����&descript=grpc ��demo`