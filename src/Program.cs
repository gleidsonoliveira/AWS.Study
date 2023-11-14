using Amazon;
using Amazon.SQS;
using Amazon.SQS.Model;

namespace AWS.SQS
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //Envia
            var clientSend = new AmazonSQSClient(RegionEndpoint.USEast1);
            var requestSend = new SendMessageRequest
            {
                QueueUrl = "https://sqs.us-east-1.amazonaws.com/220535277493/Teste",
                MessageBody = "Teste - " + DateTime.Now.Second
            };

            var responseSend = await clientSend.SendMessageAsync(requestSend);


            //Recebe
            var client = new AmazonSQSClient(RegionEndpoint.USEast1);
            var request = new ReceiveMessageRequest
            {
                QueueUrl = "https://sqs.us-east-1.amazonaws.com/220535277493/Teste"
            };

            var response = await client.ReceiveMessageAsync(request);

            foreach (var Message in response.Messages)
            {
                Console.WriteLine(Message.MessageId);
                Console.WriteLine("==============================================================================");
                Console.WriteLine(Message.Body);
            }
        }
    }
}