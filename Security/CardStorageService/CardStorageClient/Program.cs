using Grpc.Net.Client;
using static ClientServiceProtos.ClientService;

Console.WriteLine("Создать клиента ...");
Console.ReadLine();

using (var channel = GrpcChannel.ForAddress("https://localhost:5001"))
{
    var client = new ClientServiceClient(channel);

    var response = client.Create(new ClientServiceProtos.CreateClientRequest
    {
        FirstName = "Иванова",
        Surname = "Екатерина",
        Patronymic = "Сергеевна"
    });

    Console.WriteLine($"ClientId: {response.ClientId}; ErrCode: {response.ErrorCode}; ErrMessage: {response.ErrorMessage}");

}