namespace Messaging;

/*
https://api.cloudamqp.com/console/10ead49b-969e-47b7-af82-b59222f501e5/details
*/

public static class RabbitMqConnectionSettings
{
    public static string HostName => "goose.rmq2.cloudamqp.com";

    public static ushort Port => 5672;

    public static string UserAndVHost => "cfvptvpp";

    public static string Password => "LexAWJt0rqZ25VKW59xLTp4GkxCwLBp2";
    
    public static string DidrectExchengeName => "direct_exchange";
}

