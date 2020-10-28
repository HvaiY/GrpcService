# Grpc AspNetCore 服务Demo

## Grpc服务(GrpcService.Ben.Demo) 
 - 直接使用微软提供框架直接创建，增加一个过滤
## Grpc AspNetCore 客户端(GrpcClient.Ben.NetCore.Demo)

#### 完成编写proto buffer 文件接口之后直接生成 之后再写实现方法类 继承proto 生成的基类，
 (proto3语法规则)[https://developers.google.com/protocol-buffers/docs/proto3]
 - 注意需要更新工程文件 将proto 文件包含在内 下面是批量包含 
  ```
  <ItemGroup>
		<Protobuf Include=".\Protos\*.proto" GrpcServices="Server" Link="Protos\%(RecursiveDir)%(Filename)%(Extension)" />
	</ItemGroup>
  ```
   
  - 启动客户端访问  `https://localhost:44349/api/Blog?code=12365&name=grpc Related&title=grpc 这么强大的吗&descript=grpc 简单demo`