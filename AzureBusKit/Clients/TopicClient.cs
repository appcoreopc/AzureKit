
using Microsoft.Azure.ServiceBus;
using System.Threading.Tasks;

public class QueueProvider { 
    private readonly string connectionStirng;
    public QueueProvider(string connectionStirng)
    {
        this.connectionStirng = connectionStirng;
    }    

}